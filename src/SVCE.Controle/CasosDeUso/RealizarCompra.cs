using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SVCE.Modelo.Dados;

namespace SVCE.Controle.CasosDeUso
{
    class RealizarCompra
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
        public void IncluirCompra()
        {
            BancoDeDados b = new BancoDeDados();
            try
            {
                b.Conectar();
            }
            finally
            {
                b.Desconectar();
            }
        }
    }
}
