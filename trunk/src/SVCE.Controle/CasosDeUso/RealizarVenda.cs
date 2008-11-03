using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SVCE.Modelo.Dados;

namespace SVCE.Controle.CasosDeUso
{
	public class RealizarVenda
	{


		public FormaPagamento[] ListarFormasPagamento()
		{
			BancoDeDados banco = new BancoDeDados();
			try
			{
				banco.Conectar();
				return FormaPagamento.Listar(banco);
			}
			finally
			{
				banco.Desconectar();
			}
		}
	}
}
