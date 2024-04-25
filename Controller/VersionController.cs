using Atalhos.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atalhos.Controllers
{
  public class VersionController
  {
    public bool IsLastVersion()
    {
      VersionServer server = new VersionServer();
      return server.IsLastVersion();
    }
  }
}
