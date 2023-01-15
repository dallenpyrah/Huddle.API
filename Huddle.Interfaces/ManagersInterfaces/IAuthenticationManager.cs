using Huddle.Contracts;

namespace Huddle.Interfaces.ManagersInterfaces;

public interface IAuthenticationManager
{
    Task<SignUpResultContract> SignUp(SignUpRequestContract signUpRequestContract);
}