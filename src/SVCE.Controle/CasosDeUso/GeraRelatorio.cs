using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SVCE.Modelo.Dados;

namespace SVCE.Controle.CasosDeUso
{
    public class GeraRelatorio
    {
        public ItemRelatorioProdutosSemEstoque[] Listar()
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
    }
}
