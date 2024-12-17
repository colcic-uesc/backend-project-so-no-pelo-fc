using Microsoft.AspNetCore.Mvc;
using BackEndAPI.Service.Auth;
using BackEndAPI.Core.Dtos;
using BackEndAPI.Service.DataBase.Interfaces;

namespace UescColcicAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    private readonly IUserCRUD _usersCRUD;

    public AuthController(AuthService authService, IUserCRUD usersCRUD)
    {
        _authService = authService;
        _usersCRUD = usersCRUD;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] AuthDto authDto)
    {
        if(authDto.Username is null) return Unauthorized();

        var user = _usersCRUD.GetByUsername(authDto.Username);
        if(user is null) return Unauthorized();
        
        if (user.Password == authDto.Password)
        {   
            var token = _authService.GenerateJwtToken();
            return Ok(new { token });
        }

        return Unauthorized();
    }
}