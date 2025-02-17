using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Atalhos
{
  [Serializable]
  public class AliasConfig
  {
    [JsonProperty(Order = 0)]
    public string Versao { get; set; }
    [JsonProperty(Order = 1)]
    public string NomeAlias { get; set; }
    public string UsuarioRM { get; set; }
    public string SenhaRM { get; set; }
    public string Base { get; set; }
    public string Servidor {  get; set; }
    public bool RunService { get; set; } = false;
    public bool JobServerEnabled { get; set; } = false;
    public bool JobServerProcessPoolEnabled { get; set; } = false;
    public bool JobServerLocalOnly { get; set; } = false;
    public string Sgbd { get; set; }
    public string UsuarioDB { get; set; } = "SYSDBA";
    public string SenhaDB { get; set; } = "masterkey";
    public int JobServerMaxThreads { get; set; }
    public string Unidade { get; set; }

    public string DbType
    {
      get
      {
        if (Sgbd == "SQL")
          return "SqlServer";
        return "Oracle";
      }
    }

    public string DbProvider 
    { 
      get 
      {
        if(Sgbd == "SQL")
          return "SqlClient";
        return "OracleClient";
      }
    }

    public string DbServer
    {
      get
      {
        if (Sgbd == "SQL")
          return Servidor;
        return string.Join("/", Servidor, Base);
      }
    }

    public string DbName
    {
      get
      {
        if (Sgbd == "SQL")
          return Base;
        return string.Empty;
      }
    }

    [JsonIgnore]
    public RMSAliasData AliasData { get; set; }

    public AliasConfig() 
    {
      AliasData = new RMSAliasData();
      AliasData.DbConfig = new List<DbConfig>();
    }
  }
}