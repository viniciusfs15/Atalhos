using Atalhos.DTO;
using Atalhos.Models;
using Atalhos.Properties;
using Atalhos.Repositories;
using System.IO;

namespace Atalhos.Server
{
  public class AmbienteConfigServer : DataServer<AmbienteConfigModel>
  {
    private List<string> _listConfigAll { get; set; } = new List<string>();
    private List<string> _listConfigHost { get; set; } = new List<string>();
    private List<string> _listConfigClient { get; set; } = new List<string>();
    private ConfigManager _configManager { get; set; } = new ConfigManager();
    private AmbienteServer _ambienteServer { get; set; } = new AmbienteServer();

    public AmbienteConfigServer() : base(new Repository<AmbienteConfigModel>(new DbContext.ApplicationDbContext()))
    {
      DefineListConfig();
    }

    private void DefineListConfig()
    {
      _listConfigHost = new List<string>() {
        "RM.Host.Service.exe.config",
        "RM.Host.JobRunner.exe.config",
        "RM.Host.exe.config"
      };

      _listConfigClient = new List<string>()
      {
        "RM.TotvsSQLTools.exe.config",
        "RM.TotvsAudit.exe.config",
        "RM.Script.Executor.exe.config",
        "RM.Lib.TestExecutor.exe.config",
        "RM.Lib.Gerador.Execute.exe.config",
        "RM.exe.config",
        "RM.DescaracterizadorBaseDados.exe.config",
        "RM.Atualizador.LogViewer.exe.config",
        "RM.Atualizador.exe.config",
        "RM.AliasManager.exe.config"
      };

      _listConfigAll = _listConfigHost.Union(_listConfigClient).ToList();
    }

    public void SaveConfigs(AmbienteConfigModel ambienteConfig)
    {
      foreach (var hostConfig in _listConfigHost)
      {
        UpdateSettingsHost(ambienteConfig, hostConfig);
      }
      foreach (var clientConfig in _listConfigClient)
      {
        UpdateSettingsClient(ambienteConfig, clientConfig);
      }
    }

    public AmbienteConfigDTO GetAppSettings(string ambientePath)
    {
      var binPath = Path.Combine(ambientePath, "Bin");
      var hostConfigPath = Path.Combine(binPath, "RM.Host.exe.config");
      if (!File.Exists(hostConfigPath)) throw new FileNotFoundException($"Config file not found: {hostConfigPath}");
      var appSettings = _configManager.GetAppSettings(new List<string>()
      {
        "JobServer3Camadas",
        "Host",
        "Port",
        "HttpPort",
        "ApiPort",
        "ActionsPath",
        "LibPath",
        "EnableCompression",
        "EnableProcessIsolation",
        "IsolateProcess",
        "DefaultDB"
      }, hostConfigPath);

      var actionsPath = appSettings.GetValueOrDefault("ActionsPath");
      var libPath = appSettings.GetValueOrDefault("LibPath");
      var normalizePath = false;
      if(actionsPath != $"{binPath};{Path.Combine(ambientePath, "Corpore.Net", "Bin")}"
        || libPath != binPath)
      {
        normalizePath = true;
      }

      var boolDefaultDb = false;
      var defaultDbValue = appSettings.GetValueOrDefault(nameof(AmbienteConfigModel.DefaultDB));
      if(!string.IsNullOrWhiteSpace(defaultDbValue) && defaultDbValue == "CorporeRM")
      {
        boolDefaultDb = true;
      }

      var enableProcessIsolation = false;
      var enableProcessIsolationValue = appSettings.GetValueOrDefault(nameof(AmbienteConfigModel.EnableProcessIsolation));
      var isolateProcessesValue = appSettings.GetValueOrDefault(nameof(AmbienteConfigModel.IsolateProcess));
      if (!string.IsNullOrWhiteSpace(enableProcessIsolationValue) && !string.IsNullOrWhiteSpace(isolateProcessesValue))
      {
        enableProcessIsolation = true;
      }

      var ambienteConfig = new AmbienteConfigModel
      {
        Host = appSettings.GetValueOrDefault(nameof(AmbienteConfigModel.Host)),
        Port = int.TryParse(appSettings.GetValueOrDefault(nameof(AmbienteConfigModel.Port)), out int port) ? port : default,
        HttpPort = int.TryParse(appSettings.GetValueOrDefault(nameof(AmbienteConfigModel.HttpPort)), out int httpPort) ? httpPort : default,
        ApiPort = int.TryParse(appSettings.GetValueOrDefault(nameof(AmbienteConfigModel.ApiPort)), out int apiPort) ? apiPort : default,
        JobServer3Camadas = bool.TryParse(appSettings.GetValueOrDefault(nameof(AmbienteConfigModel.JobServer3Camadas)), out bool jobServer3Camadas) ? jobServer3Camadas : default,
        DefaultDB = boolDefaultDb,
        NormalizePath = normalizePath,
        EnableProcessIsolation = enableProcessIsolation,
        IsolateProcess = bool.TryParse(appSettings.GetValueOrDefault(nameof(AmbienteConfigModel.IsolateProcess)), out bool isolateProcess) ? isolateProcess : default,
        EnableCompression = bool.TryParse(appSettings.GetValueOrDefault(nameof(AmbienteConfigModel.EnableCompression)), out bool enableCompression) ? enableCompression : default
      };
      return AmbienteConfigDTO.FromModel(ambienteConfig);
    }

