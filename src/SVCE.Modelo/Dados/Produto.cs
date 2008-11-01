using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SVCE.Modelo.Dados
{
    public class Produto
    {

        public int CodigoInterno { get; set; }
        public string CodigoExterno { get;  set;  }
        public string Nome {get;  set; }
        public decimal PrecoVenda {get;  set;}
        public Status Status {get;  set; }
        public int IdFornecedor { get;  set;}
        public int QuantidadeMinima { get;  set; }


        public static Produto[] Listar(BancoDeDados b, int? codigoInterno, string codigoExterno, string nome)
        {
            string formato = "%{0}%";
            if (nome != null)
                nome = string.Format(formato, nome);
            if (codigoExterno != null)
                codigoExterno = string.Format(formato, codigoExterno);
            var sql = @"SELECT CODIGO_INTERNO, NOME,CODIGO_EXTERNO,ID_FORNECEDOR,PRECO_VENDA,QUNTIDADE_MINIMA,ID_STATUS FROM PRODUTOS WHERE	ID_STATUS = 1 
            AND     NOME LIKE  COALESCE(@NOME, NOME) 
            AND		CODIGO_EXTERNO LIKE COALESCE(@CODIGO_EXTERNO, CODIGO_EXTERNO)
            AND		COALESCE(@CODIGO_INTERNO, CODIGO_INTERNO) = CODIGO_INTERNO ";


            var cmd = b.CriarComando(sql, System.Data.CommandType.Text);
            cmd.Parameters.Add(new SqlParameter("@NOME", ((object)nome) ?? (object)DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@CODIGO_EXTERNO", ((object)codigoExterno) ?? (object)DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@CODIGO_INTERNO", ((object)codigoInterno) ?? (object)DBNull.Value));

            SqlDataReader r = null;
            try
            {
                r = cmd.ExecuteReader();
                List<Produto> retorno = new List<Produto>();
                while (r.Read())
                {
                    Produto p = new Produto();
                    p.CodigoInterno = r.GetInt32(0);
                    p.Nome = r.GetString(1);
                    p.CodigoExterno = r.GetString(2);
                    p.IdFornecedor = r.GetInt32(3);
                    p.PrecoVenda = r.GetDecimal(4);
                    p.QuantidadeMinima = r.GetInt32(5);
                    retorno.Add(p);
                }
                return retorno.ToArray();
            }
            finally
            {
                if (r != null)
                    r.Close();
            }
        }

        public void Incluir(BancoDeDados b)
        {
            string sql = @"
INSERT INTO [PRODUTOS]
           ([NOME]
           ,[CODIGO_EXTERNO]
           ,[ID_FORNECEDOR]
           ,[PRECO_VENDA]
           ,[QUNTIDADE_MINIMA]
           ,[ID_STATUS])
     VALUES
           (@NOME
           ,@EXTERNO
           ,@IDFORNECEDOR
           ,@PRECOVENDA
           ,@QUNTIDADEMINIMA
           ,1)
";
            SqlCommand cmd = b.CriarComando(sql, System.Data.CommandType.Text);
            cmd.Parameters.Add(new SqlParameter("@NOME", Nome));
            cmd.Parameters.Add(new SqlParameter("@EXTERNO", CodigoExterno));
            cmd.Parameters.Add(new SqlParameter("@IDFORNECEDOR", IdFornecedor));
            cmd.Parameters.Add(new SqlParameter("@PRECOVENDA", PrecoVenda));
            cmd.Parameters.Add(new SqlParameter("QUNTIDADEMINIMA", QuantidadeMinima));
            int count = cmd.ExecuteNonQuery();
            if (count == 0)
                throw new Exception("Não foi possível incluir o produto.");
        }
        public void Alterar(BancoDeDados b)
        {
            string sql = "UPDATE [PRODUTOS] SET [NOME] = @NOME, [CODIGO_EXTERNO] = @CODIGOEXTERNO, [ID_FORNECEDOR] = @IDFORNECEDOR, [PRECO_VENDA] = @PRECOVENDA, [QUNTIDADE_MINIMA] = @QUNTIDADEMINIMA WHERE CODIGO_INTERNO = @CODIGOINTERNO";
            SqlCommand cmd = b.CriarComando(sql, System.Data.CommandType.Text);
            cmd.Parameters.Add(new SqlParameter("@INTERNO", CodigoInterno));
            cmd.Parameters.Add(new SqlParameter("@NOME", Nome));
            cmd.Parameters.Add(new SqlParameter("@EXTERNO", CodigoExterno));
            cmd.Parameters.Add(new SqlParameter("@IDFORNECEDOR", IdFornecedor));
            cmd.Parameters.Add(new SqlParameter("@PRECOVENDA", PrecoVenda));
            cmd.Parameters.Add(new SqlParameter("@QUNTIDADEMINIMA", QuantidadeMinima));
            int count = cmd.ExecuteNonQuery();
            if (count == 0)
            {
                throw new Exception("Não foi possível alterar nenhum produto.");
            }
        }
        public static void Excluir(BancoDeDados b, int CodigoInterno)
        {
            string sql = "UPDATE PRODUTOS SET ID_STATUS = 2 WHERE CODIGO_INTERNO = @INTERNO";
            SqlCommand com = b.CriarComando(sql, System.Data.CommandType.Text);
            com.Parameters.Add(new SqlParameter("@INTERNO", CodigoInterno));
            int count = com.ExecuteNonQuery();
            if (count == 0)
                throw new Exception("Produto inexistente!");
        }
    }
}
