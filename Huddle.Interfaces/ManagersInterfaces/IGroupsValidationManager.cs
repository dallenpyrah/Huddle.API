using Huddle.DataModels;

namespace Huddle.Interfaces.ManagersInterfaces;

public interface IGroupsValidationManager
{
    public void ValidateId(int id);
    public void ValidateGroup(Group group);

}