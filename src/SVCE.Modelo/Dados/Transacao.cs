using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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


        public int IdTransacao;
        public int? IdTransacaoPai;
        public int IdFornecedor;
        public int IdResponsavel;
        public DateTime DataTransacao;
        public StatusTransacao StatusTransacao;
        public decimal ValorTotal;
        public List<ItemTransacao> Itens;
        public int? NumeroNotaFiscal;


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
        public void Incluir()
        {

        }

        public void Concluir()
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
            return null;
        }


        public void Incluir()
        {

        }

    }
}
