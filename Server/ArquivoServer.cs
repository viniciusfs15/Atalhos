using System;
using System.IO;
using System.Linq;

namespace Atalhos.Server
{
  public class ArquivoServer
  {
    public void Apagar(string caminhoArquivo)
    {
      try
      {
				if (File.Exists(caminhoArquivo))
					File.Delete(caminhoArquivo);
			}
      catch (Exception)
      {

        throw;
      }      
    }

    public void ApagarVarios(string caminho, string prefixo)
    {
      var arquivos = new DirectoryInfo(caminho).EnumerateFiles().Where(x => x.Name.Contains(prefixo)).ToList();
      foreach (var arqv in arquivos)
      {
        File.Delete(arqv.FullName);
      }
    }

    internal bool ExisteDll(string caminho, string contem, string naoContem)
    {
      return new DirectoryInfo(caminho).EnumerateFiles().Where(x => x.Name.ToLower().Contains(contem.ToLower()) && x.Name.ToLower().Contains(".dll") && !x.Name.ToLower().Contains(naoContem.ToLower())).ToList().Count() > 0;
    }
  }
}
