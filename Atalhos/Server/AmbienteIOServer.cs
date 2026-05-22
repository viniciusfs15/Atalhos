using Atalhos.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Atalhos.Server
{
  public class AmbienteIOServer
  {
    /// <summary>
    /// LerDiretorios
    /// </summary>
    /// <param name="caminhoDiretorio">Caminho do diretorio a ser mapeado</param>
    /// <example>c\RM\Legado</example>
    /// <returns></returns>
    public List<AmbienteDTO> LerDiretorios(string caminhoDiretorio, List<AtalhoDTO> listaAtalhos)
    {
      List<AmbienteDTO> ambientes = new List<AmbienteDTO>();

      DirectoryInfo diretorio = new DirectoryInfo(caminhoDiretorio);
      if (!diretorio.Exists)
        return ambientes;
      var listDiretorio = diretorio.EnumerateDirectories();
      try
      {
        foreach (var pastaAmbiente in listDiretorio)
        {
          AmbienteDTO ambiente = new AmbienteDTO();
          ambiente.Nome = pastaAmbiente.Name;
          ambiente.FullName = pastaAmbiente.FullName;
          ambiente.Unidade = pastaAmbiente.Root.Name;
          ambientes.Add(ambiente);
        }
        return ambientes;
      }
      catch (Exception err)
      {
        throw err;
      }
    }

    public void CarregarAtalhos(Dictionary<string, string> listaAtalhos, ref AmbienteDTO ambiente)
    {
      var ambienteTemp = ambiente;
      ambienteTemp.Arquivos.Clear();
			foreach (var p in new DirectoryInfo(ambiente.FullName).EnumerateDirectories())
      {
        if (p.Name.ToUpper() == StringConstantes.Bin.ToUpper())
        {
          var itens = p.EnumerateFiles();
          foreach (var atalho in listaAtalhos)
          {
						itens.ToList().ForEach(delegate (FileInfo item)
						{
							if (item.Name.ToUpper().Trim() == atalho.Key.ToUpper().Trim())
							{
								ambienteTemp.Arquivos.Add(new AtalhoDTO(item.Name, item.FullName, atalho.Value));
							}
						});
					}
        }
      }
      ambiente.Arquivos = ambienteTemp.Arquivos;
    }

		public List<AtalhoDTO> CarregarAtalhos(Dictionary<string, string> listaAtalhos, string caminhoAmbiente)
		{
      var ambienteTemp = new AmbienteDTO();
      ambienteTemp.FullName = caminhoAmbiente;
      CarregarAtalhos(listaAtalhos, ref ambienteTemp);

      return ambienteTemp.Arquivos;
		}

    public List<AmbienteDTO> ListarAmbientes(List<AtalhoDTO> listaAtalhos)
    {
      List<AmbienteDTO> listaAmbientes = new List<AmbienteDTO>();
      var unidades = DriveInfo.GetDrives().Where(x => x.DriveType == DriveType.Fixed).Select(x => x.Name).ToList();
      foreach (var unidade in unidades)
      {
        listaAmbientes.AddRange(LerDiretorios($"{unidade}RM\\Legado", listaAtalhos));
        listaAmbientes.AddRange(LerDiretorios($"{unidade}RM\\Atual", listaAtalhos));
        listaAmbientes.AddRange(LerDiretorios($"{unidade}Linha-RM\\Legado", listaAtalhos));
        listaAmbientes.AddRange(LerDiretorios($"{unidade}Linha-RM\\Atual", listaAtalhos));
      }
      return listaAmbientes;
    }
	}
}
