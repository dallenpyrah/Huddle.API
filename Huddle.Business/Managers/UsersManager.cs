using Huddle.DataModels;
using Huddle.Interfaces.ManagersInterfaces;
using Huddle.Interfaces.RepositoryInterfaces;

namespace Huddle.Business.Managers;

public class UsersManager : IUsersManager
{
    private readonly IUsersRepository _usersRepository;

    public UsersManager(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
    
    public Task<User?> GetEntityByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetEntitiesQueryableAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<User> AddEntityAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateEntityAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<User> DeleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetEntityByIdAsync(string id)
    {
        User? user = _usersRepository.GetEntityByIdAsync(id);
        return Task.FromResult(user);
    }
}