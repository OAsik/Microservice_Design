using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Authentication.API.Models;
using Microsoft.Extensions.Options;
using Authentication.API.Handlers.Base;
using Authentication.API.Repositories.Base;

namespace Authentication.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenHandler _tokenHandler;
        private readonly IUserRepository _userRepository;
        private readonly IOptions<JWTManagementModel> _options;

        public AuthenticationController(ITokenHandler tokenHandler, IUserRepository userRepository, IOptions<JWTManagementModel> options)
        {
            _options = options;
            _tokenHandler = tokenHandler;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> GenerateAccessToken([FromBody] LoginModel loginModel)
        {
            var user = await _userRepository.GetUser(loginModel.UserName);

            if (user == null)
            {
                return NotFound("User Not Found!");
            }

            //Do not forget to hash user passwords while storing them on real time scenarios
            var isValid = user.Password == loginModel.Password;

            if(!isValid)
            {
                return BadRequest("Could Not Authenticate User!");
            }

            var accessToken = _tokenHandler.IssueToken(loginModel.UserName, loginModel.Password, _options.Value.SignInKey);

            return Ok(accessToken);
        }
    }
}