using Atalhos.Models;
using System.IO;

namespace Atalhos.DTO
{
  public class AmbienteDTO
  {
    public Guid Id { get; set; }
    public string Nome { get; internal set; }
    public string FullName { get; internal set; } = string.Empty;
    public string TipoAmbiente { get; set; } = StringConstantes.TipoPadrao;
    public bool EhSmartClient => TipoAmbiente == StringConstantes.TipoSmartClient;
    public bool EhInstalado => TipoAmbiente == StringConstantes.TipoInstalado;
    public string Bin => GetPastaBinarios();
    public string Custom => Path.Combine(Bin, StringConstantes.Custom);
    public string FrameHTML => Path.Combine(FullName, StringConstantes.FrameHTML);
    public string CorporeNet => Path.Combine(FullName, StringConstantes.CorporeNet);
    public string Unidade { get; internal set; } = string.Empty;
    public bool ControlaIIS { get; set; }
    public bool Favorito { get; set; }
    public bool AutoLogin { get; internal set; }

    public List<AtalhoDTO> Arquivos = new List<AtalhoDTO>();

    private string GetPastaBinarios()
    {
      if (EhSmartClient)
        return FullName;
      if (EhInstalado)
        return Path.Combine(FullName, StringConstantes.RM_Net);
      return Path.Combine(FullName, StringConstantes.Bin);
    }

    public static AmbienteModel ToModel(AmbienteDTO dto)
    {
      if (dto == null) return null;
      return new AmbienteModel
      {
        Id = dto.Id,
        Nome = dto.Nome,
        FullName = dto.FullName,
        Unidade = dto.Unidade,
        ControlaIIS = dto.ControlaIIS,
        Favorito = dto.Favorito,
        AutoLogin = dto.AutoLogin
      };
    }

    public static AmbienteDTO FromModel(AmbienteModel model)
    {
      if (model == null) return null;
      return new AmbienteDTO
      {
        Id = model.Id,
        Nome = model.Nome,
        FullName = model.FullName,
        Unidade = model.Unidade,
        ControlaIIS = model.ControlaIIS,
        Favorito = model.Favorito,
        AutoLogin = model.AutoLogin
      };
    }
  }
}
