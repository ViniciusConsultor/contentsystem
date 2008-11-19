using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVCE.Modelo.Dados
{


	public enum TipoItemTransacao
	{
		Entrada, Saida
	}

	[Serializable]
    public class ItemTransacao
    {
		public int Sequencial { get; set; }
		public int IdProduto { get; set; }
		public int Quantidade { get; set; }
		public decimal PrecoUnitario { get; set; }

		public TipoItemTransacao TipoItem { get; set; }
		


		public string NomeProduto { get; set; }

		public decimal PrecoTotal
		{
			get
			{
				return PrecoUnitario * Quantidade;
			}
		}

    }
}
