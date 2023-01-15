using Huddle.DataModels;
using Huddle.Interfaces.ManagersInterfaces;

namespace Huddle.Business.Managers;

public class GroupsManager : IGroupsManager

{
    public Task<Group?> GetEntityByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Group>> GetEntitiesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Group> AddEntityAsync(Group entity)
    {
        throw new NotImplementedException();
    }

    public Task<Group> UpdateEntityAsync(Group entity)
    {
        throw new NotImplementedException();
    }

    public Task<Group> DeleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }
    
    public Task<IEnumerable<Group>> GetEntitiesQueryableAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }
}