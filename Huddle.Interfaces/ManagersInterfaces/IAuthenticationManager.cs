using Huddle.Contracts;
using Huddle.DataModels;

namespace Huddle.Interfaces.ManagersInterfaces;

public interface IAuthenticationManager
{
    Task<User> SignUp(SignUpRequestContract signUpRequestContract);
}