using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Atalhos.Server
{
  public class AmbienteServer
  {
    /// <summary>
    /// LerDiretorios
    /// </summary>
    /// <param name="caminhoDiretorio">Caminho do diretorio a ser mapeado</param>
    /// <example>c\RM\Legado</example>
    /// <returns></returns>
    public List<Ambiente> LerDiretorios(string caminhoDiretorio, List<Atalho> listaAtalhos)
    {
      List<Ambiente> ambientes = new List<Ambiente>();

      DirectoryInfo diretorio = new DirectoryInfo(caminhoDiretorio);
      var listDiretorio = diretorio.EnumerateDirectories();
      try
      {
        foreach (var pastaAmbiente in listDiretorio)
        {
          Ambiente ambiente = new Ambiente();
          ambiente.Nome = pastaAmbiente.Name;
          ambiente.FullName = pastaAmbiente.FullName;
          ambientes.Add(ambiente);
        }
        return ambientes;
      }
      catch (Exception err)
      {
        throw err;
      }
    }

    public void CarregarAtalhos(Dictionary<string, string> listaAtalhos, ref Ambiente ambiente)
    {
      var ambienteTemp = ambiente;
      ambienteTemp.Arquivos.Clear();
			foreach (var p in new DirectoryInfo(ambiente.FullName).EnumerateDirectories())
      {
        if (p.Name.ToUpper() == "BIN")
        {
          var itens = p.EnumerateFiles();
          foreach (var atalho in listaAtalhos)
          {
						itens.ToList().ForEach(delegate (FileInfo item)
						{
							if (item.Name.ToUpper().Trim() == atalho.Key.ToUpper().Trim())
							{
								ambienteTemp.Arquivos.Add(new Atalho(item.Name, item.FullName, atalho.Value));
							}
						});
					}
        }
      }
      ambiente.Arquivos = ambienteTemp.Arquivos;
    }

		public List<Atalho> CarregarAtalhos(Dictionary<string, string> listaAtalhos, string caminhoAmbiente)
		{
      var ambienteTemp = new Ambiente();
      ambienteTemp.FullName = caminhoAmbiente;
      CarregarAtalhos(listaAtalhos, ref ambienteTemp);

      return ambienteTemp.Arquivos;
		}
	}
}
