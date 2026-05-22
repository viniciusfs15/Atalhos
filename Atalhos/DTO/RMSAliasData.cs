using System.Xml.Serialization;
using System.Xml;
using System.Collections;
using System.Collections.Generic;

[XmlRoot("RMSAliasData", Namespace = "http://tempuri.org/RMSAliasData.xsd")]
public class RMSAliasData
{
  [XmlElement("DbConfig")]
  public List<DbConfig> DbConfig { get; set; }
}
