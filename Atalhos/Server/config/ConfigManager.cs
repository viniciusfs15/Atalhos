using System.Xml.Linq;

namespace Atalhos
{
  /// <summary>
  /// Gerenciador de configurações para arquivos XML baseados em appSettings.
  /// </summary>
  public class ConfigManager
  {
    /// <summary>
    /// Atualiza ou insere múltiplas chaves e valores na seção appSettings.
    /// </summary>
    /// <param name="settings">Settings</param>
    /// <param name="filePath">O caminho do arquivo de configuração.</param>
    public void UpdateAppSetting(Dictionary<string, string> settings, string filePath)
    {
      try
      {
        XDocument doc = XDocument.Load(filePath);//, LoadOptions.PreserveWhitespace);
        XElement appSettings = doc.Root?.Element("appSettings");
        if (appSettings == null)
        {
          return; // Se a seção appSettings não existir, não há nada a atualizar
        }
        foreach (var kvp in settings)
        {
          string key = kvp.Key;
          string newValue = kvp.Value;
          XElement setting = appSettings.Elements("add")
              .FirstOrDefault(x => x.Attribute("key")?.Value.ToUpper() == key.ToUpper());
          if (setting != null)
          {
            setting.SetAttributeValue("value", newValue);
          }
          else
          {
            appSettings.Add(new XElement("add",
                new XAttribute("key", key),
                new XAttribute("value", newValue)));
          }
        }
        doc.Save(filePath);
      }
      catch (Exception ex)
      {
        throw new InvalidOperationException($"Falha ao atualizar as chaves no arquivo {filePath}.", ex);
      }
    }

    public void RemoveAppSetting(List<string> settings, string filePath)
    {
      try
      {
        XDocument doc = XDocument.Load(filePath);//, LoadOptions.PreserveWhitespace);
        XElement appSettings = doc.Root?.Element("appSettings");
        if (appSettings == null)
        {
          return; // Se a seção appSettings não existir, não há nada a remover
        }

        foreach (var key in settings)
        {
          XElement setting = appSettings.Elements("add")
            .FirstOrDefault(x => x.Attribute("key")?.Value.ToUpper() == key.ToUpper());
          if (setting != null)
          {
            setting.Remove();
          }
        }
        doc.Save(filePath);
      }
      catch (Exception)
      {
        throw;
      }
    }

    /// <summary>
    /// Recupera o valor de uma chave específica.
    /// </summary>
    public string GetAppSetting(string key, string filePath)
    {
      XDocument doc = XDocument.Load(filePath);
      return doc.Root?.Element("appSettings")?.Elements("add")
          .FirstOrDefault(x => x.Attribute("key")?.Value == key)
          ?.Attribute("value")?.Value;
    }

    public Dictionary<string, string> GetAppSettings(List<string> keys, string filePath)
    {
      XDocument doc = XDocument.Load(filePath);
      var appSettings = doc.Root?.Element("appSettings")?.Elements("add");
      if (appSettings == null) return new Dictionary<string, string>();
      return appSettings
          .Where(x => keys.Contains(x.Attribute("key")?.Value))
          .ToDictionary(
              x => x.Attribute("key")?.Value ?? string.Empty,
              x => x.Attribute("value")?.Value ?? string.Empty);
    }
  }
}
