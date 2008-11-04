using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SVCE.Modelo.Dados;

namespace SVCE.Controle.CasosDeUso
{
	
	public class RealizarVenda
	{
		
		public Produto BuscarProduto(int codigo)
		{
			BancoDeDados banco = new BancoDeDados();
			try
			{
				banco.Conectar();
				var produtos =  Produto.Listar(banco, codigo, null, null);
				if (produtos.Count() == 0)
					return null;
				else
					return produtos.First();
			}
			finally
			{
				banco.Desconectar();
			}
		}

		public FormaPagamento[] ListarFormasPagamento()
		{
			BancoDeDados banco = new BancoDeDados();
			try
			{
				banco.Conectar();
				return FormaPagamento.Listar(banco);
			}
			finally
			{
				banco.Desconectar();
			}
		}
	}
}
