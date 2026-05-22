using Atalhos.Models;

namespace Atalhos.DTO
{
  public class AmbienteConfigDTO
  {
    public Guid? Id { get; set; }
    public Guid? AmbienteId { get; set; }
    public string? Host { get; set; } = string.Empty;
    public int? Port { get; set; }
    public int? HttpPort { get; set; }
    public int? ApiPort { get; set; }
    public bool? JobServer3Camadas { get; set; }
    public bool? DefaultDB { get; set; }
    public bool? NormalizePath { get; set; }
    public bool? EnableProcessIsolation { get; set; }
    public bool? IsolateProcess { get; set; }
    public bool? EnableCompression { get; set; }
    public static AmbienteConfigModel ToModel(AmbienteConfigDTO dto)
    {
      return new AmbienteConfigModel
      {
        Id = dto.Id ?? Guid.Empty,
        AmbienteId = dto.AmbienteId ?? Guid.Empty,
        Host = dto.Host ?? string.Empty,
        Port = dto.Port ?? -1,
        HttpPort = dto.HttpPort ?? -1,
        ApiPort = dto.ApiPort ?? -1,
        JobServer3Camadas = dto.JobServer3Camadas ?? false,
        DefaultDB = dto.DefaultDB ?? false,
        NormalizePath = dto.NormalizePath ?? false,
        EnableProcessIsolation = dto.EnableProcessIsolation ?? false,
        IsolateProcess = dto.IsolateProcess ?? false,
        EnableCompression = dto.EnableCompression ?? false
      };
    }
    public static AmbienteConfigDTO FromModel(AmbienteConfigModel model)
    {
      return new AmbienteConfigDTO
      {
        Id = model.Id,
        AmbienteId = model.AmbienteId,
        Host = model.Host,
        Port = model.Port,
        HttpPort = model.HttpPort,
        ApiPort = model.ApiPort,
        JobServer3Camadas = model.JobServer3Camadas,
        DefaultDB = model.DefaultDB,
        NormalizePath = model.NormalizePath,
        EnableProcessIsolation = model.EnableProcessIsolation,
        IsolateProcess = model.IsolateProcess,
        EnableCompression = model.EnableCompression
      };
    }
  }
}
