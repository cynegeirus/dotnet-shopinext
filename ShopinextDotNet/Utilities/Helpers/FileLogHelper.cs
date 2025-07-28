using Newtonsoft.Json;
using ShopinextDotNet.Utilities.Result;

namespace ShopinextDotNet.Utilities.Helpers;

public static class FileLogHelper
{
    private static async Task WriteLogAsync<T>(T log, string logType)
    {
        try
        {
            var logDirectory = Path.Combine("logs", logType);
            if (!Directory.Exists(logDirectory)) Directory.CreateDirectory(logDirectory);

            var dateString = DateTime.Now.ToShortDateString().Replace(".", string.Empty).Replace("/", string.Empty);
            var path = Path.Combine(logDirectory, $"{dateString}.log");

            await using var sw = new StreamWriter(path, true);
            await sw.WriteLineAsync(JsonConvert.SerializeObject(log, Formatting.Indented));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    public static Task WriteErrorLogAsync(ErrorLog log)
    {
        return WriteLogAsync(log, "error");
    }

    public static Task WriteTransactionLogAsync(TransactionLog log)
    {
        return WriteLogAsync(log, "transaction");
    }
}