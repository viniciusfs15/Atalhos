using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atalhos.Models
{
  [Table("Aliases")]
  public class AliasModel : BaseModel
  {
    public Guid AmbienteId { get; set; }
    public string Nome { get; set; }
    public string Usuario { get; set; }
    public string Senha { get; set; }
    public string Servidor { get; set; }
    public string BaseName { get; set; }
    public bool RunService { get; set; }
    public bool JobServerEnabled { get; set; }
    public bool JobServerProcessPoolEnabled { get; set; }
    public bool JobServerLocalOnly { get; set; }
    public string Sgbd { get; set; }
    public string UsuarioDB { get; set; } = "SYSDBA";
    public string SenhaDB { get; set; } = "masterkey";
    public int JobServerMaxThreads { get; set; }
    public string DbType { get; set; }
    public string DbProvider { get; set; }
    public string DbServer { get; set; }
    public string DbName { get; set; }

    [ForeignKey("AmbienteId")]
    public virtual AmbienteModel Ambiente { get; set; }
  }
}
