using System.Collections.Generic;
using System.Data.SqlClient;
using System;
namespace SVCE.Modelo.Dados
{
	public class MotivoTroca
	{
		#region Atributos e Enumerados
		#endregion

		#region Construtores e Destrutores
		#endregion

		#region Sub-Classes e Estruturas
		#endregion

		#region Propriedades

		public int IdMotivoTroca { get; set; }
		public string Descricao { get; set; }



		#endregion

		#region  Eventos
		#endregion

		#region Métodos
        public void Inserir(BancoDeDados b)
        {
            string sql = @"INSERT INTO MOTIVOS_TROCA (DESCRICAO) VALUES(@DESCRICAO)";
            SqlCommand cmd = b.CriarComando(sql, System.Data.CommandType.Text);
            cmd.Parameters.Add(new SqlParameter("@DESCRICAO", Descricao));
            int count = cmd.ExecuteNonQuery();
            if (count == 0)
                throw new Exception("Não foi possível incluir o motivo.");
        }

        public void Remover(BancoDeDados b)
        {
            string sql = @"DELETE FROM MOTIVOS_TROCA WHERE ID_MOTIVO = @IDMOTIVO";
            SqlCommand com = b.CriarComando(sql, System.Data.CommandType.Text);
            com.Parameters.Add(new SqlParameter("@IDMOTIVO", IdMotivoTroca));
            int count = com.ExecuteNonQuery();
            if (count == 0)
                throw new Exception("Motivo inexistente!");
        }

		public static MotivoTroca[] Listar(BancoDeDados banco)
		{
			List<MotivoTroca> lista = new List<MotivoTroca>();

			string sql = @"select*  from motivos_troca";
			var cmd = banco.CriarComando(sql, System.Data.CommandType.Text);
			var reader = cmd.ExecuteReader();
			try
			{
				while (reader.Read())
				{
					var item = new MotivoTroca();
					item.IdMotivoTroca = reader.GetInt32(0);
					item.Descricao = reader.GetString(1);
					lista.Add(item);
				}
			}
			finally
			{
				reader.Close();
			}
			return lista.ToArray();
		}

		#endregion
	}
}
