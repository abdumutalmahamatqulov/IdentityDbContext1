using IdentityDbContext1.Data;
using IdentityDbContext1.Dto_s;
using IdentityDbContext1.Entities;

namespace IdentityDbContext1.Services;
public interface IAuthService
{
    public Task<User> Register(UserDto request);
    public Task<string> Login(UserDto userDto);
    public Task<List<User>> UserList();
}
