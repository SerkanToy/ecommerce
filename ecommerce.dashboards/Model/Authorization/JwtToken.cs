using System.Text.Json.Serialization;

namespace ecommerce.dashboards.Model.Authorization
{
    public class JwtToken
    {
        [JsonPropertyName("accesstoken")]
        public string AccessToken { get; set; } = string.Empty;
        [JsonPropertyName("expireat")]
        public DateTime ExpireAt { get; set; }
    }
}
