using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public ActionResult<AuthResponseDto> Register([FromBody] RegisterRequestDto request)
    {
        var response = _authService.Register(request);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpPost("login")]
    public ActionResult<AuthResponseDto> Login([FromBody] LoginRequestDto request)
    {
        var response = _authService.Login(request);

        if (!response.Success)
        {
            return Unauthorized(response);
        }

        return Ok(response);
    }
}
