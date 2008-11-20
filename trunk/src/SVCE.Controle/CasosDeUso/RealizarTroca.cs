using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SVCE.Modelo.Dados;

namespace SVCE.Controle.CasosDeUso
{
	public class RealizarTroca : RealizarVenda
	{

		public Venda CarregarVenda(int numeroNota)
		{
			BancoDeDados banco = new BancoDeDados();
			try
			{
				banco.Conectar();
				var venda = Venda.PesquisarVenda(banco, numeroNota);
				if (venda != null)
					venda.CarregarItens(banco);
				return venda;
			}
			finally
			{
				banco.Desconectar();
			}
		}

		public MotivoTroca[] ListarMotivosTroca()
		{
			BancoDeDados banco = new BancoDeDados();
			try
			{
				banco.Conectar();
				return MotivoTroca.Listar(banco);
			}
			finally
			{
				banco.Desconectar();
			}
		}

	}
}
