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
        public void IncluirProduto(List<ItemTransacao> item)
        {
            BancoDeDados b = new BancoDeDados();
            try
            {
                b.Conectar();
                foreach (ItemTransacao i in item)
                {
                    ItemTransacao it = new ItemTransacao();
                    it.IdProduto = i.IdProduto;
                    it.NomeProduto = i.NomeProduto;
                    it.PrecoUnitario = i.PrecoUnitario;
                    it.Quantidade = i.Quantidade;
                    it.Sequencial = i.Sequencial;

                }
            }
            finally
            {
                b.Desconectar();
            }
        }
    }
}
