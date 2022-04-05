using Newtonsoft.Json;

namespace Flight.API.Models
{
    [JsonObject("jwtManagement")]
    public class JWTManagementModel
    {
        [JsonProperty("signInKey")]
        public string SignInKey { get; set; }
    }
}