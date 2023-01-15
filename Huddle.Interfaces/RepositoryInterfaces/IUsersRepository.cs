using Huddle.DataModels;
using Huddle.Interfaces.BaseInterfaces;

namespace Huddle.Interfaces.RepositoryInterfaces;

public interface IUsersRepository : IBaseRestOperations<User>
{
    User? GetEntityByIdAsync(string id);
    User? GetUserByEmail(string userEmail);
}