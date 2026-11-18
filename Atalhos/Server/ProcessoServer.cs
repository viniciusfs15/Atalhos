using Atalhos.DTO;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Atalhos.Server
{
  public class ProcessoServer
  {
    public void Encerrar(string nomeProcesso)
    {
      foreach (var processo in Process.GetProcessesByName(nomeProcesso))
      {
        processo.Kill();
      }
    }

    public void Iniciar(string caminhoExe)
    {
      Process.Start(caminhoExe);
    }

    public void Iniciar(string caminhoExe, string argumentos)
    {
      Process.Start(caminhoExe, argumentos);
    }

    public void IniciarExplorer(string caminhoExe)
    {
      if (!Directory.Exists(caminhoExe))
      {
        Process.Start("explorer.exe", Directory.GetParent(caminhoExe).FullName);
        return;
      }
      Process.Start("explorer.exe", caminhoExe);
    }

    public void IniciarComoAdministrador(string caminhoExe)
    {
      ProcessStartInfo startInfo = new ProcessStartInfo();
      startInfo.UseShellExecute = true;
      startInfo.WorkingDirectory = Environment.CurrentDirectory;
      startInfo.FileName = caminhoExe;
      startInfo.Verb = "runas";
      try
      {
        Process p = Process.Start(startInfo);
      }
      catch
      {
        return;
      }
    }

    public void IniciarComoAdministrador(string caminhoExe, string argumentos)
    {
      ProcessStartInfo startInfo = new ProcessStartInfo();
      startInfo.UseShellExecute = true;
      startInfo.WorkingDirectory = Environment.CurrentDirectory;
      startInfo.FileName = caminhoExe;
      startInfo.Arguments = argumentos;
      startInfo.Verb = "runas";
      try
      {
        Process p = Process.Start(startInfo);
      }
      catch
      {
        return;
      }
    }

    public void IniciarExeEHost(AtalhoDTO rmExe, AtalhoDTO host, bool exeComArgumentos)
    {
      var hostCheck = new RMHostCheck(rmExe.Caminho);
      var check = hostCheck.CheckHostActivity();
      
      if (!check)
      {
        IniciarComoAdministrador(host.Caminho);

        var timeout = 15;
        for (int i = 0; i < timeout; i++)
        {
          if (hostCheck.CheckHostActivity())
          {
            break;
          }
          Thread.Sleep(1000);
        }
      }        

      if (exeComArgumentos)
        IniciarComoAdministrador(rmExe.Caminho, rmExe.Argumentos);
      else
        IniciarComoAdministrador(rmExe.Caminho);
    }

    public async Task IniciarExeEHostAsync(AtalhoDTO rmExe, AtalhoDTO host, bool exeComArgumentos)
    {
      var hostCheck = new RMHostCheck(rmExe.Caminho);
      var check = await hostCheck.CheckHostActivityAsync();
      
      if (!check)
      {
        IniciarComoAdministrador(host.Caminho);

        var timeout = 15;
        for (int i = 0; i < timeout; i++)
        {
          if (await hostCheck.CheckHostActivityAsync())
          {
            break;
          }
          await Task.Delay(1000);
        }
      }        

      if (exeComArgumentos)
        IniciarComoAdministrador(rmExe.Caminho, rmExe.Argumentos);
      else
        IniciarComoAdministrador(rmExe.Caminho);
    }
  }
}
