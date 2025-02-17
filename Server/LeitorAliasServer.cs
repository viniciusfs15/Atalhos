using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Atalhos
{
  public class LeitorAliasServer
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

    public LeitorAliasServer(string caminhoAmbiente)
    {
      AliasPath = Path.Combine(caminhoAmbiente, "Bin", StringConstantes.AliasDat);
    }

    public List<AliasConfig> GetAliasData(string versao, string unidade)
    {
      if (!File.Exists(AliasPath))
        return null;

      List<AliasConfig> listAliasConfig = new List<AliasConfig>();
      var aliasData = GetRMSAliasData();

      var configServer = new ConfigServer();

      foreach (var alias in aliasData.DbConfig)
      {
        var aliasConfig = configServer.GetAliasConfig(versao, alias.Alias, unidade);
        if (aliasConfig == null)
        {
          aliasConfig = new AliasConfig
          {
            Versao = versao,
            NomeAlias = alias.Alias,
            UsuarioRM = StringConstantes.Usuario,
            SenhaRM = StringConstantes.Senha,
          };
        }
        aliasConfig.AliasData.DbConfig.Add(alias);
        listAliasConfig.Add(aliasConfig);
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

    public void CreateAliasDat(AliasConfig alias)
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

    private void CriarXmlAliasDat(AliasConfig alias)
    {
      var xml = FormataXML(alias);
      File.WriteAllText(AliasPath, xml);
    }

    public string FormataXML(AliasConfig alias)
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

    static void AdicionarElementoXml(XmlDocument xmlDoc, XmlElement parentElement, string nome, string valor)
    {
      XmlElement elemento = xmlDoc.CreateElement(nome);
      elemento.InnerText = valor;
      parentElement.AppendChild(elemento);
    }
  }
}
