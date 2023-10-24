using System.Linq;
using IdentityDbContext1.Data;
using IdentityDbContext1.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityDbContext1.Generics;
public class GenericRepository<TEntity, TContext>:IGenericRepository<TEntity> where TEntity : class,IEntity where TContext:DbContext
{
    private readonly TContext _context;

    public GenericRepository(TContext context) => _context = context;

    public async Task<TEntity> Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> Delete(int id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if(entity != null) 
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        return entity;
    }

    public async Task<List<TEntity>> GetAll() => await _context.Set<TEntity>().ToListAsync();

    public async Task<TEntity> GetById(int id) => await _context.Set<TEntity>().FindAsync(id);

    public async Task<TEntity> Update(int id, TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }
}

