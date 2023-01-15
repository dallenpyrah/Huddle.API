
using Huddle.DataModels;
using Huddle.Interfaces.RepositoryInterfaces;

namespace Huddle.Repositories;

public class GroupsRepository : IGroupsRepository
{
    public Task<Group?> GetEntityByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Group>> GetEntitiesQueryableAsync(int skip, int take)
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
}