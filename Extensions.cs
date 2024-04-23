using System.IO;

namespace Atalhos
{
  public static class Extensions
  {
    public static string CaminhoBin(this string caminho)
    {
      return Path.Combine(caminho, "bin");
    }
  }
}
