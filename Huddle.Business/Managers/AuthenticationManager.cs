using Huddle.Contracts;
using Huddle.DataModels;
using Huddle.Interfaces.ManagersInterfaces;
using Huddle.Interfaces.RepositoryInterfaces;

namespace Huddle.Business.Managers;

public class AuthenticationManager : IAuthenticationManager
{
    private readonly IUsersRepository _usersRepository;

    public AuthenticationManager(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<User> SignUp(SignUpRequestContract signUpRequestContract)
    {
        User? existingUser = _usersRepository.GetUserByEmail(signUpRequestContract.Email);
        
        if (existingUser != null)
        {
            throw new Exception("User already exists");
        }
        
        User userToCreate = new User
        {
            Email = signUpRequestContract.Email,
            Name = signUpRequestContract.DisplayName,
            FireBaseId = signUpRequestContract.uId
        };

        User createdUser = await _usersRepository.AddEntityAsync(userToCreate);
        return createdUser;
    }
}