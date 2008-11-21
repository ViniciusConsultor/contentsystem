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
		public void RegistrarTroca(Troca troca)
		{
			BancoDeDados banco = new BancoDeDados();

			try
			{
				banco.Conectar();
				banco.IniciarTransacao();
				troca.Incluir(banco);
				banco.ConcluirTransacao();
			}
			catch (Exception ex)
			{
				banco.AbortarTransacao();
				throw new Exception("Não foi possível registrar venda!", ex);
			}
			finally
			{
				banco.Desconectar();
			}
		}
	}
}
