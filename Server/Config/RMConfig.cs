using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Atalhos.Server
{
  public class RMConfig
  {
    public RMConfig() { }

    private string Read(string path)
    {
      return File.ReadAllText(path);
    }

    public int Port { get; set; }
    public string Host { get; set; }

    /// <summary>
    /// Converte a string XML para uma instância de RMConfig.
    /// </summary>
    /// <param name="xmlContent">Conteúdo do arquivo de configuração</param>
    /// <returns>Instância de AppConfig preenchida</returns>
    public RMConfig(string path)
    {
      var xmlContent = Read(path);
      try
      {
        var doc = XDocument.Parse(xmlContent);

        var settings = doc.Descendants("appSettings").Elements("add");

        var portValue = settings
            .FirstOrDefault(x => (string)x.Attribute("key") == "Port")?
            .Attribute("value")?.Value;

        var hostValue = settings
            .FirstOrDefault(x => (string)x.Attribute("key") == "Host")?
            .Attribute("value")?.Value;

        Port = int.TryParse(portValue, out int p) ? p : 0;
        Host = hostValue ?? "localhost";
      }
      catch (Exception ex)
      {
        throw new InvalidOperationException("Falha ao processar o XML de configuração.", ex);
      }
    }
  }
}
