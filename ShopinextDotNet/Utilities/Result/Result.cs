namespace ShopinextDotNet.Utilities.Result;

public class Result(bool success) : IResult
{
    protected Result(bool success, string? message) : this(success)
    {
        Message = message;
    }

    public bool Success { get; } = success;

    public string? Message { get; }
}