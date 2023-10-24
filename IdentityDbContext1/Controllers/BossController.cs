using IdentityDbContext1.Entities;
using IdentityDbContext1.Generics;
using IdentityDbContext1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityDbContext1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BossController : MoldController<Boss, BossService>
{
    public BossController(BossService genericRepository) : base(genericRepository){ }
}
