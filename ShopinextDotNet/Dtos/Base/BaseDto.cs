using Newtonsoft.Json;

namespace ShopinextDotNet.Dtos.Base;

public class BaseDto : IDto
{
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}