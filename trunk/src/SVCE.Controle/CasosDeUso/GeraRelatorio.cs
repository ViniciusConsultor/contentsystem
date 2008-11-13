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

        public ItemRelatorioProdutosMaisVendidos[] ListarProdutosMaisVendido(DateTime? df, DateTime? di)
        {
            BancoDeDados b = new BancoDeDados();
            RelatorioProdutosMaisVendidos r = new RelatorioProdutosMaisVendidos();
            if (df != null)
                r.DataFinal = df;
            if (di != null)
                r.DataInicial = di;
            try
            {
                b.Conectar();
                return r.GerarRelatorioMaisVendido(b);
            }
            finally
            {
                b.Desconectar();
            }
        }

        public ItemRelatorioProdutosMaisVendidos[] ListarVolumeVendas(DateTime? dt, DateTime? df, string periodo)
        {
            BancoDeDados b = new BancoDeDados();
            RelatorioProdutosMaisVendidos r = new RelatorioProdutosMaisVendidos();
            if(df != null)
                r.DataFinal = df;
            if(dt != null)
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
