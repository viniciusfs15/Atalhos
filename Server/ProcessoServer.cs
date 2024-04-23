using System;
using System.Diagnostics;

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
      catch (System.ComponentModel.Win32Exception ex)
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
      catch (System.ComponentModel.Win32Exception ex)
      {
        return;
      }
    }
  }
}
