using Huddle.Contracts;
using Huddle.Interfaces.ManagersInterfaces;

namespace Huddle.Business.Managers;

public class AuthenticationManager : IAuthenticationManager
{
    public Task<SignUpResultContract> SignUp(SignUpRequestContract signUpRequestContract)
    {
        throw new NotImplementedException();
    }
}