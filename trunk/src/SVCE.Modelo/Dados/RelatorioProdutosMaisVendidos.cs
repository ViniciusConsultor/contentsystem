using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SVCE.Modelo.Dados
{
    public class RelatorioProdutosMaisVendidos
    {
        //public DateTime DataInicial { get; set; }
        //public DateTime DataFinal { get; set; }
        //public ItemRelatorioProdutosMaisVendidos[] Produtos { get; set; }

        public DateTime? DataInicial{ get; set; }
        public DateTime? DataFinal{ get; set; }
        public string perido{ get; set; }
        public ItemRelatorioProdutosMaisVendidos[] Produtos;

        public ItemRelatorioProdutosMaisVendidos[] GerarRelarioVolumeVenda(BancoDeDados b)
        {
            string sql = @"relatorio_volume_vendas";
            var cmd = b.CriarComando(sql, System.Data.CommandType.StoredProcedure);
            cmd.Parameters.Add(new SqlParameter("@data_inicial",((object)DataInicial) ??(object)DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@data_final",((object)DataFinal) ?? (object)DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@periodo", ((object)perido) ?? (object)DBNull.Value));

            SqlDataReader r = null;
            List<ItemRelatorioProdutosMaisVendidos> l = new List<ItemRelatorioProdutosMaisVendidos>();
            try
            {
                r = cmd.ExecuteReader();
                while (r.Read())
                {
                    ItemRelatorioProdutosMaisVendidos i = new ItemRelatorioProdutosMaisVendidos();
                    i.data = r.GetDateTime(0);
                    i.VolumeVendas = r.GetDecimal(1);
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

        public ItemRelatorioProdutosMaisVendidos[] GerarRelatorioMaisVendido(BancoDeDados b)
        {
            string sql = @"RELATORIO_PRODUTOS_MAIS_VENDIDOS";
            var cmd = b.CriarComando(sql, System.Data.CommandType.StoredProcedure);
            cmd.Parameters.Add(new SqlParameter("@DATA_INICIAL", ((object)DataInicial) ?? (object)DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@DATA_FINAL", ((object)DataInicial) ?? (object)DBNull.Value));

            SqlDataReader r = null;
            List<ItemRelatorioProdutosMaisVendidos> l = new List<ItemRelatorioProdutosMaisVendidos>();
            try
            {
                r = cmd.ExecuteReader();
                while (r.Read())
                {
                    ItemRelatorioProdutosMaisVendidos i = new ItemRelatorioProdutosMaisVendidos();
                    i.NomeProduto = r.GetString(0);
                    i.QuantidadeVendida = r.GetInt32(1);
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

    public class ItemRelatorioProdutosMaisVendidos
    {
        //public int IdProduto { get; set; }
        //public string NomeProduto { get; set; }
        //public int IdFornecedor { get; set; }

        //public string NomeFornecedor { get; set; }
        //public int QuantidadeVendida { get; set; }
        //public decimal VolumeVendas { get; set; }

        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public int IdFornecedor { get; set; }
        public string NomeFornecedor { get; set; }
        public int QuantidadeVendida { get; set; }
        public decimal VolumeVendas { get; set; }
        public DateTime data { get; set; }

    }
}
