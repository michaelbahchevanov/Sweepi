using System.Threading.Tasks;
using System.Collections.Generic;
using Sweepi.ProductServiceAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Sweepi.ProductServiceAPI.Repository
{
  public class ProductRepository<TEntity, TContext> : IProductRepository<TEntity>
    where TEntity : class, IEntity
    where TContext : DbContext
  {

    readonly TContext _context;

    public ProductRepository(TContext context)
    {
        _context = context;
    }

    public async Task<TEntity> Create(TEntity entity)
    {
      _context.Set<TEntity>().Add(entity);
      await _context.SaveChangesAsync();
      return entity;
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

    public async Task<TEntity> Update(TEntity entity)
    {
      _context.Entry(entity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return entity;
    }
  }
}