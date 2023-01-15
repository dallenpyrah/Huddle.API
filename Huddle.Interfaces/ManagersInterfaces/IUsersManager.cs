using Huddle.DataModels;
using Huddle.Interfaces.BaseInterfaces;

namespace Huddle.Interfaces.ManagersInterfaces;

public interface IUsersManager : IBaseRestOperations<User>
{
    Task<User?> GetEntityByIdAsync(string id);
}