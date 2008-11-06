using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SVCE.Modelo.Dados
{
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


        public decimal CalcularValorTotal()
        {
            return 0;
        }



        protected void Incluir()
        {

        }
        protected void AlterarStatusTransacao(int id_transacao, StatusTransacao novoStatusTransacao)
        {

        }

    }

    public class Compra : Transacao
    {
        public void Incluir(BancoDeDados b)
        {
            foreach (ItemTransacao i in Itens)
            {
                string sql = @"INSERT INTO ITENS_TRANSACOES(ID_TRANSACAO,SEQUENCIAL,ID_PRODUTO,QUANTIDADE,PRECO_UNITARIO,IN_ENTRADA_SAIDA) VALUES(@IDTRANSACAO,@SEQUENCIAL,@IDPRODUTO, @QUANTIDADE,@PRECOUNITARIO, @INENTRADASAIDA)";
                SqlCommand cmd = b.CriarComando(sql, System.Data.CommandType.Text);
                cmd.Parameters.Add(new SqlParameter("@IDTRANSACAO", IdTransacao));
                cmd.Parameters.Add(new SqlParameter("@SEQUENCIAL", i.Sequencial));
                cmd.Parameters.Add(new SqlParameter("@IDPRODUTO", i.IdProduto));
                cmd.Parameters.Add(new SqlParameter("@QUANTIDADE", i.Quantidade));
                cmd.Parameters.Add(new SqlParameter("@PRECOUNITARIO", i.PrecoUnitario));
                cmd.Parameters.Add(new SqlParameter("@INENTRADASAIDA", "E"));

                int count = cmd.ExecuteNonQuery();
                if (count == 0)
                    throw new Exception("Não foi possível cadastrar o produto.");
            }


            string sql2 = @"UPDATE TRANSACOES SET ID_TIPO_TRANSACAO = @TIPOTRANSACAO, DATA_TRANSACAO = @DATATRANSACAO  WHERE ID_TRANSACAO = @IDTRANSACAO";
            SqlCommand cmd2 = b.CriarComando(sql2, System.Data.CommandType.Text);
            cmd2.Parameters.Add(new SqlParameter("@TIPOTRANSACAO", TipoTransacao.Compra));
            cmd2.Parameters.Add(new SqlParameter("@DATATRANSACAO", DataTransacao));
            cmd2.Parameters.Add(new SqlParameter("@IDTRANSACAO", IdTransacao));


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
    public class Venda : Transacao
    {


        public void Incluir()
        {

        }

        public static Venda PesquisarVenda(int numeroNotaFiscal)
        {
            return null;
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
        public static PedidoCompra[] ListarPedidosCompra(int? idProduto, StatusTransacao? statusTransacao, DateTime? dataInicial, DateTime? DataFinal)
        {
            string sql = @"SELECT ";


            return null;
        }


        public static int Incluir(BancoDeDados b,int IdFornecedor, int idResponsavel, decimal valorTotal)
        {
            int id = 0;
            string a;
            string sql = @"INSERT INTO TRANSACOES(ID_TIPO_TRANSACAO, ID_FORNECEDOR, ID_RESPONSAVEL, DATA_TRANSACAO, ID_STATUS, VALOR_TOTAL) VALUES(@IDTIPOTRANSACAO, @IDFORNECEDOR, @IDRESPONSAVEL, @DATATRANSACAO, @IDSTATUS, @VALORTOTAL) SELECT ID = @@IDENTITY";
            SqlCommand cmd = b.CriarComando(sql, System.Data.CommandType.Text);
            cmd.Parameters.Add(new SqlParameter("@IDTIPOTRANSACAO",TipoTransacao.Pedido));
            cmd.Parameters.Add(new SqlParameter("@IDFORNECEDOR", IdFornecedor));
            cmd.Parameters.Add(new SqlParameter("@IDRESPONSAVEL", idResponsavel));
            cmd.Parameters.Add(new SqlParameter("@DATATRANSACAO", DateTime.Now));
            cmd.Parameters.Add(new SqlParameter("@IDSTATUS", StatusTransacao.Concluido));
            cmd.Parameters.Add(new SqlParameter("@VALORTOTAL", valorTotal));

            SqlDataReader r = null;
            try
            {
                id =Int32.Parse(cmd.ExecuteScalar().ToString());
                /*while (r.Read())
                {
                    id = r.GetInt32(0);
                }*/
                return id;
            }
            finally
            {
                if (r != null)
                    r.Close();
            }     
        }

        public static void IncluirPedido(BancoDeDados b,int idTransação, ItemTransacao l)
        {
            string sql = @"INSERT INTO ITENS_TRANSACOES(ID_TRANSACAO,SEQUENCIAL,ID_PRODUTO, QUANTIDADE, PRECO_UNITARIO, IN_ENTRADA_SAIDA) VALUES(@IDTRANSACAO,@SEQUENCIAL,@IDPRODUTO,@QUANTIDADE,@PRECOUNITARIO,@INENTRADASAIDA)";

            SqlCommand cmd = b.CriarComando(sql, System.Data.CommandType.Text);
            cmd.Parameters.Add(new SqlParameter("@IDTRANSACAO", idTransação));
            cmd.Parameters.Add(new SqlParameter("@SEQUENCIAL", l.Sequencial));
            cmd.Parameters.Add(new SqlParameter("@IDPRODUTO", l.IdProduto));
            cmd.Parameters.Add(new SqlParameter("@QUANTIDADE", l.Quantidade));
            cmd.Parameters.Add(new SqlParameter("@PRECOUNITARIO", l.PrecoUnitario));
            cmd.Parameters.Add(new SqlParameter("@INENTRADASAIDA", "E"));
            int count = cmd.ExecuteNonQuery();

            if (count == 0)
                throw new Exception("Não foi possível adcionar os itens.");
        }
    }
}
