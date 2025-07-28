using Microsoft.Extensions.Configuration;

namespace ShopinextDotNet.Utilities.Helpers;

public class ConfigurationHelper
{
    private static IConfigurationRoot? _configuration;

    public ConfigurationHelper()
    {
        if (_configuration == null) GetConfigFileSet();
    }

    public static IConfiguration? GetConfig()
    {
        GetConfigFileSet();
        return _configuration;
    }

    private static void GetConfigFileSet()
    {
        _configuration ??= new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("configurationSettings.json", true, true).AddEnvironmentVariables().Build();
    }
}