using Atalhos.Server;
using System.Text;
using Atalhos.DTO;
using Atalhos.Models;
using System.IO;

namespace Atalhos.Controller
{
  public class AmbienteController
  {
    #region [- SERVERS -]
    private AmbienteServer _ambienteServer = new AmbienteServer();
    private AmbienteIOServer _ambienteIOServer = new AmbienteIOServer();

    private ProcessoServer ProcessoServer
    {
      get
      {
        if (_processoServer == null)
          _processoServer = new ProcessoServer();
        return _processoServer;
      }
      set
      {
        _processoServer = new ProcessoServer();
      }
    }
    private ProcessoServer _processoServer { get; set; }

    public AtalhosIOServer ArquivoServer
    {
      get
      {
        if (_arquivoServer == null)
        {
          _arquivoServer = new AtalhosIOServer();
        }
        return _arquivoServer;
      }
      set { _arquivoServer = value; }
    }
    private AtalhosIOServer _arquivoServer;

    private AliasController _aliasController { get; set; } = new AliasController();

    private IISServer IIsServer
    {
      get
      {
        if (_xmlServer == null)
          _xmlServer = new IISServer();
        return _xmlServer;
      }
      set { _xmlServer = value; }
    }
    private IISServer _xmlServer;
    #endregion

    public List<AmbienteDTO> LerAmbientes(List<AtalhoDTO> atalhos)
    {
      var ambientesIO = _ambienteIOServer.ListarAmbientes(atalhos);
      foreach (var ambiente in ambientesIO)
      {
        _ambienteServer.GetByNameAsync(ambiente.Nome).ContinueWith(task =>
        {
          if (task.Result != null)
          {
            ambiente.Favorito = task.Result.Favorito;
            ambiente.AutoLogin = task.Result.AutoLogin;
            ambiente.ControlaIIS = task.Result.ControlaIIS;
          }
          else
          {
            _ambienteServer.AddAsync(AmbienteDTO.ToModel(ambiente)).Wait();
          }
        }).Wait();
      }

      return ambientesIO;
    }

    public void EncerrarProcesso()
    {
      List<string> listProcessos = new List<string>() { "RM", "RM.Host", "RM.Host.JobRunner" };

      foreach (string processo in listProcessos)
      {
        ProcessoServer.Encerrar(processo);
      }
    }

