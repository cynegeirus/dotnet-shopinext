using Newtonsoft.Json;

namespace ShopinextDotNet.Dtos.Requests;

public class AuthenticateRequest
{
    [JsonProperty("client_id")] public string? ClientId { get; set; }
    [JsonProperty("client_secret")] public string? ClientSecret { get; set; }
}