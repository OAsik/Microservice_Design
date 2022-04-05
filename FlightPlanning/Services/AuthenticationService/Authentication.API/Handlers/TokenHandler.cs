using System.Text;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Authentication.API.Handlers.Base;

namespace Authentication.API.Handlers
{
    public class TokenHandler : ITokenHandler
    {
        public string IssueToken(string userName, string password, string signInKey)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signInKey));

            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, password)
            };

            var token = new JwtSecurityToken(claims: claims, signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}