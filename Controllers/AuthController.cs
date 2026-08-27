using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notes_API.Database;
using Notes_API.Entities;
using Notes_API.Services;
using Notes_API.Interfaces;
using Notes_API.DTOs;

namespace Notes_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller
{
    private readonly IAuthService auth;
    public AuthController(IAuthService authService)
    {
        auth = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
    {
        var user = await auth.RegisterAsync(dto.Email, dto.Name, dto.Password);

        if (user == null)
            return BadRequest("User already exists");

        return Ok(new
        {
            user.Id,
            user.Email,
            user.Name
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO dto)
    {
        var token = await auth.LoginAsync(dto.Email, dto.Password);

        if (token == null)
            return Unauthorized("Invalid credentials");

        return Ok(new
        {
            token
        });
    }
}