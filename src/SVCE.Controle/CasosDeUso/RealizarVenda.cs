using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SVCE.Modelo.Dados;
using System.Data;
using System.Data.SqlClient;

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
		public void RegistrarVenda(Venda venda)
		{
			BancoDeDados banco = new BancoDeDados();

			try
			{
				banco.Conectar();
				banco.IniciarTransacao();
				venda.Incluir(banco);
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

		public DataSet BuscarDadosNotaFiscal(int id_transacao)
		{
			BancoDeDados banco = new BancoDeDados();
			try
			{
				banco.Conectar();

				var cmd = banco.CriarComando("BUSCAR_DADOS_NOTA_FISCAL", CommandType.StoredProcedure);
				cmd.Parameters.Add(new SqlParameter("@ID_TRANSACAO", id_transacao));

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataSet ds = new DataSet();
				da.Fill(ds);
				return ds;
			}
			finally
			{
				banco.Desconectar();
			}
		}
        public Estoque[] ConsultarEstoque()
        {
            BancoDeDados b = new BancoDeDados();
            try
            {
                b.Conectar();
                return Estoque.ConsultarEstoque(b);

            }
            finally
            {
                b.Desconectar();
                
            }
        }
	}
}
