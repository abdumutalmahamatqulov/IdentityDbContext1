using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IdentityDbContext1.Services;
using IdentityDbContext1.Data;
using IdentityDbContext1.Entities;
using IdentityDbContext1.Dto_s;
using Microsoft.EntityFrameworkCore;
using IdentityDbContext1.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace IdentityDbContext1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService) => _authService = authService;

    [HttpGet("ListUsers"), Authorize]
    public async Task<IActionResult> GetAllUsers() => Ok(await _authService.UserList());

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(UserDto request) => Ok(await _authService.Register(request));

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserDto request) => Ok(await _authService.Login(request));

}
