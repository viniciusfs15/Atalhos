using Atalhos.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atalhos
{
  public class ConfigController
  {
    #region [- SERVERS -]

    private ConfigServer ConfigServer
    {
      get
      {
        if (_configServer == null)
          _configServer = new ConfigServer();
        return _configServer;
      }
      set
      {
        _configServer = new ConfigServer();
      }
    }
    private ConfigServer _configServer { get; set; }

    #endregion [- SERVERS -]

    public void ControlarIIS(Ambiente ambienteAtual, bool? isChecked)
    {
      ambienteAtual.ControlaIIS = isChecked ?? false;
      ConfigServer.UpdateAmbienteConfig(ambienteAtual);
    }
  }
}
