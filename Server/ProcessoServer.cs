using System;
using System.Diagnostics;
using System.Threading;

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

    //inicia processo como administrador
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

    //inicia processo como administrador com argumentos
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

    public void IniciarExeEHost(Atalho rmExe, Atalho host, bool exeComArgumentos)
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
  }
}
