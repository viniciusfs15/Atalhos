using Atalhos.DTO;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Atalhos.Server
{
  public class AliasIOServer
  {
    private XmlSerializer Serializer
    {
      get
      {
        if (_serializer == null)
          _serializer = new XmlSerializer(typeof(RMSAliasData));
        return _serializer;
      }
    }
    private XmlSerializer _serializer { get; set; }

    private string AliasPath { get; set; }

    public AliasIOServer(string caminhoAmbiente)
    {
      AliasPath = Path.Combine(caminhoAmbiente, "Bin", StringConstantes.AliasDat);
    }

    public List<AliasConfigDTO> GetAliasData()
    {
      if (!File.Exists(AliasPath))
        return null;

      List<AliasConfigDTO> listAliasConfig = new List<AliasConfigDTO>();
      var aliasData = GetRMSAliasData();

      foreach (var alias in aliasData.DbConfig)
      {
        var newAlias = new AliasConfigDTO();
        newAlias.NomeAlias = alias.Alias;
        newAlias.Sgbd = alias.DbType == "SqlServer" ? "SQL" : "Oracle";
        if (alias.DbType == "SqlServer")
        {
          newAlias.Servidor = alias.DbServer;
          newAlias.Base = alias.DbName;
        }
        else
        {
          newAlias.Servidor = alias.DbServer.Split("/")[0];
          newAlias.Base = alias.DbServer.Split("/")[0];
        }

        newAlias.UsuarioDB = alias.UserName;
        newAlias.SenhaDB = alias.Password;
        newAlias.RunService = alias.RunService;
        newAlias.JobServerEnabled = alias.JobServerEnabled;
        newAlias.JobServerMaxThreads = alias.JobServerMaxThreads;
        newAlias.JobServerLocalOnly = alias.JobServerLocalOnly;
        newAlias.JobServerProcessPoolEnabled = alias.JobServerProcessPoolEnabled;

        listAliasConfig.Add(newAlias);
      }
      return listAliasConfig;
    }

    private RMSAliasData GetRMSAliasData()
    {
      using (StreamReader reader = new StreamReader(AliasPath))
      {
        return (RMSAliasData)Serializer.Deserialize(reader);
      }
    }

    public void CreateAliasDat(AliasConfigDTO alias)
    {
      if(alias == null)
        return;

      DeleteAliasDat();
      CriarXmlAliasDat(alias);
    }

    private void DeleteAliasDat()
    {
      if (File.Exists(AliasPath))
      {
        File.Delete(AliasPath);
      }
    }

    private void CriarXmlAliasDat(AliasConfigDTO alias)
    {
      var xml = FormataXML(alias);
      File.WriteAllText(AliasPath, xml);
    }

    public string FormataXML(AliasConfigDTO alias)
    {
      var dbname = alias.Sgbd == "SQL" ? $"<DbName>{alias.Base}</DbName>" : "<DbName/>";
      return $@"<?xml version=""1.0"" standalone=""yes""?>
<RMSAliasData xmlns=""http://tempuri.org/RMSAliasData.xsd"">
  <DbConfig>
    <Alias>CorporeRM</Alias>
    <DbType>{alias.DbType}</DbType>
    <DbProvider>{alias.DbProvider}</DbProvider>
    <DbServer>{alias.DbServer}</DbServer>
    {dbname}
    <UserName>{alias.UsuarioDB}</UserName>
    <Password>{alias.SenhaDB}</Password>
    <RunService>{alias.RunService.ToString().ToLower()}</RunService>
    <JobServerEnabled>{alias.JobServerEnabled.ToString().ToLower()}</JobServerEnabled>
    <JobServerMaxThreads>{alias.JobServerMaxThreads}</JobServerMaxThreads>
    <JobServerLocalOnly>{alias.JobServerLocalOnly.ToString().ToLower()}</JobServerLocalOnly>
    <JobServerPollingInterval>10</JobServerPollingInterval>
    <ChartAlertEnabled>false</ChartAlertEnabled>
    <ChartAlertPollingInterval>20</ChartAlertPollingInterval>
    <ChartHistoryEnabled>false</ChartHistoryEnabled>
    <ChartHistoryPollingInterval>20</ChartHistoryPollingInterval>
    <RSSReaderMailEnabled>false</RSSReaderMailEnabled>
    <RSSReaderMailPollingInterval>10</RSSReaderMailPollingInterval>
    <JobServerProcessPoolEnabled>{alias.JobServerProcessPoolEnabled.ToString().ToLower()}</JobServerProcessPoolEnabled>
  </DbConfig>
</RMSAliasData>";
    }
  }
}
