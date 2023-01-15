using Huddle.Business.Managers;
using Huddle.DataModels;
using Huddle.Interfaces.ManagersInterfaces;

namespace Huddle.UnitTests;

public class GroupsValidationManagerTests
{
    private readonly IGroupsValidationManager _validationManager;

    public GroupsValidationManagerTests()
    {
        _validationManager = new GroupsValidationManager();
    }

    [Fact]
    public void ValidateId_IdIsZero_ThrowsArgumentException()
    {
        int id = 0;
        
        Assert.Throws<ArgumentException>(() => _validationManager.ValidateId(id));
    }

    [Fact]
    public void ValidateId_IdIsGreaterThanZero_DoesNotThrowException()
    {
        int id = 1;

        _validationManager.ValidateId(id);
    }

    [Fact]
    public void ValidateGroup_GroupIsNull_ThrowsArgumentNullException()
    {
        Group group = null;

        Assert.Throws<ArgumentNullException>(() => _validationManager.ValidateGroup(group));
    }

    [Fact]
    public void ValidateGroup_GroupNameIsEmpty_ThrowsArgumentException()
    {
        Group group = new Group { Name = "" };

        Assert.Throws<ArgumentException>(() => _validationManager.ValidateGroup(group));
    }

    [Fact]
    public void ValidateGroup_GroupNameIsTooLong_ThrowsArgumentException()
    {
        Group group = new Group { Name = new string('a', 51) };

        Assert.Throws<ArgumentException>(() => _validationManager.ValidateGroup(group));
    }
    
    [Fact]
    public void ValidateGroup_GroupDescriptionIsTooLong_ThrowsArgumentException()
    {
        Group group = new Group { Name = "Valid name", Description = new string('a', 501) };
        
        Assert.Throws<ArgumentException>(() => _validationManager.ValidateGroup(group));
    }
    
    [Fact]
    public void ValidateGroup_GroupDescriptionIsLessThanFiveHundredCharacters_DoesNotThrowArgumentException()
    {
        Group group = new Group { Name = "Valid name", Description = "Test" };

        _validationManager.ValidateGroup(group);
    }
}