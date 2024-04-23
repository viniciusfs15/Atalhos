using System.Xml.Serialization;
using System.Xml;

public class DbConfig
{
  [XmlElement("Alias")]
  public string Alias { get; set; }

  [XmlElement("DbType")]
  public string DbType { get; set; }

  [XmlElement("DbProvider")]
  public string DbProvider { get; set; }

  [XmlElement("DbServer")]
  public string DbServer { get; set; }

  [XmlElement("DbName")]
  public string DbName { get; set; }

  [XmlElement("UserName")]
  public string UserName { get; set; }

  [XmlElement("Password")]
  public string Password { get; set; }

  [XmlElement("RunService")]
  public bool RunService { get; set; }

  [XmlElement("JobServerEnabled")]
  public bool JobServerEnabled { get; set; }

  [XmlElement("JobServerMaxThreads")]
  public int JobServerMaxThreads { get; set; }

  [XmlElement("JobServerLocalOnly")]
  public bool JobServerLocalOnly { get; set; }

  [XmlElement("JobServerPollingInterval")]
  public int JobServerPollingInterval { get; set; }

  [XmlElement("ChartAlertEnabled")]
  public bool ChartAlertEnabled { get; set; }

  [XmlElement("ChartAlertPollingInterval")]
  public int ChartAlertPollingInterval { get; set; }

  [XmlElement("ChartHistoryEnabled")]
  public bool ChartHistoryEnabled { get; set; }

  [XmlElement("ChartHistoryPollingInterval")]
  public int ChartHistoryPollingInterval { get; set; }

  [XmlElement("RSSReaderMailEnabled")]
  public bool RSSReaderMailEnabled { get; set; }

  [XmlElement("RSSReaderMailPollingInterval")]
  public int RSSReaderMailPollingInterval { get; set; }

  [XmlElement("JobServerProcessPoolEnabled")]
  public bool JobServerProcessPoolEnabled { get; set; }
}
