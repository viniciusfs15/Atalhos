using System.ComponentModel.DataAnnotations.Schema;

namespace Atalhos.Models
{
  [Table("Ambientes")]
  public class AmbienteModel : BaseModel
  {
    public string Nome { get; set; }
    public string FullName { get; set; }
    public string Unidade { get; set; }
    public bool ControlaIIS { get; set; }
    public bool Favorito { get; set; }
    public bool AutoLogin { get; set; }
  }
}
