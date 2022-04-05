using Newtonsoft.Json;
namespace Pilot.API.Models
{
    [JsonObject("jwtManagement")]
    public class JWTManagementModel
    {
        [JsonProperty("signInKey")]
        public string SignInKey { get; set; }
    }
}