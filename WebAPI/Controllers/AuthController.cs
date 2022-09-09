using Business.Abstract;
using Core.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("[action]")]
    public IActionResult Login(UserForLoginDto userForLoginDto)
    {
        var userToCheck = _authService.IsUserExists(userForLoginDto.Email);

        if (!userToCheck.Success)
        {
            return BadRequest(userToCheck);
        }
        
        var result = _authService.Login(userForLoginDto);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        var token = _authService.CreateToken(result.Data);
        return Ok(token);
    }
    
    [HttpPost("[action]")]
    public IActionResult Register(UserForRegisterDto userForRegisterDto)
    {
        var userToCheck = _authService.IsUserNotExists(userForRegisterDto.Email);
        
        if (!userToCheck.Success)
        {
            return BadRequest(userToCheck);
        }
        
        var result = _authService.Register(userForRegisterDto);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        var token = _authService.CreateToken(result.Data);
        return Ok(token);
    }
}