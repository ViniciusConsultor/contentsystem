using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SVCE.Modelo.Dados
{
    public class Fornecedor
    {
        public int IdFornecedor { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public Status Status { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string NomeContato { get; set; }
        

        public static Fornecedor[] Listar(BancoDeDados banco, string nome, string razaoSocial, string cnpj)
        {
            string formato = "%{0}%";
            if (nome != null)
                nome = string.Format(formato, nome);
            if (razaoSocial != null)
                razaoSocial = string.Format(formato, razaoSocial);
           

            var sql = @"
SELECT     ID_FORNECEDOR, NOME, RAZAO_SOCIAL, CNPJ, ENDERECO, TELEFONE, EMAIL, NOME_CONTATO
FROM         FORNECEDORES
WHERE	ID_STATUS = 1 
AND     NOME LIKE  COALESCE(@NOME, NOME) 
AND		RAZAO_SOCIAL LIKE COALESCE(@RAZAO_SOCIAL, RAZAO_SOCIAL)
AND		COALESCE(@CNPJ, CNPJ) = CNPJ ";

            var cmd = banco.CriarComando(sql, System.Data.CommandType.Text);
            cmd.Parameters.Add(new SqlParameter("@NOME", ((object)nome) ?? (object)DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@RAZAO_SOCIAL", ((object)razaoSocial) ?? (object)DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@CNPJ", ((object)cnpj) ?? (object)DBNull.Value));


            

            SqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
                List<Fornecedor> retorno = new List<Fornecedor>();
                while (reader.Read())
                {
                    Fornecedor fornecedor = new Fornecedor();
                    fornecedor.IdFornecedor = reader.GetInt32(0);
                    fornecedor.Nome = reader.GetString(1);
                    fornecedor.RazaoSocial = reader.GetString(2);
                    fornecedor.CNPJ = reader.GetString(3);
                    fornecedor.Endereco = reader.GetString(4);
                    fornecedor.Telefone = reader.GetString(5);
                    fornecedor.Email = reader.GetString(6);
                    fornecedor.NomeContato = reader.GetString(7);
                    retorno.Add(fornecedor);
                }
                return retorno.ToArray();
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }


        }
        public void Incluir(BancoDeDados banco)
        {

            string sql = @"
INSERT INTO [FORNECEDORES]
           ([NOME]
           ,[RAZAO_SOCIAL]
           ,[CNPJ]
           ,[ENDERECO]
           ,[TELEFONE]
           ,[EMAIL]
           ,[NOME_CONTATO]
           ,[ID_STATUS])
     VALUES
           (@NOME
           ,@RAZAO_SOCIAL
           ,@CNPJ
           ,@ENDERECO
           ,@TELEFONE
           ,@EMAIL
           ,@NOME_CONTATO
           ,1)
";

            var cmd = banco.CriarComando(sql, System.Data.CommandType.Text);
            cmd.Parameters.Add(new SqlParameter("@NOME", Nome));
            cmd.Parameters.Add(new SqlParameter("@RAZAO_SOCIAL", RazaoSocial));
            cmd.Parameters.Add(new SqlParameter("@CNPJ", CNPJ));
            cmd.Parameters.Add(new SqlParameter("@ENDERECO", Endereco));
            cmd.Parameters.Add(new SqlParameter("@TELEFONE", Telefone));
            cmd.Parameters.Add(new SqlParameter("@EMAIL", Email));
            cmd.Parameters.Add(new SqlParameter("@NOME_CONTATO", NomeContato));

            cmd.ExecuteNonQuery();

        }
        public void Alterar(BancoDeDados banco)
        {
            string sql = @"
UPDATE [FORNECEDORES]
   SET [NOME] = @NOME
      ,[RAZAO_SOCIAL] = @RAZAO_SOCIAL
      ,[CNPJ] = @CNPJ
      ,[ENDERECO] = @ENDERECO
      ,[TELEFONE] = @TELEFONE
      ,[EMAIL] = @EMAIL
      ,[NOME_CONTATO] = @NOME_CONTATO
 WHERE ID_FORNECEDOR = @ID_FORNECEDOR
";

            var cmd = banco.CriarComando(sql, System.Data.CommandType.Text);
            cmd.Parameters.Add(new SqlParameter("@NOME", Nome));
            cmd.Parameters.Add(new SqlParameter("@RAZAO_SOCIAL", RazaoSocial));
            cmd.Parameters.Add(new SqlParameter("@CNPJ", CNPJ));
            cmd.Parameters.Add(new SqlParameter("@ENDERECO", Endereco));
            cmd.Parameters.Add(new SqlParameter("@TELEFONE", Telefone));
            cmd.Parameters.Add(new SqlParameter("@EMAIL", Email));
            cmd.Parameters.Add(new SqlParameter("@NOME_CONTATO", NomeContato));
            cmd.Parameters.Add(new SqlParameter("@ID_FORNECEDOR", IdFornecedor));

            cmd.ExecuteNonQuery();
        }
        public static void Excluir(BancoDeDados banco, int id_fornecedor)
        {
            string sql = "UPDATE FORNECEDORES SET ID_STATUS = 2 WHERE ID_FORNECEDOR = @ID_FORNECEDOR";
            var cmd = banco.CriarComando(sql, System.Data.CommandType.Text);
            cmd.Parameters.Add(new SqlParameter("@id_fornecedor", id_fornecedor));

            cmd.ExecuteNonQuery();
        }

    }
}
