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

        public ItemRelatorioProdutosMaisVendidos[] ListarProdutosMaisVendido(DateTime df, DateTime di)
        {
            BancoDeDados b = new BancoDeDados();
            RelatorioProdutosMaisVendidos r = new RelatorioProdutosMaisVendidos();
            try
            {
                b.Conectar();
                r.DataFinal = df;
                r.DataInicial = di;
                return r.GerarRelatorioMaisVendido(b);
            }
            finally
            {
                b.Desconectar();
            }
        }

        public ItemRelatorioProdutosMaisVendidos[] ListarVolumeVendas(DateTime dt, DateTime df, string periodo)
        {
            BancoDeDados b = new BancoDeDados();
            RelatorioProdutosMaisVendidos r = new RelatorioProdutosMaisVendidos();
            r.DataFinal = df;
            r.DataInicial = dt;
            r.perido = periodo;
            try
            {
                b.Conectar();
                return r.GerarRelarioVolumeVenda(b);
            }
            finally
            {
                b.Desconectar();
            }
        }
    }
}
