using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SVCE.Modelo.Dados
{
	[Serializable]
	public class Transacao
	{
		//public int IdTransacao { get; set; }
		//public int? IdTransacaoPai { get; set; }
		//public TipoTransacao TipoTransacao { get; set; }
		//public int IdFornecedor { get; set; }
		//public int IdResponsavel { get; set; }
		//public DateTime DataTransacao { get; set; }
		//public StatusTransacao StatusTransacao { get; set; }
		//public decimal ValorTotal { get; set; }
		//public int? NumeroNotaFiscal { get; set; }
		//public List<ItemTransacao> Itens { get; set; }


		public int IdTransacao { get; set; }
		public int? IdTransacaoPai { get; set; }
		public TipoTransacao tpTransacao { get; set; }
		public int IdFornecedor { get; set; }
		public int IdResponsavel { get; set; }
		public DateTime DataTransacao { get; set; }
		public StatusTransacao StatusTransacao { get; set; }
		public decimal ValorTotal { get; set; }
		public List<ItemTransacao> Itens { get; set; }
		public int? NumeroNotaFiscal { get; set; }
		public int IdFormaPagamento { get; set; }
        public string nomeF { get; set; }
        public int qt { get; set; }
        public string desPro { get; set; }
        public decimal pu { get; set; }
        public string nomeP { get; set;}
        public string nomeFU { get; set; }


		public decimal CalcularValorTotal()
		{
			return (from item in Itens
			 select item.PrecoTotal).Sum();
		}



		protected void Incluir()
		{

		}
		protected void AlterarStatusTransacao(int id_transacao, StatusTransacao novoStatusTransacao)
		{

		}

		public void CarregarItens(BancoDeDados banco)
		{
			string sql = "SELECT * FROM ITENS_TRANSACOES WHERE ID_TRANSACAO = @ID_TRANSACAO";
			var cmd = banco.CriarComando(sql, System.Data.CommandType.Text);
			cmd.Parameters.Add(new SqlParameter("@id_transacao", this.IdTransacao));

			var reader = cmd.ExecuteReader();
			try
			{
				while (reader.Read())
				{
					ItemTransacao item = new ItemTransacao();
					item.Sequencial = (int) reader["SEQUENCIAL"];
					item.IdProduto = (int)reader["ID_PRODUTO"];
					item.TipoItem =  ((string) reader["IN_ENTRADA_SAIDA"]) == "E" ? TipoItemTransacao.Entrada : TipoItemTransacao.Saida;

					if (this.Itens == null)
						this.Itens = new List<ItemTransacao>();
					Itens.Add(item);
				}
			}
			finally
			{
				reader.Close();
			}

		}

	}

	public class Compra : Transacao
	{
		public void Incluir(BancoDeDados b)
		{


            string sql2 = @"UPDATE TRANSACOES SET ID_TIPO_TRANSACAO = @TIPOTRANSACAO, DATA_TRANSACAO = @DATATRANSACAO, ID_STATUS = @STATUS  WHERE ID_TRANSACAO = @IDTRANSACAO";
			SqlCommand cmd2 = b.CriarComando(sql2, System.Data.CommandType.Text);
			cmd2.Parameters.Add(new SqlParameter("@TIPOTRANSACAO", TipoTransacao.Compra));
			cmd2.Parameters.Add(new SqlParameter("@DATATRANSACAO", DataTransacao));
			cmd2.Parameters.Add(new SqlParameter("@IDTRANSACAO", IdTransacao));
            cmd2.Parameters.Add(new SqlParameter("@STATUS", 3));


			int count2 = cmd2.ExecuteNonQuery();
			if (count2 == 0)
				throw new Exception("Não foi possível realizar a compra!");


		}

		public void Concluir(BancoDeDados b)
		{


		}
		public void Cancelar()
		{

		}

		public static Compra[] ListarCompras(int? id_produto, int? id_fornecedor, DateTime? data_inicial, DateTime? data_final, StatusTransacao statusTransacao)
		{
			return null;
		}


	}
	[Serializable]
	public class Venda : Transacao
	{


		public void Incluir(BancoDeDados banco)
		{
			string sql = @"INSERT INTO [dbo].[TRANSACOES]
           ([ID_TRANSACAO_PAI]
           ,[ID_TIPO_TRANSACAO]
           ,[ID_FORNECEDOR]
           ,[ID_RESPONSAVEL]
           ,[NUMERO_NOTA_FISCAL]
           ,[DATA_TRANSACAO]
           ,[ID_STATUS]
           ,[VALOR_TOTAL]
           ,[ID_MOTIVO_TROCA]
           ,[ID_FORMA_PAGAMENTO])
     VALUES
           (null
           ,2
           ,null
           ,@ID_RESPONSAVEL
           ,null
           ,getdate()
           ,3
           ,@VALOR_TOTAL
           ,null
           ,@ID_FORMA_PAGAMENTO
	);SELECT @@IDENTITY;";

			var cmd = banco.CriarComando(sql, System.Data.CommandType.Text);
			cmd.Parameters.Add(new SqlParameter("@ID_RESPONSAVEL", this.IdResponsavel));
			cmd.Parameters.Add(new SqlParameter("@VALOR_TOTAL", this.ValorTotal));
			cmd.Parameters.Add(new SqlParameter("@ID_FORMA_PAGAMENTO", this.IdFormaPagamento));

			int idVenda = Convert.ToInt32(cmd.ExecuteScalar());
			this.IdTransacao = idVenda;

			int sequencial = 1;
			foreach (ItemTransacao i in Itens)
			{
				sql = @"INSERT INTO ITENS_TRANSACOES(ID_TRANSACAO,SEQUENCIAL,ID_PRODUTO,QUANTIDADE,PRECO_UNITARIO,IN_ENTRADA_SAIDA) VALUES(@IDTRANSACAO,@SEQUENCIAL,@IDPRODUTO, @QUANTIDADE,@PRECOUNITARIO, @INENTRADASAIDA)";
				cmd = banco.CriarComando(sql, System.Data.CommandType.Text);
				cmd.Parameters.Add(new SqlParameter("@IDTRANSACAO", IdTransacao));
				cmd.Parameters.Add(new SqlParameter("@SEQUENCIAL", sequencial++));
				cmd.Parameters.Add(new SqlParameter("@IDPRODUTO", i.IdProduto));
				cmd.Parameters.Add(new SqlParameter("@QUANTIDADE", i.Quantidade));
				cmd.Parameters.Add(new SqlParameter("@PRECOUNITARIO", i.PrecoUnitario));
				cmd.Parameters.Add(new SqlParameter("@INENTRADASAIDA", "S"));

				cmd.ExecuteNonQuery();

			}

		}

		public static Venda PesquisarVenda(BancoDeDados banco,  int numeroNotaFiscal)
		{
			string sql = "SELECT ID_TRANSACAO FROM TRANSACOES WHERE NUMERO_NOTA_FISCAL = @NUMERO_NOTA_FISCAL";
			
			var cmd = banco.CriarComando(sql, System.Data.CommandType.Text);
			cmd.Parameters.Add(new SqlParameter("@NUMERO_NOTA_FISCAL", numeroNotaFiscal));
			var reader = cmd.ExecuteReader();
			try
			{
				while (reader.Read())
				{

					Venda venda = new Venda();
					venda.IdTransacao = (int)reader["ID_TRANSACAO"];
					


					return venda;
				}
				return null;
			}
			finally
			{
				reader.Close();
			}

		}

	}
	public class Troca : Transacao
	{

		public void Incluir()
		{

		}

		public Troca[] ListarTrocas(DateTime dataInicial, DateTime dataFinal)
		{
			return null;
		}
	}
	public class PedidoCompra : Transacao
	{
		public static PedidoCompra[] ListarPedidosCompra(BancoDeDados b, int? idProduto)
		{

			List<SqlParameter> listaParameters = new List<SqlParameter>();
			string where = "WHERE T.ID_TIPO_TRANSACAO = 5";
			if (idProduto != null)
			{
				where += "AND PR.CODIGO_INTERNO = @IDPRODUTO";
				listaParameters.Add(new SqlParameter("@IDPRODUTO", idProduto));
			}
			SqlCommand cmd = b.CriarComando(string.Format(@"SELECT	T.ID_TRANSACAO, I.NOME, 
		T.ID_TIPO_TRANSACAO, T.DATA_TRANSACAO, 
		T.VALOR_TOTAL, S.DESCRICAO, 
		F.NOME, IT.QUANTIDADE, 
		IT.PRECO_UNITARIO,PR.NOME,PR.CODIGO_INTERNO AS ID_PRODUTO 

FROM	TRANSACOES T
INNER JOIN FORNECEDORES F
ON		T.ID_FORNECEDOR = F.ID_FORNECEDOR 
INNER JOIN FUNCIONARIOS I
ON		T.ID_RESPONSAVEL = I.MATRICULA
INNER JOIN TIPOS_TRANSACAO P
ON		T.ID_TIPO_TRANSACAO = P.ID_TIPO_TRANSACAO
INNER JOIN STATUS_TRANSACAO S
ON		T.ID_STATUS = S.ID_STATUS
INNER JOIN ITENS_TRANSACOES IT
ON		T.ID_TRANSACAO = IT.ID_TRANSACAO
INNER JOIN PRODUTOS PR
ON		PR.CODIGO_INTERNO = IT.ID_PRODUTO {0} ", where), System.Data.CommandType.Text);
			cmd.Parameters.AddRange(listaParameters.ToArray());
            SqlDataReader r = null;
            List<PedidoCompra> l = new List<PedidoCompra>();
            try
            {
                r = cmd.ExecuteReader();
                while (r.Read())
                {
                    PedidoCompra t = new PedidoCompra();
                    t.IdTransacao = r.GetInt32(0);
                    t.nomeFU = r.GetString(1);
                    int a = r.GetInt32(2);
                    switch (a)
                    {
                        case 1:
                            t.tpTransacao = TipoTransacao.Compra;
                            break;
                        case 2:
                            t.tpTransacao = TipoTransacao.VendaLoja;
                            break;
                        case 3:
                            t.tpTransacao = TipoTransacao.VendaTelefone;
                            break;
                        case 4:
                            t.tpTransacao = TipoTransacao.Troca;
                            break;
                        case 5:
                            t.tpTransacao = TipoTransacao.Pedido;
                            break;
                        default:
                            t.tpTransacao = TipoTransacao.NotSet;
                            break;
                    }
                    t.DataTransacao = r.GetDateTime(3);
                    t.ValorTotal = r.GetDecimal(4);
                    t.desPro = r.GetString(5);
                    t.nomeF = r.GetString(6);
                    t.qt = r.GetInt32(7);
                    t.pu = r.GetDecimal(8);
                    t.nomeP = r.GetString(9);
                    l.Add(t);
                }
            }
            finally
            {
                if (r != null)
                    r.Close();
            }
            return l.ToArray();

		}


        public void Incluir(BancoDeDados b, int IdFornecedor, int idResponsavel, decimal valorTotal,List<ItemTransacao> l)
		{
			int id = 0;
			string a;
			string sql = @"INSERT INTO TRANSACOES(ID_TIPO_TRANSACAO, ID_FORNECEDOR, ID_RESPONSAVEL, DATA_TRANSACAO, ID_STATUS, VALOR_TOTAL) VALUES(@IDTIPOTRANSACAO, @IDFORNECEDOR, @IDRESPONSAVEL, @DATATRANSACAO, @IDSTATUS, @VALORTOTAL) SELECT ID = @@IDENTITY";
			SqlCommand cmd = b.CriarComando(sql, System.Data.CommandType.Text);
			cmd.Parameters.Add(new SqlParameter("@IDTIPOTRANSACAO", TipoTransacao.Pedido));
			cmd.Parameters.Add(new SqlParameter("@IDFORNECEDOR", IdFornecedor));
			cmd.Parameters.Add(new SqlParameter("@IDRESPONSAVEL", idResponsavel));
			cmd.Parameters.Add(new SqlParameter("@DATATRANSACAO", DateTime.Now));
			cmd.Parameters.Add(new SqlParameter("@IDSTATUS", StatusTransacao.Pendente));
			cmd.Parameters.Add(new SqlParameter("@VALORTOTAL", valorTotal));

				id = Int32.Parse(cmd.ExecuteScalar().ToString());
                foreach (ItemTransacao i in l)
                {
                    string sql2 = @"INSERT INTO ITENS_TRANSACOES(ID_TRANSACAO,SEQUENCIAL,ID_PRODUTO, QUANTIDADE, PRECO_UNITARIO, IN_ENTRADA_SAIDA) VALUES(@IDTRANSACAO,@SEQUENCIAL,@IDPRODUTO,@QUANTIDADE,@PRECOUNITARIO,@INENTRADASAIDA)";

                    SqlCommand cmd2 = b.CriarComando(sql2, System.Data.CommandType.Text);
                    cmd2.Parameters.Add(new SqlParameter("@IDTRANSACAO", id));
                    cmd2.Parameters.Add(new SqlParameter("@SEQUENCIAL", i.Sequencial + 1));
                    cmd2.Parameters.Add(new SqlParameter("@IDPRODUTO", i.IdProduto));
                    cmd2.Parameters.Add(new SqlParameter("@QUANTIDADE", i.Quantidade));
                    cmd2.Parameters.Add(new SqlParameter("@PRECOUNITARIO", i.PrecoUnitario));
                    cmd2.Parameters.Add(new SqlParameter("@INENTRADASAIDA", "E"));
                    int count = cmd2.ExecuteNonQuery();
                }
		}
	}
}
