using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SVCE.Modelo.Dados;

namespace SVCE.Controle.CasosDeUso
{
    public class GeraRelatorio
    {
        public ItemRelatorioProdutosSemEstoque[] ListarProdutosSemEstoque()
        {
            BancoDeDados b = new BancoDeDados();
            RelatorioProdutosSemEstoque r = new RelatorioProdutosSemEstoque();
            try
            {
                b.Conectar();
                return r.GerarRelatorio(b);
            }
            finally
            {
                b.Desconectar();
            }
        }

        public ItemRelatorioProdutosMaisVendidos[] ListarProdutosMaisVendido()
        {
            BancoDeDados b = new BancoDeDados();
            RelatorioProdutosMaisVendidos r = new RelatorioProdutosMaisVendidos();
            try
            {
                b.Conectar();
                return null;
            }
            finally
            {
                b.Desconectar();
            }
        }

        public RelatorioProdutosMaisVendidos ListarVolumeVendas()
        {
            BancoDeDados b = new BancoDeDados();
            RelatorioProdutosMaisVendidos r = new RelatorioProdutosMaisVendidos();
            try
            {
                b.Conectar();
                return null;
            }
            finally
            {
                b.Desconectar();
            }
        }
    }
}
