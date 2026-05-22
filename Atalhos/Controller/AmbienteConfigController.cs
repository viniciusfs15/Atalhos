using Atalhos.DTO;
using Atalhos.Server;

namespace Atalhos.Controller
{
  public class AmbienteConfigController
  {
    private AmbienteController _ambienteController { get; set; } = new AmbienteController();
    private AmbienteConfigServer _configServer { get; set; } = new AmbienteConfigServer();

    public AmbienteConfigDTO GetAmbiente(Guid ambienteId)
    {
      var ambiente = AmbienteDTO.FromModel(_ambienteController.GetById(ambienteId));
      if (ambiente == null)
        return null;

      return _configServer.GetAppSettings(ambiente.FullName);
    }

    public void SaveAmbienteConfig(AmbienteConfigDTO ambienteConfig)
    {
      _configServer.SaveConfigs(AmbienteConfigDTO.ToModel(ambienteConfig));
    }

    public void NormalizeAmbientePath(AmbienteConfigDTO ambienteConfig) 
    { 
      ambienteConfig.NormalizePath = true;
      _configServer.NormalizeAmbientePath(AmbienteConfigDTO.ToModel(ambienteConfig));
    }
  }
}
