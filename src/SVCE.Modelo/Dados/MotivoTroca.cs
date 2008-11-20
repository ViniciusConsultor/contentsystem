using System.Collections.Generic;
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
