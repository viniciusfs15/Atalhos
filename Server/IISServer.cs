using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Web.Administration;


namespace Atalhos
{
  public class IISServer
  {
    public void AlterPathAplication(string newPath)
    {
      try
      {
        var serverManager = new ServerManager();
        var site = serverManager.Sites["Default Web Site"];

        foreach (var app in site.Applications)
        {
          if (app.Path.ToLower() == "/corpore.net")
          {
            app.VirtualDirectories["/"].PhysicalPath = Path.Combine(newPath, "Corpore.Net");
          }
          else if (app.Path.ToLower() == "/framehtml")
          {
            app.VirtualDirectories["/"].PhysicalPath = Path.Combine(newPath, "FrameHTML");
          }
        }

        serverManager.CommitChanges();
      }
      catch (Exception err)
      {
        throw new Exception("Erro ao alterar configurações do IIS", err);
      }
    }

    public void ReciclarAppPool()
    {
      try
      {
        var serverManager = new ServerManager();
        var site = serverManager.Sites["Default Web Site"];

        foreach (var app in site.Applications)
        {
          if (app.Path.ToLower() == "/corpore.net" || app.Path.ToLower() == "/framehtml")
          {
            var appPool = serverManager.ApplicationPools.FirstOrDefault(x => x.Name == app.ApplicationPoolName);
            if (appPool != null)
            {
              appPool.Recycle();
            }
          }            
        }          
      }
      catch (Exception err)
      {
        throw new Exception("Erro ao reciclar pool de aplicação", err);
      }
    }
  }
}
