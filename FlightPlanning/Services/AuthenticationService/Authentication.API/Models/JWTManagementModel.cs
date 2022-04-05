using Newtonsoft.Json;

namespace Authentication.API.Models
{
    [JsonObject("jwtManagement")]
    public class JWTManagementModel
    {
        [JsonProperty("signInKey")]
        public string SignInKey { get; set; }

        [JsonProperty("scheme")]
        public string Scheme { get; set; }
    }
}