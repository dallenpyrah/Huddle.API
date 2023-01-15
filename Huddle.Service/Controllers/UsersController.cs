using Huddle.Contracts;
using Huddle.DataModels;
using Huddle.Interfaces.ManagersInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Huddle.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersManager _usersManager;

    public UsersController(IUsersManager usersManager)
    {
        _usersManager = usersManager;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponseContract<User>>> GetUserById(string id)
    {
        BaseResponseContract<User> baseResponseContract = new BaseResponseContract<User>();
        
        try
        {
            User? user = await _usersManager.GetEntityByIdAsync(id);
            
            if (user == null)
            {
                baseResponseContract.Message = "User not found";
                return NotFound(baseResponseContract);
            }
            
            baseResponseContract.Data = user;
            baseResponseContract.Success = true;
            baseResponseContract.Message = "User found";
            return Ok(baseResponseContract);
        }
        catch (Exception e)
        {
            baseResponseContract.Message = e.Message;
            baseResponseContract.Success = false;
            return baseResponseContract;
        }
    }
    
    

}