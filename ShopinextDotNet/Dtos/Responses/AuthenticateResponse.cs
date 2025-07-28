using Newtonsoft.Json;

namespace ShopinextDotNet.Dtos.Responses;

public class AuthenticateResponse
{
    [JsonProperty("status")] public int Status { get; set; }

    [JsonProperty("access_token")] public string? AccessToken { get; set; }

    [JsonProperty("refresh_token")] public string? RefreshToken { get; set; }

    [JsonProperty("access_token_validity")]
    public DateTime AccessTokenValidity { get; set; }

    [JsonProperty("refresh_token_validity")]
    public DateTime RefreshTokenValidity { get; set; }
}