    private void UpdateSettingsHost(AmbienteConfigModel model, string fileName)
    {
      var ambiente = GetAmbiente(model.AmbienteId);
      var filePath = Path.Combine(ambiente.Bin, fileName);
      List<string> settingsToRemove = new List<string>();
      Dictionary<string, string> settingsToUpdate = GetBasicSettings(model);

      if (model.DefaultDB) 
        settingsToUpdate.Add(nameof(model.DefaultDB), "CorporeRM");
      else settingsToRemove.Add(nameof(model.DefaultDB));

      if (model.HttpPort > 0) settingsToUpdate.Add(nameof(model.HttpPort), model.HttpPort.ToString());
      if (model.ApiPort > 0) settingsToUpdate.Add(nameof(model.ApiPort), model.ApiPort.ToString());
            
      SettingsProcessIsolation(model, settingsToRemove, settingsToUpdate);

      _configManager.UpdateAppSetting(settingsToUpdate, filePath);
      _configManager.RemoveAppSetting(settingsToRemove, filePath);
      //TODO: Salvar alterações no banco de dados UpdateAsync(model).GetAwaiter().GetResult();
    }

    private void UpdateSettingsClient(AmbienteConfigModel model, string fileName)
    {
      var ambiente = GetAmbiente(model.AmbienteId);
      var filePath = Path.Combine(ambiente.Bin, fileName);
      List<string> settingsToRemove = new List<string>();
      Dictionary<string, string> settingsToUpdate = GetBasicSettings(model);
      SettingsNormalizePaths(model, ambiente, settingsToUpdate);

      _configManager.UpdateAppSetting(settingsToUpdate, filePath);
      _configManager.RemoveAppSetting(settingsToRemove, filePath);
      //TODO: Salvar alterações no banco de dados UpdateAsync(model).GetAwaiter().GetResult();
    }

    private static void SettingsProcessIsolation(AmbienteConfigModel model, List<string> settingsToRemove, Dictionary<string, string> settingsToUpdate)
    {
      if (model.EnableProcessIsolation)
      {
        settingsToUpdate.Add(nameof(model.EnableProcessIsolation), "false");
        settingsToUpdate.Add(nameof(model.IsolateProcess), "false");
      }
      else
      {
        settingsToRemove.Add(nameof(model.EnableProcessIsolation).ToUpper());
        settingsToRemove.Add(nameof(model.IsolateProcess));
      }
    }

    private static Dictionary<string, string> GetBasicSettings(AmbienteConfigModel model)
    {
      var settings = new Dictionary<string, string>
      {
        { nameof(model.JobServer3Camadas), model.JobServer3Camadas.ToString().ToLower() },
        { nameof(model.Host), model.Host },
        { nameof(model.Port), model.Port.ToString() },
        { nameof(model.EnableCompression), model.EnableCompression.ToString().ToLower() },
      };
      return settings;
    }

    private static void SettingsNormalizePaths(AmbienteConfigModel model, AmbienteDTO ambiente, Dictionary<string, string> settingsToUpdate)
    {
      if (model.NormalizePath)
      {
        var actionsPath = $"{ambiente.Bin};{Path.Combine(ambiente.FullName, "Corpore.Net", "Bin")}";
        settingsToUpdate.Add("ActionsPath", actionsPath);
        settingsToUpdate.Add("LibPath", ambiente.Bin);
      }
    }

    private AmbienteDTO GetAmbiente(Guid ambienteId)
    {
      return AmbienteDTO.FromModel(_ambienteServer.GetByIdAsync(ambienteId).GetAwaiter().GetResult());
    }

    internal void NormalizeAmbientePath(AmbienteConfigModel model)
    {
      var ambiente = GetAmbiente(model.AmbienteId);
      foreach (var fileName in _listConfigAll)
      {
        var filePath = Path.Combine(ambiente.Bin, fileName);
        Dictionary<string, string> settingsToUpdate = new Dictionary<string, string>();
        SettingsNormalizePaths(model, ambiente, settingsToUpdate);
        _configManager.UpdateAppSetting(settingsToUpdate, filePath);
      }        
    }
  }
}
