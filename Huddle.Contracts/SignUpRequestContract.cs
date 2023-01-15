using Huddle.DataModels;

namespace Huddle.Contracts;

public class SignUpRequestContract
{
    public string DisplayName { get; set; }
    public string Email { get; set; }
    public string uId { get; set; }
}