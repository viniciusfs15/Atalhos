using Atalhos.DbContext;
using Atalhos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atalhos.Repositories
{
  public class AliasRepository : Repository<AliasModel>, IRepository<AliasModel>
  {
    public AliasRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<AliasModel>> GetByAmbienteId(Guid ambienteId)
    {
      return await Task.Run(() => _dbSet.Where(x => x.AmbienteId == ambienteId).ToList());
    }

    public async Task<AliasModel?> GetByNomeAndAmbienteId(string nome, Guid ambienteId)
    {
      return await Task.Run(() => _dbSet.FirstOrDefault(x => x.Nome == nome && x.AmbienteId == ambienteId));
    }
  }

  public class AmbienteRepository : Repository<AmbienteModel>, IRepository<AmbienteModel>
  {
    public AmbienteRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<AmbienteModel?> GetByNome(string nome)
    {
      return await Task.Run(() => _dbSet.FirstOrDefault(x => x.Nome == nome));
    }

    public async Task<AmbienteModel?> GetFavorito()
    {
      return await Task.Run(() => _dbSet.FirstOrDefault(x => x.Favorito));
    }
  }
}
