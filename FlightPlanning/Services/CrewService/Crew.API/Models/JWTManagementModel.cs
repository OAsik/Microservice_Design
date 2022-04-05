using Newtonsoft.Json;

namespace Crew.API.Models
{
    [JsonObject("jwtManagement")]
    public class JWTManagementModel
    {
        [JsonProperty("signInKey")]
        public string SignInKey { get; set; }
    }
}