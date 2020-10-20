using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Sweepi.UserServiceAPI.Data;

namespace Sweepi.UserServiceAPI.Repository
{
  public class UserRepository<TEntity, TContext> : IUserRepository<TEntity>
    where TEntity : class, IEntity
    where TContext : DbContext
  {

    TContext _context;
    public UserRepository(TContext context)
    {
        _context = context;
    }

    public async Task<TEntity> Delete(string id)
    {
      var entity = await _context.Set<TEntity>().FindAsync(id);

      if (entity == null) return entity;

      _context.Set<TEntity>().Remove(entity);
      await _context.SaveChangesAsync();
      return entity;
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
      return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetById(string id)
    {
      return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity> Create(TEntity entity)
    {
      _context.Set<TEntity>().Add(entity);
      await _context.SaveChangesAsync();
      return entity;
    }

    public async Task<TEntity> Update(TEntity entity)
    {
      _context.Entry(entity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return entity;
    }
  }
}