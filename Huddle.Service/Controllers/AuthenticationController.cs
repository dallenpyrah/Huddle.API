using Huddle.Contracts;
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
        BaseResponseContract<SignUpResultContract> baseResponseContract =
            new BaseResponseContract<SignUpResultContract>();
        
        try
        {
            SignUpResultContract signUpResultContract = await _authenticationManager.SignUp(signUpRequestContract);
            
            baseResponseContract.Data = signUpResultContract;
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