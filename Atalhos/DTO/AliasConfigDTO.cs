using Atalhos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Atalhos.DTO
{
  [Serializable]
  public class AliasConfigDTO
  {
    public Guid Id { get; set; }
    public Guid AmbienteId { get; set; }
    [JsonProperty(Order = 0)]
    public string Versao { get; set; }
    [JsonProperty(Order = 1)]
    public string NomeAlias { get; set; }
    public string UsuarioRM { get; set; } = "mestre";
    public string SenhaRM { get; set; } = "totvs";
    public string Base { get; set; }
    public string Servidor { get; set; }
    public bool RunService { get; set; } = false;
    public bool JobServerEnabled { get; set; } = false;
    public bool JobServerProcessPoolEnabled { get; set; } = false;
    public bool JobServerLocalOnly { get; set; } = false;
    public string Sgbd { get; set; }
    public string UsuarioDB { get; set; } = "SYSDBA";
    public string SenhaDB { get; set; } = "masterkey";
    public int JobServerMaxThreads { get; set; }

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
        if (Sgbd == "SQL")
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

    public AliasConfigDTO()
    {
      AliasData = new RMSAliasData();
      AliasData.DbConfig = new List<DbConfig>();
    }

    public static AliasModel ToModel(AliasConfigDTO dto)
    {
      return new AliasModel
      {
        Id = dto.Id,
        AmbienteId = dto.AmbienteId,
        Nome = dto.NomeAlias,
        Usuario = dto.UsuarioRM,
        Senha = dto.SenhaRM,
        Servidor = dto.Servidor,
        BaseName = dto.Base,
        RunService = dto.RunService,
        JobServerEnabled = dto.JobServerEnabled,
        JobServerProcessPoolEnabled = dto.JobServerProcessPoolEnabled,
        JobServerLocalOnly = dto.JobServerLocalOnly,
        Sgbd = dto.Sgbd,
        UsuarioDB = dto.UsuarioDB,
        SenhaDB = dto.SenhaDB,
        JobServerMaxThreads = dto.JobServerMaxThreads,
        DbType = dto.DbType,
        DbProvider = dto.DbProvider,
        DbServer = dto.DbServer,
        DbName = dto.DbName
      };
    }

    public static AliasConfigDTO FromModel(AliasModel model)
    {
      return new AliasConfigDTO
      {
        Id = model.Id,
        AmbienteId = model.AmbienteId,
        NomeAlias = model.Nome,
        UsuarioRM = model.Usuario,
        SenhaRM = model.Senha,
        Servidor = model.Servidor,
        Base = model.BaseName,
        RunService = model.RunService,
        JobServerEnabled = model.JobServerEnabled,
        JobServerProcessPoolEnabled = model.JobServerProcessPoolEnabled,
        JobServerLocalOnly = model.JobServerLocalOnly,
        Sgbd = model.Sgbd,
        UsuarioDB = model.UsuarioDB,
        SenhaDB = model.SenhaDB,
        JobServerMaxThreads = model.JobServerMaxThreads
      };
    }
  }
}