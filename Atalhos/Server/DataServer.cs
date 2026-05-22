using Atalhos.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atalhos.Server
{
  public class DataServer<T> where T : class
  {
    protected readonly IRepository<T> _repository;
    public DataServer(IRepository<T> repository)
    {
      _repository = repository;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
      return await _repository.GetAllAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
      return await _repository.GetByIdAsync(id);
    }

    public async Task<EntityEntry<T>> AddAsync(T entity)
    {
      var retorno = await _repository.AddAsync(entity);
      await _repository.SaveChangesAsync();
      return retorno;
    }

    public async Task UpdateAsync(T entity)
    {
      _repository.Update(entity);
      await _repository.SaveChangesAsync();
    }

    public async Task RemoveAsync(T entity)
    {
      _repository.Delete(entity);
      await _repository.SaveChangesAsync();
    }
  }
}
