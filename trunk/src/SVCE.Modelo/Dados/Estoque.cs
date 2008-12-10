using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace SVCE.Modelo.Dados
{
    public class Estoque
    {
        public int idFornecedor { get; set; }
        public int codInterno{get; set;}
        public string nome { get; set; }
        public int qtMinima { get; set; }
        public int qtEstoque { get; set; }
        public int qtCompra { get; set; }
        public string NFornecedor { get; set; }
        public decimal preco { get; set; }

        public static Estoque[] ListarProdutosAbaixoEstoque(BancoDeDados b)
        {
            var sql = @" SELECT * FROM estoque_abaixo";
            var cmd = b.CriarComando(sql, System.Data.CommandType.Text);
            SqlDataReader r = null;
            try
            {
                r = cmd.ExecuteReader();
                List<Estoque> retorno = new List<Estoque>();
                while (r.Read())
                {
                    Estoque e = new Estoque();
                    e.idFornecedor = r.GetInt32(0);
                    e.codInterno = r.GetInt32(1);
                    e.nome = r.GetString(2);
                    e.qtMinima = r.GetInt32(3);
                    e.qtEstoque = r.GetInt32(4);
                    e.qtCompra = r.GetInt32(5);
                    retorno.Add(e);
                }
                return retorno.ToArray();
            }
            finally
            {
                if (r != null)
                    r.Close();
            }
        }
        public static Estoque[] ConsultarEstoque(BancoDeDados b)
        {
            var sql = @"SELECT			F.NOME,E.CODIGO_INTERNO,E.NOME,
				E.QUANTIDADE_MINIMA,E.QUANTIDADE_ESTOQUE,
				P.PRECO_VENDA
FROM			ESTOQUE E
LEFT OUTER JOIN FORNECEDORES F
ON				F.ID_FORNECEDOR = E.ID_FORNECEDOR
LEFT OUTER JOIN		PRODUTOS P
ON				E.CODIGO_INTERNO = P.CODIGO_INTERNO";
            var cmd = b.CriarComando(sql, System.Data.CommandType.Text);
            SqlDataReader r = null;
            try
            {
                r = cmd.ExecuteReader();
                List<Estoque> retorno = new List<Estoque>();
                while (r.Read())
                {
                    Estoque e = new Estoque();
                    e.NFornecedor = r.GetString(0);
                    e.codInterno = r.GetInt32(1);
                    e.nome = r.GetString(2);
                    e.qtMinima = r.GetInt32(3);
                    e.qtEstoque = r.GetInt32(4);
                    e.preco = r.GetDecimal(5);
                    retorno.Add(e);
                }
                return retorno.ToArray();
            }
            finally
            {
                if (r != null)
                    r.Close();
            }
       }
    }
}
