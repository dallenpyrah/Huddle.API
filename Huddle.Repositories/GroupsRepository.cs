using System.Text.RegularExpressions;
using Huddle.Interfaces.RepositoryInterfaces;

namespace Huddle.Repositories;

public class GroupsRepository : IGroupsRepository
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

    public Task UpdateEntityAsync(Group entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }
}