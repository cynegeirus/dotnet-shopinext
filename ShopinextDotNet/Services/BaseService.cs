using System.Net.Http.Headers;
using Newtonsoft.Json;
using ShopinextDotNet.Constants;
using ShopinextDotNet.Enumerations;
using ShopinextDotNet.Utilities.Helpers;
using ShopinextDotNet.Utilities.Result;

namespace ShopinextDotNet.Services;

public class BaseService
{
    private readonly HttpClient _httpClient;

    private string? ApiUrlAddress { get; }
    public string? ApiClientId { get; }
    public string? ApiClientSecret { get; }

    public BaseService(EnvironmentType environmentType)
    {
        ApiClientId = ConfigurationHelper.GetConfig()?.GetSection("Endpoints:Credentials:ClientId").Value;
        ApiClientSecret = ConfigurationHelper.GetConfig()?.GetSection("Endpoints:Credentials:ClientSecret").Value;
        ApiUrlAddress = environmentType switch
        {
            EnvironmentType.Production => ConfigurationHelper.GetConfig()?.GetSection("Endpoints:Production").Value,
            EnvironmentType.Test => ConfigurationHelper.GetConfig()?.GetSection("Endpoints:Test").Value,
            _ => throw new ArgumentOutOfRangeException(nameof(environmentType), environmentType, null)
        };

        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(ApiUrlAddress!);
        _httpClient.DefaultRequestHeaders.Add("Domain", "accvalo.shop");
        _httpClient.DefaultRequestHeaders.Referrer = new Uri("https://accvalo.shop");
        _httpClient.DefaultRequestHeaders.Add("Origin", "https://accvalo.shop");
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36");
    }

    public void SetAuthorization(string? token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    public async Task<IDataResult<TResponse>>? PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
    {
        try
        {
            var requestBodyString = JsonConvert.SerializeObject(data, Formatting.Indented);
            var response = await _httpClient.PostAsync(endpoint, new StringContent(requestBodyString));
            var jsonString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return new SuccessDataResult<TResponse>(JsonConvert.DeserializeObject<TResponse>(jsonString)!, CustomMessage.TransactionSuccess);

            await FileLogHelper.WriteErrorLogAsync(new ErrorLog(DateTime.Now, $"PostAsync | Endpoint: {endpoint} | Content: {jsonString}", null));
            return new ErrorDataResult<TResponse>(CustomMessage.TransactionError);
        }
        catch (Exception ex)
        {
            await FileLogHelper.WriteErrorLogAsync(new ErrorLog(DateTime.Now, $"PostAsync | Endpoint: {endpoint}", ex));
            return new ErrorDataResult<TResponse>(CustomMessage.TransactionError);
        }
    }

    public async Task<IDataResult<TResponse>>? GetAsync<TResponse>(string endpoint)
    {
        try
        {
            var response = await _httpClient.GetAsync(endpoint);
            var jsonString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return new SuccessDataResult<TResponse>(JsonConvert.DeserializeObject<TResponse>(jsonString)!, CustomMessage.TransactionSuccess);

            return new ErrorDataResult<TResponse>(CustomMessage.TransactionError);
        }
        catch (Exception ex)
        {
            await FileLogHelper.WriteErrorLogAsync(new ErrorLog(DateTime.Now, $"GetAsync | Endpoint: {endpoint}", ex));
            return new ErrorDataResult<TResponse>(CustomMessage.TransactionError);
        }
    }
}