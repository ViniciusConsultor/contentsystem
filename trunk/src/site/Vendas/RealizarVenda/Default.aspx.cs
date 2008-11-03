using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SVCE.Controle.CasosDeUso;

public partial class Vendas_RealizarVenda_Default : System.Web.UI.Page
{

	private RealizarVenda controle;


	protected void Page_Load(object sender, EventArgs e)
	{
		controle = new RealizarVenda();
	}

	protected void ProsseguirParaFormasPagamento(object sender, CommandEventArgs e)
	{
		mv.ActiveViewIndex = 1;
		rblFormasPagamento.DataSource = controle.ListarFormasPagamento();
		rblFormasPagamento.DataBind();
	}
	protected void SalvarVenda(object sender, CommandEventArgs e)
	{

		mv.ActiveViewIndex = 2;
	}

}
