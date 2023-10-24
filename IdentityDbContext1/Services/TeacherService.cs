using IdentityDbContext1.Data;
using IdentityDbContext1.Entities;
using IdentityDbContext1.Generics;

namespace IdentityDbContext1.Services;
public class TeacherService :GenericRepository<Teacher,AppDbContext>
{
    public TeacherService(AppDbContext appDbContext) : base(appDbContext) { }
}
