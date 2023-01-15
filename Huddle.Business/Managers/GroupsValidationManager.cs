using Huddle.DataModels;
using Huddle.Interfaces.ManagersInterfaces;

namespace Huddle.Business.Managers;

public class GroupsValidationManager : IGroupsValidationManager
{
    public void ValidateId(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id must be greater than 0");
        }
    }

    public void ValidateGroup(Group group)
    {
        if (group == null)
        {
            throw new ArgumentNullException("group");
        }

        if (string.IsNullOrEmpty(group.Name))
        {
            throw new ArgumentException("Group name cannot be empty");
        }
        
        if (group.Name.Length > 50)
        {
            throw new ArgumentException("Group name cannot be longer than 50 characters");
        }
        
        if (group.Description.Length > 500)
        {
            throw new ArgumentException("Group description cannot be longer than 500 characters");
        }
    }

    public void ValidateGetAllGroupsQueryable(int skip, int take)
    {
        if (skip < 0)
        {
            throw new ArgumentException("Skip cannot be less than 0");
        }

        if (take <= 0)
        {
            throw new ArgumentException("Take cannot be less than or equal to 0");
        }
    }
}