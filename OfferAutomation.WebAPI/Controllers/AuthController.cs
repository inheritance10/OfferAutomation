using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OfferAutomation.Application.DTOs.Auth;
using OfferAutomation.Application.Interfaces;

using System;
using System.Security.Claims;

namespace OfferAutomation.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var userId = await _authService.RegisterAsync(dto);
        return Ok(new { message = "Kayıt başarılı", userId });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var (token, refreshToken) = await _authService.LoginAsync(dto);
        return Ok(new { token, refreshToken });
    }


    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken(RefreshTokenDto dto)
    {
        try
        {
            var (token, refreshToken) = await _authService.RefreshTokenAsync(dto);
            return Ok(new { token, refreshToken });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { error = ex.Message });
        }
    }

    [Authorize]
    [HttpGet("profile")]
    public IActionResult Profile()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        var role = User.FindFirst(ClaimTypes.Role)?.Value;

        return Ok(new { userId, email, role });
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("admin-only")]
    public IActionResult AdminPanel()
    {
        return Ok("Sadece admin kullanıcılar burayı görebilir.");
    }



}
