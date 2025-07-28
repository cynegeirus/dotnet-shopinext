using Newtonsoft.Json;

namespace ShopinextDotNet.Dtos.Responses;

public class PaymentResponse
{
    [JsonProperty("status")] public int Status { get; set; }
    [JsonProperty("payment_id")] public string? PaymentId { get; set; }
    [JsonProperty("redirect_url")] public string? RedirectUrl { get; set; }
}