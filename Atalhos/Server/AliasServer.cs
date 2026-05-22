using Atalhos.DbContext;
using Atalhos.DTO;
using Atalhos.Models;
using Atalhos.Repositories;

namespace Atalhos.Server
{
  public class AliasServer : DataServer<AliasModel>
  {
    public AliasServer() : base(new AliasRepository(new ApplicationDbContext()))
    {
    }

    public async Task<IEnumerable<AliasModel>> GetByAmbienteId(Guid ambienteId)
    {
      return (await _repository.GetAllAsync()).Where(x => x.AmbienteId == ambienteId);
    }

    internal async Task<IEnumerable<AliasModel>> GetByAmbienteId(Guid ambienteId, string servidor, string nomeBase)
    {
      return (await GetByAmbienteId(ambienteId)).Where(x => x.Servidor == servidor && x.BaseName == nomeBase);
    }

    internal AliasModel GetByAmbienteName(string nomeAmbiente, string servidor, string nomeBase)
    {
      return AliasConfigDTO.ToModel(GetByAmbienteName(nomeAmbiente).Where(x => x.Base == nomeBase && x.Servidor == servidor).FirstOrDefault());
    }

    internal IEnumerable<AliasConfigDTO> GetByAmbienteName(string nomeAmbiente)
    {
      var ambienteServer = new AmbienteServer();
      var ambiente = ambienteServer.GetByNameAsync(nomeAmbiente).Result;
      if (ambiente == null) return new List<AliasConfigDTO>();
      
      var list = GetByAmbienteId(ambiente.Id).Result.ToList();
      return list.Select(x => AliasConfigDTO.FromModel(x)).ToList(); 
    }
  }
}
