using Huddle.Business.Managers;
using Huddle.Contracts;
using Huddle.DataModels;
using Huddle.Interfaces.ManagersInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Huddle.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupsController : ControllerBase
{
    private readonly IGroupsManager _groupsManager;
    private readonly GroupsValidationManager _groupsValidationManager;
    public GroupsController(IGroupsManager groupsManager, GroupsValidationManager groupsValidationManager)
    {
        _groupsManager = groupsManager;
        _groupsValidationManager = groupsValidationManager;
    }
    
    [HttpGet]
    public async Task<ActionResult<BaseResponseContract<IEnumerable<Group>>>> GetAllGroupsQueryable(int skip, int take)
    {
        BaseResponseContract<IEnumerable<Group>> baseResponseContract = new BaseResponseContract<IEnumerable<Group>>();
        
        try
        {
            _groupsValidationManager.ValidateGetAllGroupsQueryable(skip, take);
            
            IEnumerable<Group> groups = await _groupsManager.GetEntitiesQueryableAsync(skip, take);

            if (!groups.Any())
            {
                baseResponseContract.Message = "No groups were found";
                return NotFound(baseResponseContract);
            }

            baseResponseContract.Message = "Successfully found groups";
            baseResponseContract.Success = true;
            baseResponseContract.Data = groups;
            return Ok(baseResponseContract);
        }
        catch (Exception e)
        {
            baseResponseContract.Message = e.Message;
            return BadRequest(baseResponseContract);
        }
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponseContract<Group>>> GetGroupById(int id)
    {
        BaseResponseContract<Group> baseResponseContract = new BaseResponseContract<Group>();
        
        try
        {
            _groupsValidationManager.ValidateId(id);
            
            Group? group = await _groupsManager.GetEntityByIdAsync(id);

            if (group == null)
            {
                baseResponseContract.Message = "No group was found";
                return NotFound(baseResponseContract);
            }
            
            baseResponseContract.Message = "Successfully found group";
            baseResponseContract.Success = true;
            baseResponseContract.Data = group;
            return Ok(baseResponseContract);
        }
        catch (Exception e)
        {
            baseResponseContract.Message = e.Message;
            return BadRequest(baseResponseContract);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<BaseResponseContract<Group>>> CreateGroup([FromBody] Group group)
    {
        BaseResponseContract<Group> baseResponseContract = new BaseResponseContract<Group>();
        
        try
        {
            _groupsValidationManager.ValidateGroup(group);
            
            Group? createdGroup = await _groupsManager.AddEntityAsync(group);

            if (createdGroup == null)
            {
                baseResponseContract.Message = "Group was not created";
                return BadRequest(baseResponseContract);
            }
            
            baseResponseContract.Message = "Successfully created group";
            baseResponseContract.Success = true;
            baseResponseContract.Data = createdGroup;
            return Ok(baseResponseContract);
        }
        catch (Exception e)
        {
            baseResponseContract.Message = e.Message;
            return BadRequest(baseResponseContract);
        }
    }
    
    [HttpPut]
    public async Task<ActionResult<BaseResponseContract<Group>>> UpdateGroup([FromBody] Group group)
    {
        BaseResponseContract<Group> baseResponseContract = new BaseResponseContract<Group>();
        
        try
        {
            Group updatedGroup = await _groupsManager.UpdateEntityAsync(group);

            baseResponseContract.Message = "Successfully updated group";
            baseResponseContract.Success = true;
            baseResponseContract.Data = updatedGroup;
            
            return Ok(baseResponseContract);
        }
        catch (Exception e)
        {
            baseResponseContract.Message = e.Message;
            return BadRequest(baseResponseContract);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGroup(int id)
    {
        BaseResponseContract<Group> baseResponseContract = new BaseResponseContract<Group>();
        
        try
        {
            _groupsValidationManager.ValidateId(id);
            
            Group deletedGroup = await _groupsManager.DeleteEntityAsync(id);
            
            baseResponseContract.Message = "Successfully deleted group";
            baseResponseContract.Success = true;
            baseResponseContract.Data = deletedGroup;

            return Ok(baseResponseContract);
        }
        catch (Exception e)
        {
            baseResponseContract.Message = e.Message;
            return BadRequest(baseResponseContract);
        }
    }
}