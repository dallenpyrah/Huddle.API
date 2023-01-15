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
    private readonly BaseResponseContract _baseResponseContract;

    public GroupsController(IGroupsManager groupsManager, BaseResponseContract baseResponseContract)
    {
        _groupsManager = groupsManager;
        _baseResponseContract = baseResponseContract;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllGroups()
    {
        try
        {
            IEnumerable<Group> groups = await _groupsManager.GetEntitiesAsync();

            if (!groups.Any())
            {
                _baseResponseContract.Message = "No groups were found";
                return NotFound(_baseResponseContract);
            }
            
            _baseResponseContract.Message = "Successfully found groups";
            _baseResponseContract.Success = true;
            _baseResponseContract.Data = groups;
            return Ok(_baseResponseContract);
        }
        catch (Exception e)
        {
            _baseResponseContract.Message = e.Message;
            return BadRequest(_baseResponseContract);
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetGroupById(int id)
    {
        try
        {
            Group? group = await _groupsManager.GetEntityByIdAsync(id);

            if (group == null)
            {
                _baseResponseContract.Message = "No group was found";
                return NotFound(_baseResponseContract);
            }
            
            _baseResponseContract.Message = "Successfully found group";
            _baseResponseContract.Success = true;
            _baseResponseContract.Data = group;
            return Ok(_baseResponseContract);
        }
        catch (Exception e)
        {
            _baseResponseContract.Message = e.Message;
            return BadRequest(_baseResponseContract);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateGroup([FromBody] Group group)
    {
        try
        {
            Group? createdGroup = await _groupsManager.AddEntityAsync(group);

            if (createdGroup == null)
            {
                _baseResponseContract.Message = "Group was not created";
                return BadRequest(_baseResponseContract);
            }
            
            _baseResponseContract.Message = "Successfully created group";
            _baseResponseContract.Success = true;
            _baseResponseContract.Data = createdGroup;
            return Ok(_baseResponseContract);
        }
        catch (Exception e)
        {
            _baseResponseContract.Message = e.Message;
            return BadRequest(_baseResponseContract);
        }
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateGroup([FromBody] Group group)
    {
        try
        {
            await _groupsManager.UpdateEntityAsync(group);
            
            _baseResponseContract.Message = "Successfully updated group";
            _baseResponseContract.Success = true;
            
            return Ok(_baseResponseContract);
        }
        catch (Exception e)
        {
            _baseResponseContract.Message = e.Message;
            return BadRequest(_baseResponseContract);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGroup(int id)
    {
        try
        {
            await _groupsManager.DeleteEntityAsync(id);
            
            _baseResponseContract.Message = "Successfully deleted group";
            _baseResponseContract.Success = true;
            
            return Ok(_baseResponseContract);
        }
        catch (Exception e)
        {
            _baseResponseContract.Message = e.Message;
            return BadRequest(_baseResponseContract);
        }
    }
}