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

    internal void CreateAlias(string fullName, AliasConfigDTO alias)
    {
      var server = new AliasIOServer(fullName);
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

    internal void UpdateAlias(AmbienteDTO ambiente, AliasConfigDTO alias)
    {
      var aliasModel = AliasConfigDTO.ToModel(alias);
      var aliasExistente = _aliasServer.GetByAmbienteName(ambiente.Nome, alias.Servidor, alias.Base);
      if (aliasExistente == null)
      {
        return;
      }
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
      var server = new AliasIOServer(ambiente.FullName);
      var aliases = server.GetAliasData().Where(x => x.NomeAlias != "CorporeRM").ToList();
      foreach (var alias in aliases) 
      { 
        var aliasModel = AliasConfigDTO.ToModel(alias);
        AddAlias(ambiente, alias);
      }
    }
  }
}