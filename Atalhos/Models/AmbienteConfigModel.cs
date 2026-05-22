using System.ComponentModel.DataAnnotations.Schema;

namespace Atalhos.Models
{
  [Table("AmbienteConfig")]
  public class AmbienteConfigModel : BaseModel
  {
    public Guid AmbienteId { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }
    public int HttpPort { get; set; }
    public int ApiPort { get; set; }
    public bool JobServer3Camadas { get; set; }
    public bool DefaultDB { get; set; }
    public bool NormalizePath { get; set; }
    public bool EnableProcessIsolation { get; set; }
    public bool IsolateProcess { get; set; }
    public bool EnableCompression { get; set; }

    [ForeignKey("AmbienteId")]
    public virtual AmbienteModel Ambiente { get; set; }
  }
}
