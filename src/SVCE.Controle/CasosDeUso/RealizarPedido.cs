using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SVCE.Modelo.Dados;
namespace SVCE.Controle.CasosDeUso
{
    public class RealizarPedido
    {
        public Estoque[] ListarBaixoEstoque()
        {
            BancoDeDados b = new BancoDeDados();
            try
            {
                b.Conectar();
                return Estoque.ListarProdutosAbaixoEstoque(b);
            }
            finally
            {
                b.Desconectar();
            }
        }
        public void IncluirPedido(int IdFornecedor, int idResponsavel, decimal valorTotal,List<ItemTransacao> item)
        {
            BancoDeDados b = new BancoDeDados();
            PedidoCompra p = new PedidoCompra();
            try
            {
                b.Conectar();
                p.Incluir(b, IdFornecedor, idResponsavel, valorTotal, item);
            }
            finally
            {
                b.Desconectar();
            }
        }
        public Estoque[] ListarEstoque()
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
