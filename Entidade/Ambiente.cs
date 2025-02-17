using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atalhos
{
  public class Ambiente
  {
    public string Nome { get; internal set; }
    public string FullName { get; internal set; }
    public string Bin => Path.Combine(FullName, "Bin");
    public string Custom => Path.Combine(Bin, "Custom");
    public string Unidade { get; internal set; }

    public List<Atalho> Arquivos = new List<Atalho>();
  }
}
