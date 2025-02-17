using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Atalhos
{
  public class ConfigServer
  {
    private static string ConfigPath => Path.Combine(Directory.GetCurrentDirectory(), "Config.json");

    public void AddAliasConfig(AliasConfig aliasConfig)
    {
      var ListaAliasConfig = new List<AliasConfig>();
      
      var jsonData = File.ReadAllText(ConfigPath);

      if (!string.IsNullOrEmpty(jsonData))
      {
        ListaAliasConfig = JsonConvert.DeserializeObject<List<AliasConfig>>(jsonData);
      }
      
      if (ListaAliasConfig.Any(x => x.Versao == aliasConfig.Versao && x.Unidade == aliasConfig.Unidade && x.NomeAlias == aliasConfig.NomeAlias))
      {
        ListaAliasConfig.Remove(ListaAliasConfig.Find(x => x.Versao == aliasConfig.Versao && x.NomeAlias == aliasConfig.NomeAlias));
      }
      ListaAliasConfig.Add(aliasConfig);
      File.WriteAllText(ConfigPath,JsonConvert.SerializeObject(ListaAliasConfig));
    }

    public void UpdateAliasConfig(AliasConfig oldAlias, AliasConfig newAlias)
    {
      RemoveAliasConfig(oldAlias);
      AddAliasConfig(newAlias);
    }

    public void RemoveAliasConfig(AliasConfig aliasConfig)
    {
      var ListaAliasConfig = new List<AliasConfig>();

      var jsonData = File.ReadAllText(ConfigPath);

      if (!string.IsNullOrEmpty(jsonData))
      {
        ListaAliasConfig = JsonConvert.DeserializeObject<List<AliasConfig>>(jsonData);
        if (ListaAliasConfig.Any(x => x.Versao == aliasConfig.Versao && x.Unidade == aliasConfig.Unidade && x.NomeAlias == aliasConfig.NomeAlias))
        {
          ListaAliasConfig.Remove(ListaAliasConfig.Find(x => x.Versao == aliasConfig.Versao && x.NomeAlias == aliasConfig.NomeAlias));
          File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(ListaAliasConfig));
        }       
      }
    }

    public IEnumerable<AliasConfig> GetAliasByVersao(string versao)
    {
      var ListaAliasConfig = new List<AliasConfig>();

      if (!File.Exists(ConfigPath))
        File.Create(ConfigPath).Close();

      var jsonData = File.ReadAllText(ConfigPath);

      if (!string.IsNullOrEmpty(jsonData))
      {
        ListaAliasConfig = JsonConvert.DeserializeObject<List<AliasConfig>>(jsonData);
        return ListaAliasConfig.Where(x => x.Versao == versao);
      }
      return ListaAliasConfig;
    }

    public AliasConfig GetAliasConfig(string versao, string nomeAlias, string unidade)
    {
      var ListaAliasConfig = new List<AliasConfig>();
      
      if (!File.Exists(ConfigPath))
        File.Create(ConfigPath).Close();

      var jsonData = File.ReadAllText(ConfigPath);

      if (!string.IsNullOrEmpty(jsonData))
      {
        ListaAliasConfig = JsonConvert.DeserializeObject<List<AliasConfig>>(jsonData);
        var alias = ListaAliasConfig.Find(x => x.Versao == versao && x.Unidade == unidade && x.NomeAlias == nomeAlias);
        if (alias != null)
          return alias;
      }

      var aliasConfig = new AliasConfig
      {
        Versao = versao,
        NomeAlias = nomeAlias,
        UsuarioRM = StringConstantes.Usuario,
        SenhaRM = StringConstantes.Senha,
      };

      AddAliasConfig(aliasConfig);
      return aliasConfig;
    }
  }
}
