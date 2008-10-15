using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SVCE.Modelo.Dados
{
    public class Produto
    {

        public int CodigoInterno { get { return CodigoInterno; } set { CodigoInterno = value; } }
        public string CodigoExterno { get { return CodigoExterno; } set { CodigoExterno = value; } }
        public string Nome { get { return Nome; } set { Nome = value; } }
        public decimal PrecoVenda { get { return PrecoVenda; } set { PrecoVenda = value; } }
        public Status Status { get { return Status; } set { Status = value; } }
        public int IdFornecedor { get { return IdFornecedor; } set { IdFornecedor = value; } }
        public int QuantidadeMinima { get { return QuantidadeMinima; } set { QuantidadeMinima = value; } }


        public static Produto[] Listar(int? codigoInterno, string codigoExterno, string nome)
        {
            List<SqlParameter> listaParametrs = new List<SqlParameter>();
            string sql = "WHERE ID_STATUS = 1";
            if (codigoInterno != null)
            {
                sql += "AND CODIGO_INTERNO = @INTERNO";
                listaParametrs.Add(new SqlParameter("@INTERNO", codigoInterno));
            }
            if(codigoExterno != null)
            {
                sql +="AND CODIGO_EXTERNO = @EXTERNO";
                listaParametrs.Add(new SqlParameter("@EXTERNO", codigoExterno));
            }
            if(nome != null)
            {
                sql += "AND NOME =@NOME";
                listaParametrs.Add(new SqlParameter("@NOME", nome));
            }
            List<Produto> p = new List<Produto>();
            SqlCommand com = new SqlCommand();
            BancoDeDados b = new BancoDeDados();
            com = b.CriarComando(string.Format("SELECT * FROM PRODUTOS {0} ORDER BY NAME", sql), System.Data.CommandType.Text);
            com.Parameters.Add(listaParametrs.ToArray());
            SqlDataReader r = null;
            try
            {
                r = com.ExecuteReader();
                while (r.Read())
                {
                    Produto pr = new Produto();
                    pr.Nome = (string)r["NOME"];
                    pr.CodigoInterno = (int)r["CODIGO_INTERNO"];
                    pr.CodigoExterno = (string)r["CODIGO_EXTERNO"];
                    pr.IdFornecedor = (int)r["ID_FORNECEDOR"];
                    pr.PrecoVenda = (decimal)r["PRECO_VENDA"];
                    pr.QuantidadeMinima = (int)r["QUANTIDADE_MINIMA"];
                    pr.Status = Status.Ativo;
                    p.Add(pr);
                }

            }
            finally
            {
                if (r != null)
                    r.Close();
            }

            return p.ToArray();
        }
        public void Incluir()
        {
            string sql = "INSERT INTO PRODUTOS(CODIGO_INTERNO, NOME, CODIGO_EXTERNO, ID_FORNECEDOR, PRECO_VENDA, QUANTIDADE_MINIMA, ID_STATUS) VALUES(@INTERNO,@NOME, @EXTERNO, @IDFORNECEDOR, @PRECOVENDA, @QUANTIDADEMINIMA,@IDSTATUS)";
            BancoDeDados b = new BancoDeDados();
            SqlCommand cmd = b.CriarComando(sql, System.Data.CommandType.Text);
            cmd.Parameters.Add(new SqlParameter("@INTERNO", CodigoInterno));
            cmd.Parameters.Add(new SqlParameter("@NOME", Nome));
            cmd.Parameters.Add(new SqlParameter("@EXTERNO", CodigoExterno));
            cmd.Parameters.Add(new SqlParameter("@IDFORNECEDOR", IdFornecedor));
            cmd.Parameters.Add(new SqlParameter("@PRECOVENDA", PrecoVenda));
            cmd.Parameters.Add(new SqlParameter("@QUANTIDADEMINIMA", QuantidadeMinima));
            cmd.Parameters.Add(new SqlParameter("@IDSTATUS",(int)Status));
            int count = cmd.ExecuteNonQuery();
            if (count == 0)
                throw new Exception("Não foi possível incluir o produto.");
        }
        public void Alterar()
        {
            string sql = "UPDATE PRODUTOS SET NOME = @NOME, CODIGO_EXTERNO = @CODIGOEXTERNO, ID_FORNECEDOR = @IDFORNECEDOR, PRECO_VENDA = @PRECOVENDA, QUANTIDADE_MINIMA = @QUANTIDADEMINIMA, ID_STATUS = @IDSTATUS WHERE CODIGO_INTERNO = @CODIGOINTERNO";
            BancoDeDados b = new BancoDeDados();
            SqlCommand cmd = b.CriarComando(sql, System.Data.CommandType.Text);
            cmd.Parameters.Add(new SqlParameter("@INTERNO", CodigoInterno));
            cmd.Parameters.Add(new SqlParameter("@NOME", Nome));
            cmd.Parameters.Add(new SqlParameter("@EXTERNO", CodigoExterno));
            cmd.Parameters.Add(new SqlParameter("@IDFORNECEDOR", IdFornecedor));
            cmd.Parameters.Add(new SqlParameter("@PRECOVENDA", PrecoVenda));
            cmd.Parameters.Add(new SqlParameter("@QUANTIDADEMINIMA", QuantidadeMinima));
            cmd.Parameters.Add(new SqlParameter("@IDSTATUS", (int)Status));
            int count = cmd.ExecuteNonQuery();
            if (count == 0)
            {
                throw new Exception("Não foi possível alterar nenhum produto.");
            }
        }
        public static void Excluir(int codigoExterno)
        {
            string sql = "UPDATE PRODUTOS SET ID_STATUS = 2 WHERE CODIGO_EXTERNO = @EXTERNO";
            BancoDeDados b = new BancoDeDados();
            SqlCommand com = b.CriarComando(sql, System.Data.CommandType.Text);
            com.Parameters.Add(new SqlParameter("@EXTERNO", codigoExterno));
            int count = com.ExecuteNonQuery();
            if (count == 0)
                throw new Exception("Produto inexistente!");
        }


        public static Produto[] Listar(string codigoExterno, string codigoExterno_2, string nome)
        {
            throw new NotImplementedException();
        }
    }
}
