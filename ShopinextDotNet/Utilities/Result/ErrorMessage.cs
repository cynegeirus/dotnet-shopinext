using Newtonsoft.Json;

namespace ShopinextDotNet.Utilities.Result;

public class ErrorMessage
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}