using System;
using System.Drawing;
using System.Linq;

namespace Atalhos
{
  public class Atalho
  {
    public Atalho() { }

    public Atalho(string caminho)
    {
      Caminho = caminho;
    }

    public Atalho(string nome, string caminho)
    {
      Nome = nome;
      Caminho = caminho;
    }

		public Atalho(string nome, string caminho, string argumentos)
		{
			Nome = nome;
			Caminho = caminho;
			Argumentos = argumentos;
		}

		public string Nome { get; set; }
    public string Caminho { get; set; }
    public string Argumentos { get; set; }


		public Bitmap Imagem { get; set; }
  }
}