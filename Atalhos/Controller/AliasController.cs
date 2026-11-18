using Atalhos.DTO;
using Atalhos.Models;
using Atalhos.Server;

namespace Atalhos
{
  public class AliasController
  {
    public AliasController()
    {
    }

    private AliasServer _aliasServer = new AliasServer();
    private AmbienteServer _ambienteServer = new AmbienteServer();

    internal IEnumerable<AliasConfigDTO> GetAliasByAmbienteName(string nome)
    {
      return _aliasServer.GetByAmbienteName(nome);
    }

    internal void RemoveAlias(AliasConfigDTO aliasAtual)
    {
      var aliasModel = AliasConfigDTO.ToModel(aliasAtual);
      _aliasServer.RemoveAsync(aliasModel).Wait();
    }

    internal void CreateAlias(string path, AliasConfigDTO alias)
    {
      var server = new AliasIOServer(path);
      server.CreateAliasDat(alias);
    }

    internal void AddAlias(AmbienteDTO ambiente, AliasConfigDTO aliasDTO)
    {
      Guid ambienteId = new Guid();
      var ambienteModel = _ambienteServer.GetByNameAsync(ambiente.Nome);
      var aliasModel = AliasConfigDTO.ToModel(aliasDTO);
      
      if(ambienteModel.Result == null || string.IsNullOrWhiteSpace(ambienteModel.Result.Nome))
      {
        ambienteId = ((AmbienteModel)_ambienteServer.AddAsync(AmbienteDTO.ToModel(ambiente)).Result.Entity).Id;
      }
      else
      {
        ambienteId = ambienteModel.Result.Id;
      }

      aliasModel.AmbienteId = ambienteId;
      if (_aliasServer.GetByAmbienteId(ambienteId, aliasModel.Servidor, aliasModel.BaseName).Result.Any())
      {
        return;
      }
      _aliasServer.AddAsync(aliasModel).Wait();
    }

    internal void UpdateAlias(AmbienteDTO ambiente, AliasConfigDTO aliasOriginal, AliasConfigDTO aliasEditado)
    {
      if (aliasOriginal == null) return;
      var ambienteModel = _ambienteServer.GetByNameAsync(ambiente.Nome).Result;
      if (ambienteModel == null) return;

      var aliasExistente = _aliasServer.GetByIdAsync(aliasOriginal.Id).Result;
      if (aliasExistente == null) return;

      var aliasModel = AliasConfigDTO.ToModel(aliasEditado);
      aliasModel.Id = aliasExistente.Id;
      aliasModel.AmbienteId = aliasExistente.AmbienteId;
      _aliasServer.UpdateAsync(aliasModel).Wait();
    }

    internal void ReadAllExistentAlias(List<AmbienteDTO> ambientes)
    {
      foreach (var ambiente in ambientes)
      {
        ReadExistentAlias(ambiente);
      }
    }

    internal void ReadExistentAlias(AmbienteDTO ambiente)
    {
      if (ambiente == null || string.IsNullOrWhiteSpace(ambiente.FullName))
        return;

      var server = new AliasIOServer(ambiente.Bin);
      var aliases = (server.GetAliasData() ?? new List<AliasConfigDTO>())
        .Where(x => x != null && x.NomeAlias != "CorporeRM")
        .ToList();
      foreach (var alias in aliases) 
      { 
        AddAlias(ambiente, alias);
      }
    }
  }
}