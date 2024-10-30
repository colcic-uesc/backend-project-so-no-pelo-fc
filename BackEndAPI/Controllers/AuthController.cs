using Microsoft.AspNetCore.Mvc;
using BackEndAPI.Service.Auth;
using BackEndAPI.Core.Dtos;

namespace UescColcicAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] AuthDto authDto)
    {
        if (authDto.Username == "admin" && authDto.Password == "admin")
        {   
            var token = _authService.GenerateJwtToken();
            return Ok(new { token });
        }

        return Unauthorized();
    }
}