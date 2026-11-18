using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Atalhos.Server
{
  public class RMHostCheck
  {
    private string _hostName;
    private int _port;

    public RMHostCheck(string exePath)
    {
      var config = new RMConfig(exePath + ".config");
      _hostName = config.Host;
      _port = config.Port;
    }

    public bool CheckHostActivity()
    {
      var ok = false;
      using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
      {
        try
        {
          IAsyncResult asr = socket.BeginConnect(_hostName, _port, null, null);
          if (asr.AsyncWaitHandle.WaitOne(10000, true))
          {
            ok = socket.Connected;
          }
        }
        catch
        {
          ok = false;
        }
      }
      return ok;
    }

    public async Task<bool> CheckHostActivityAsync()
    {
      var ok = false;
      using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
      {
        try
        {
          var cts = new System.Threading.CancellationTokenSource(10000);
          await socket.ConnectAsync(_hostName, _port, cts.Token);
          ok = socket.Connected;
        }
        catch
        {
          ok = false;
        }
      }
      return ok;
    }
  }
}
