using Huddle.Contracts;
using Huddle.DataModels;
using Huddle.Interfaces.ManagersInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Huddle.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationManager _authenticationManager;

    public AuthenticationController(IAuthenticationManager authenticationManager)
    {
        _authenticationManager = authenticationManager;
    }
    
    [HttpPost]
    public async Task<ActionResult<BaseResponseContract<SignUpRequestContract>>> SignUp([FromBody] SignUpRequestContract signUpRequestContract)
    {
        BaseResponseContract<User> baseResponseContract =
            new BaseResponseContract<User>();
        
        try
        {
            User user = await _authenticationManager.SignUp(signUpRequestContract);
            
            baseResponseContract.Data = user;
            baseResponseContract.Message = "User created successfully";
            baseResponseContract.Success = true;
            
            return Ok(baseResponseContract);
        }
        catch (Exception e)
        {
            baseResponseContract.Message = e.Message;
            baseResponseContract.Success = false;
            
            return BadRequest(baseResponseContract);
        }
    }

}