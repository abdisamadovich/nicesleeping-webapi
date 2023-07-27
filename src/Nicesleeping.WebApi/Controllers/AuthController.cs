using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NicesleepingShop.Service.Dtos.Auth;
using NicesleepingShop.Service.Interfaces.Auth;
using NicesleepingShop.Service.Validators.Dtos.Auth;

namespace NicesleepingShop.WebApi.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        this._authService = authService;
    }
    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAsync([FromForm] RegisterDto registerDto)
    {
        var validator = new RegisterValidator();
        var result = validator.Validate(registerDto);
        if (result.IsValid)
        {
            var serviceResult = await _authService.RegisterAsync(registerDto);
            return Ok(new { serviceResult.Result, serviceResult.CachedMinutes });
        }
        else return BadRequest(result.Errors);
    }
}
