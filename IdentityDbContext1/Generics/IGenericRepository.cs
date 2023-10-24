using IdentityDbContext1.Dto_s;
using IdentityDbContext1.Entities;

namespace IdentityDbContext1.Generics;
public interface IGenericRepository<T> where T : class,IEntity
{
    Task<List<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> Add(T entity);
    Task<T> Update(int id,T entity);
    Task<T> Delete(int id);
}