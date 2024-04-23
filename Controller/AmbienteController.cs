using Atalhos.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atalhos
{
  public class AmbienteController
  {
		#region [- SERVERS -]
		private AmbienteServer AmbienteServer 
    { get 
      { 
        if (_ambienteServer == null)
          _ambienteServer = new AmbienteServer();
        return _ambienteServer;
      }
      set 
      {
        _ambienteServer = new AmbienteServer();
      } 
    }
    private AmbienteServer _ambienteServer { get; set; }

    private ProcessoServer ProcessoServer 
    { 
      get 
      {
        if(_processoServer == null)
          _processoServer = new ProcessoServer();
        return _processoServer;
      }
      set 
      { 
        _processoServer = new ProcessoServer();
      }
    }
    private ProcessoServer _processoServer { get; set; }

    private ArquivoServer _arquivoServer;
    public ArquivoServer ArquivoServer
    {
      get
      {
        if (_arquivoServer == null)
        {
          _arquivoServer = new ArquivoServer();
        }
        return _arquivoServer; 
      }
      set { _arquivoServer = value; }
    }
		#endregion

		public List<Ambiente> LerAmbientes(string caminho, List<Atalho> atalhos)
    {
      return AmbienteServer.LerDiretorios(caminho, atalhos);
    }

    public void EncerrarProcesso()
    {
      List<string> listProcessos = new List<string>() { "RM", "RM.Host", "RM.Host.JobRunner" };

      foreach (string processo in listProcessos)
      {
        ProcessoServer.Encerrar(processo);
      }      
    }

    public void ApagarBrokers(string caminhoAmbiente)
    {
      ApagarBroker(caminhoAmbiente);
      ApagarBrokerCustom(caminhoAmbiente);
    }

    public void ApagarBroker(string caminhoAmbiente)
    {
      var caminho = Path.Combine(caminhoAmbiente, "_Broker.dat");
      ArquivoServer.Apagar(caminho);
    }

    public void ApagarBrokerCustom(string caminhoAmbiente)
    {
      var caminho = Path.Combine(caminhoAmbiente, "_BrokerCustom.dat");
      ArquivoServer.Apagar(caminho);
    }

    public void ApagarDllCustom(string caminhoAmbiente)
    {
      ArquivoServer.ApagarVarios(caminhoAmbiente, "RM.Cst.");
    }

    public bool ValidaDllCustomBin(string caminhoAmbiente)
    {
      return ArquivoServer.ExisteDll(caminhoAmbiente, "RM.Cst.", "TesteUnitario");
    }

    public bool ValidaDllProdutoCustom(string caminhoAmbiente)
    {
      return ArquivoServer.ExisteDll(caminhoAmbiente, string.Empty, "RM.Cst.");
    }

    public void IniciarApp(Atalho atalho)
    {
      ProcessoServer.Iniciar(atalho.Caminho);
    }

    public void IniciarAppComArgumentos(Atalho atalho)
		{
			ProcessoServer.Iniciar(atalho.Caminho, atalho.Argumentos);
		}

    public void IniciarAppComoAdminComArgumentos(Atalho atalho)
    {
      ProcessoServer.IniciarComoAdministrador(atalho.Caminho, atalho.Argumentos);
    }

    public void IniciarAppComoAdmin(Atalho atalho)
    {
      ProcessoServer.IniciarComoAdministrador(atalho.Caminho);
    }

    public void IniciarAppComPrivilegios(Atalho atalho)
    {
      ProcessoServer.IniciarComoAdministrador(atalho.Caminho, atalho.Argumentos);
    }

    public void IniciarAppComPrivilegiosSemArgumentos(Atalho atalho)
    {
      ProcessoServer.IniciarComoAdministrador(atalho.Caminho);
    }

    public void CarregarAtalhos(Dictionary<string, string> listAtalhos,ref Ambiente ambiente)
    {
      AmbienteServer.CarregarAtalhos(listAtalhos, ref ambiente);
    }

		public void IniciarAmbiente(Ambiente ambiente, bool apagaBrokerCustom)
		{
      if(apagaBrokerCustom)
			  ApagarBrokerCustom(ambiente.FullName);
        ApagarDllCustom(ambiente.Bin);

      Task task = Task.Run(() => IniciarRmEHost(ambiente));
		}

		private void IniciarRmEHost(Ambiente ambiente)
		{
			Atalho rmExe = ambiente.Arquivos.Find(x => x.Nome == "RM.exe");
			Atalho host = ambiente.Arquivos.Find(x => x.Nome == "RM.Host.exe");

			IniciarAppComPrivilegios(host);

      Thread.Sleep(7000);

      //TODO: var hostIniciado = VerificarSeProcessoEstaEmExecucao("RM.Host");

      IniciarAppComPrivilegios(rmExe);
		}

    public IEnumerable<AliasConfig> LerAlias(Ambiente ambiente)
    {
      var server = new ConfigServer();
      return server.GetAliasByVersao(ambiente.Nome);
    }

    internal void CreateAlias(string fullName, AliasConfig alias)
    {
      var server = new LeitorAliasServer(fullName);
      server.CreateAliasDat(alias);
    }

    internal string ObterLog(Ambiente ambienteAtual)
    {
      var log = new StringBuilder();
      if (ValidaDllCustomBin(ambienteAtual.Bin))
        log.AppendLine("Foram encontradas Dlls com o prefixo \"RM.Cst.\" na pasta bin;");

      if (ValidaDllProdutoCustom(ambienteAtual.Custom))
        log.AppendLine("Foram encontradas Dlls que não tem o prefixo \"RM.Cst.\" na pasta Custom;");

      return log.ToString();
    }
  }
}

