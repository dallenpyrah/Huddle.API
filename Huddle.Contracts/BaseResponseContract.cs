namespace Huddle.Contracts;

public class BaseResponseContract
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }
}