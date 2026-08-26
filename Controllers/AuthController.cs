using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notes_API.Database;
using Notes_API.Entities;
using Notes_API.Services;
using Notes_API.Interfaces;
using Notes_API.Models;
using Notes_API.Models.Login;
using Notes_API.Models.Register;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Notes_API.Controllers;

public class AuthController : Controller
{
    private readonly IUserService _userService;
    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    //! GET: Auth/Register =========================================================================
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _userService.CreateUser(model.Name, model.Email, model.Password);

        return RedirectToAction("Login");
    }

    //! GET: Auth/Login ============================================================================
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = await _userService.GetUserByCredentialsAsync(
            model.Email,
            model.Password
        );

        if (user == null)
        {
            ModelState.AddModelError(
                "",
                "Неверный email или пароль."
            );

            return View(model);
        }

        var claims = new List<Claim>
        {
            new Claim(
                ClaimTypes.NameIdentifier,
                user.Id.ToString()
            ),
            new Claim(
                ClaimTypes.Name,
                user.Name
            ),
            new Claim(
                ClaimTypes.Email,
                user.Email
            )
        };

        var identity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme
        );

        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal
        );

        return RedirectToAction(
            "List",
            "Notes"
        );
    }
}