using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SVCE.Modelo.Dados;

namespace SVCE.Controle.CasosDeUso
{
    public class RealizarCompra
    {
        public PedidoCompra[] Listarpedido(int? idProduto)
        {
            BancoDeDados b = new BancoDeDados();
            try
            {
                b.Conectar();
                return PedidoCompra.ListarPedidosCompra(b, idProduto);
            }
            finally
            {
                b.Desconectar();
            }
        }
        public void IncluirCompra(int id)
        {
            Compra c = new Compra();
            BancoDeDados b = new BancoDeDados();
            c.IdTransacao = id;
            c.DataTransacao = DateTime.Now;
            try
            {
                b.Conectar();
                c.Incluir(b);
            }
            finally
            {
                b.Desconectar();
            }
        }
    }
}
