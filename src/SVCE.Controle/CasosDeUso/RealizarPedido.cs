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
        public void Incluir()
        {
        }
    }
}
