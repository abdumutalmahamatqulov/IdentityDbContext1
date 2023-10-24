using IdentityDbContext1.Data;
using IdentityDbContext1.Entities;
using IdentityDbContext1.Generics;

namespace IdentityDbContext1.Services;
public class BossService : GenericRepository<Boss, AppDbContext>
{
    public BossService(AppDbContext context) : base(context) { }
}
