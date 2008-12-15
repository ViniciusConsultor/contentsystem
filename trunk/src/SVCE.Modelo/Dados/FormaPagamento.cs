using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SVCE.Modelo.Dados
{
	public class FormaPagamento
	{

		public int ID { get; set; }
		public string Descricao { get; set; }

        public void Inserir(BancoDeDados b)
        {
            string sql = @"INSERT INTO FORMA_PAGAMENTO (DESCRICAO) VALUES(@DESCRICAO)";
            SqlCommand cmd = b.CriarComando(sql, System.Data.CommandType.Text);
            cmd.Parameters.Add(new SqlParameter("@DESCRICAO", Descricao));
            int count = cmd.ExecuteNonQuery();
            if (count == 0)
                throw new Exception("Não foi possível incluir o motivo.");
        }

        public void Remover(BancoDeDados b)
        {
            string sql = @"DELETE FROM FORMA_PAGAMENTO WHERE ID_FORMA_PAGAMENTO = @ID";
            SqlCommand com = b.CriarComando(sql, System.Data.CommandType.Text);
            com.Parameters.Add(new SqlParameter("@ID", ID));
            int count = com.ExecuteNonQuery();
            if (count == 0)
                throw new Exception("Motivo inexistente!");
        }

		public static FormaPagamento[] Listar(BancoDeDados banco)
		{
			List<FormaPagamento> formas = new List<FormaPagamento>();

			string sql = "SELECT * FROM FORMA_PAGAMENTO";

			var cmd = banco.CriarComando(sql, System.Data.CommandType.Text);
			var reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				FormaPagamento forma = new FormaPagamento();
				forma.ID = reader.GetInt32(0);
				forma.Descricao = reader.GetString(1);
				formas.Add(forma);
			}
			reader.Close();

			return formas.ToArray();
		}

		
	}
}
