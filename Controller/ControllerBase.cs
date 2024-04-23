namespace Atalhos
{
  public class ControllerBase
  {
    private ConfigServer _configServer;
    public ConfigServer ConfigServer
    {
      get
      {
        if (_configServer == null)
        {
          _configServer = new ConfigServer();
        }
        return _configServer;
      }
      set { _configServer = value; }
    }

    internal void SalvarAlias(AliasConfig aliasConfig)
    {
      ConfigServer.AddAliasConfig(aliasConfig);
    }
  }
}
