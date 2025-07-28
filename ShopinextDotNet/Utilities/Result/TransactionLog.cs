namespace ShopinextDotNet.Utilities.Result;

public class TransactionLog
{
    public DateTime Logged { get; set; }
    public DateTime? Requested { get; set; }
    public DateTime? Responded { get; set; }
    public string? ResponseCode { get; set; }
    public bool? IsSuccess { get; set; }
    public string? ConnectionId { get; set; }
    public string? RemoteIpAddress { get; set; }
    public string? RemotePort { get; set; }
    public string? LocalIpAddress { get; set; }
    public string? LocalPort { get; set; }
    public string? Method { get; set; }
    public string? Path { get; set; }
    public string? QueryString { get; set; }
    public string? Payload { get; set; }
    public string? Response { get; set; }
}