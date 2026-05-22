using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Atalhos.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Atalhos.Repositories
{
  public class Repository<T> : IRepository<T> where T : class
  {
    protected readonly Microsoft.EntityFrameworkCore.DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(Microsoft.EntityFrameworkCore.DbContext context)
    {
      _context = context;
      _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
      return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
      return await _dbSet.FindAsync(id);
    }

    public async Task<EntityEntry<T>> AddAsync(T entity)
    {
      return await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
      var entry = _context.Entry(entity);

      // If entity is detached, check if a tracked local instance with same key exists.
      if (entry.State == EntityState.Detached)
      {
        // Try to find Id property (BaseModel.Id)
        var keyProp = typeof(T).GetProperty("Id");
        if (keyProp != null)
        {
          var keyVal = keyProp.GetValue(entity);
          var local = _dbSet.Local.FirstOrDefault(e =>
          {
            var localKey = keyProp.GetValue(e);
            return localKey != null && localKey.Equals(keyVal);
          });

          if (local != null)
          {
            // Copy values into the tracked instance to avoid duplicate tracking
            _context.Entry(local).CurrentValues.SetValues(entity);
            return;
          }
        }

        // No local tracked entity found — attach and mark modified
        _dbSet.Attach(entity);
        entry.State = EntityState.Modified;
      }
      else
      {
        // Already tracked by this context — mark as modified
        entry.State = EntityState.Modified;
      }
    }

    public void Delete(T entity)
    {
      var entry = _context.Entry(entity);

      if (entry.State == EntityState.Detached)
      {
        var keyProp = typeof(T).GetProperty("Id");
        if (keyProp != null)
        {
          var keyVal = keyProp.GetValue(entity);
          var local = _dbSet.Local.FirstOrDefault(e =>
          {
            var localKey = keyProp.GetValue(e);
            return localKey != null && localKey.Equals(keyVal);
          });

          if (local != null)
          {
            _dbSet.Remove(local);  // Remove the tracked instance
            return;
          }
        }
      }
      _dbSet.Remove(entity);
    }

    public async Task<int> SaveChangesAsync()
    {
      return await _context.SaveChangesAsync();
    }
  }
}
