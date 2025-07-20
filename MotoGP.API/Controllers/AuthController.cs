using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoGP.Application.Auth;
using MotoGP.Shared.Responses;

namespace MotoGP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) => _authService = authService;

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest req) =>
        Ok(await _authService.RegisterAsync(req));

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest req)
    {
        var res = await _authService.LoginAsync(req);
        return Ok(ApiResponse<string>.Ok("Đăng nhập thành công"));
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] string refreshToken) =>
        Ok(await _authService.RefreshTokenAsync(refreshToken));
}

