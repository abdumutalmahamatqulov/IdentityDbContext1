using IdentityDbContext1.Data;
using IdentityDbContext1.Entities;
using IdentityDbContext1.Extensions;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System;
using IdentityDbContext1.Controllers;
using Microsoft.EntityFrameworkCore;
using IdentityDbContext1.Dto_s;
using Microsoft.AspNetCore.Http.HttpResults;

namespace IdentityDbContext1.Services;
public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthService(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, AppDbContext context)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _context = context;
    }

    public async Task<User> Register(UserDto request)
    {
        var user = new User
        {
            UserName = request.Name,
            Email = request.Email
        };
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            throw new Exception("Password isn't hashed");
        }

        await _userManager.AddToRoleAsync(user, Enum.GetName(request.Role).ToUpper());
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<string> Login(UserDto request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(e => e.Email == request.Email);

        if (user != null)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();
            roleClaims.Add(new Claim(ClaimTypes.Name, request.Name));
            var token = CreateTokenInJwtAuthorizationFromUsers.CreateToken(user, roleClaims);
            return token;
        }

        throw new BadHttpRequestException("User not found.");
    }

    public async Task<List<User>> UserList() => await _context.Users.ToListAsync();
}
