namespace ShopinextDotNet.Utilities.Result;

public class ErrorLog
{
    public DateTime Logged { get; set; }
    public string? Title { get; set; }
    public Exception? Exception { get; set; }

    public ErrorLog()
    {
    }

    public ErrorLog(DateTime logged, string? title, Exception? exception)
    {
        Logged = logged;
        Title = title;
        Exception = exception;
    }
}