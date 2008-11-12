using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SVCE.Modelo.Dados
{
    public class RelatorioProdutosSemEstoque
    {
        //public ItemRelatorioProdutosSemEstoque[] Produtos { get; set; }
        public ItemRelatorioProdutosSemEstoque[] Produtos;


        public ItemRelatorioProdutosSemEstoque[] GerarRelatorio(BancoDeDados b)
        {
            string sql = @"RELATORIO_PRODUTOS_SEM_ESTOQUE";
            var cmd = b.CriarComando(sql, System.Data.CommandType.StoredProcedure);

            SqlDataReader r = null;
            List<ItemRelatorioProdutosSemEstoque> l = new List<ItemRelatorioProdutosSemEstoque>();
            try
            {
                r = cmd.ExecuteReader();
                while (r.Read())
                {
                    ItemRelatorioProdutosSemEstoque i = new ItemRelatorioProdutosSemEstoque();
                    i.IdProduto = r.GetInt32(0);
                    i.NomeProduto = r.GetString(1);
                    i.QuantidadeMinima = r.GetInt32(2);
                    i.QuantidadeDisponivel = r.GetInt32(3);
                    i.NomeFornecedor = r.GetString(4);
                    l.Add(i);
                }
                return l.ToArray();
            }
            finally
            {
                if (r != null)
                    r.Close();
            }
        }
    }

    public class ItemRelatorioProdutosSemEstoque
    {
        //public int IdProduto { get; set; }
        //public string NomeProduto { get; set; }
        //public int IdFornecedor { get; set; }
        //public string NomeFornecedor { get; set; }
        //public int QuantidadeDisponivel { get; set; }
        //public int QuantidadeMinima { get; set; }
        //public decimal PrecoVenda { get; set; }

        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public int IdFornecedor { get; set; }
        public string NomeFornecedor { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public int QuantidadeMinima { get; set; }
        public decimal PrecoVenda { get; set; }

    }
}
