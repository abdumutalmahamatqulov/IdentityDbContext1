using IdentityDbContext1.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace IdentityDbContext1.Data;
public class AppDbContext : IdentityDbContext<User>
{
    private IServiceProvider services;


    public AppDbContext(DbContextOptions<AppDbContext> options, IServiceProvider services) : base(options)
    {
        this.Service = services;
    }
    public IServiceProvider Service { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Boss> Bosss { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration<IdentityRole>(new RoleConfiguration(Service));
    }
}
