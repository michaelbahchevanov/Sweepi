using System.Threading.Tasks;
using System.Collections.Generic;
using Sweepi.ProductServiceAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Sweepi.ProductServiceAPI.Repository
{
  public class ProductRepository<TEntity, TContext> : IProductRepository<TEntity>
    where TEntity : class, IEntity
    where TContext : ProductDbContext
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

    public async Task<IEnumerable<TEntity>> GetAll(string userId)
    {
            return await _context.Set<TEntity>().Where(x => x.UserId == userId).ToListAsync();
    }

    public async Task<TEntity> GetById(string id)
    {
            return await _context.Set<TEntity>().FirstAsync(x => x.UserId == id);
    }

    public async Task<TEntity> Update(TEntity entity)
    {
            _context.Entry(await _context.Products.FirstOrDefaultAsync(x => x.Id == entity.Id)).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return entity;
    }
  }
}