    public void EncerrarProcesso(string nomeApp)
    {
      ProcessoServer.Encerrar(nomeApp);
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

    public void IniciarApp(string nomeApp)
    {
      ProcessoServer.Iniciar(nomeApp);
    }

    public void IniciarAppComArgumentos(AtalhoDTO atalho)
    {
      ProcessoServer.Iniciar(atalho.Caminho, atalho.Argumentos);
    }

    public void IniciarExplorer(string caminho)
    {
      ProcessoServer.IniciarExplorer(caminho);
    }

    public void IniciarAppComPrivilegios(AtalhoDTO atalho)
    {
      ProcessoServer.IniciarComoAdministrador(atalho.Caminho, atalho.Argumentos);
    }

    public void IniciarAmbiente(AmbienteDTO ambiente, bool exeComArgumentos, bool apagaBrokerCustom, bool apagarBroker)
    {
      if (apagaBrokerCustom)
        ApagarBrokerCustom(ambiente.Bin);

      if (apagarBroker)
        ApagarBroker(ambiente.Bin);

      Task task = Task.Run(() => IniciarRmEHost(ambiente, exeComArgumentos));
    }

    private void IniciarRmEHost(AmbienteDTO ambiente, bool exeComArgumentos)
    {
      ProcessoServer.IniciarExeEHost(ambiente.Arquivos.Find(x => x.Nome == "RM.exe"), ambiente.Arquivos.Find(x => x.Nome == "RM.Host.exe"), exeComArgumentos);
    }

    internal string ObterLog(AmbienteDTO ambienteAtual)
    {
      var log = new StringBuilder();
      if (ValidaDllCustomBin(ambienteAtual.Bin))
        log.AppendLine("Foram encontradas Dlls com o prefixo \"RM.Cst.\" na pasta bin;");

      if (ValidaDllProdutoCustom(ambienteAtual.Custom))
        log.AppendLine("Foram encontradas Dlls que não tem o prefixo \"RM.Cst.\" na pasta Custom;");

      return log.ToString();
    }

    internal void ResetarIIS(AmbienteDTO ambienteAtual, bool? alterPath)
    {
      if (alterPath != null && alterPath == true)
        AlterIisPath(ambienteAtual);

      ProcessoServer.IniciarComoAdministrador("iisreset.exe");
    }

    internal void AlterIisPath(AmbienteDTO ambienteAtual)
    {
      IIsServer.AlterPathAplication(ambienteAtual.FullName);
    }

    internal void ReciclarAppPool()
    {
      IIsServer.ReciclarAppPool();
    }

    public Dictionary<string, string> GetNomesAtalhos(List<AliasConfigDTO> aliases, string nomeAmbiente, string nomeAlias)
    {
      var ambienteAtual = _ambienteServer.GetByNameAsync(nomeAmbiente).Result;
      string atributosRmexe = "multi=true alias=CorporeRM user=mestre password=totvs #objetos_gerenciais";
      if (ambienteAtual != null)
      {
        var alias = aliases.ToList().Where(x => x.NomeAlias == nomeAlias).FirstOrDefault();
        if (alias != null)
          atributosRmexe = $"multi=true alias=CorporeRM user={alias.UsuarioRM} password={alias.SenhaRM} #objetos_gerenciais";
      }

      var dictionary = new Dictionary<string, string>
      {
        { StringConstantes.RM_Exe, atributosRmexe },
        { StringConstantes.RM_AliasManager, "" },
        { StringConstantes.RM_Atualizador, "" },
        { StringConstantes.RM_Exe_Config, "" },
        { StringConstantes.RM_Host_Exe_Config, "" },
        { StringConstantes.RM_Host_Exe, "" }
      };
      return dictionary;
    }

    public List<AtalhoDTO> GetListAtalhos(List<AliasConfigDTO> aliases, string nomeAmbiente, string nomeAlias)
    {
      var ambienteAtual = _ambienteServer.GetByNameAsync(nomeAmbiente).Result;
      if (ambienteAtual == null) return new List<AtalhoDTO>();
      var alias = aliases.ToList().Where(x => x.Versao == ambienteAtual.Nome && x.NomeAlias == nomeAlias).FirstOrDefault();
      var nomesAtalhos = GetNomesAtalhos(aliases, nomeAmbiente, nomeAlias);
      var pastaPadrao = ambienteAtual.FullName.Contains("CorporeRM") ? "RM.Net" : "Bin";
      var listaAtalhos = new List<AtalhoDTO>();

      if (nomesAtalhos == null)
        return null;

      foreach (var nome in nomesAtalhos)
      {
        var caminho = Path.Combine(ambienteAtual.FullName, pastaPadrao, nome.Key);
        listaAtalhos.Add(new AtalhoDTO(nome.Key, caminho, nome.Value));
      }
      return listaAtalhos;
    }

    internal void SaveAmbiente(AmbienteDTO ambienteAtual)
    {
      if (ambienteAtual == null) return;
      var ambienteModel = AmbienteDTO.ToModel(ambienteAtual);
      var ambiente = _ambienteServer.GetByNameAsync(ambienteAtual.Nome).Result;
      if (ambiente == null)
      {
        _ambienteServer.AddAsync(ambienteModel).GetAwaiter().GetResult();
      }
      UpdateAmbiente(ambienteModel);
    }

    private void UpdateAmbiente(AmbienteModel ambienteAtual)
    {
      if (ambienteAtual == null) return;
      var ambiente = _ambienteServer.GetByNameAsync(ambienteAtual.Nome).Result;
      if (ambiente == null) return;
      ambienteAtual.Id = ambiente.Id;

      if (ambienteAtual.Favorito)
      {
        var ambientes = _ambienteServer.GetAllAsync().Result.Where(x => x.Id != ambienteAtual.Id);
        foreach (var item in ambientes)
        {
          item.Favorito = false;
          _ambienteServer.UpdateAsync(item).GetAwaiter().GetResult();
        }
      }

      _ambienteServer.UpdateAsync(ambienteAtual).GetAwaiter().GetResult();
    }

    internal AmbienteModel? GetById(Guid ambienteId)
    {
      return _ambienteServer.GetByIdAsync(ambienteId).GetAwaiter().GetResult();
    }

    public AmbienteDTO GetAmbiente(string nomeAmbiente)
    {
      var ambiente = _ambienteServer.GetByNameAsync(nomeAmbiente).Result;
      if (ambiente == null) return null;
      return AmbienteDTO.FromModel(ambiente);
    }
  }
}

