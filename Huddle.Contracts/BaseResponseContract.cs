namespace Huddle.Contracts;

public class BaseResponseContract<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
}