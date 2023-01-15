using Huddle.DataModels;
using Huddle.DbContext;
using Huddle.Interfaces;
using Huddle.Interfaces.RepositoryInterfaces;

namespace Huddle.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly HuddleDbContext _context;

    public UsersRepository(HuddleDbContext context)
    {
        _context = context;
    }

    public User? GetEntityByIdAsync(string id)
    {
        return _context.Users.FirstOrDefault(x => x.FireBaseId == id);
    }

    public User? GetUserByEmail(string userEmail)
    {
        return _context.Users.FirstOrDefault(u => u.Email == userEmail);
    }

    public Task<User?> GetEntityByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetEntitiesQueryableAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<User> AddEntityAsync(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return Task.FromResult(user);
    }

    public Task<User> UpdateEntityAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<User> DeleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }
}