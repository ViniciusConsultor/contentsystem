using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVCE.Modelo.Dados
{
	public class FormaPagamento
	{

		public int ID { get; set; }
		public string Descricao { get; set; }

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
