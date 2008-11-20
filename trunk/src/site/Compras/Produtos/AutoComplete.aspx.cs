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

public partial class Compras_Produtos_AutoComplete : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{


		var filtro = Request["filtro"];
		var controle = new ManterProduto();
		var produtos = controle.Listar(null, null, filtro,null);


		Response.Write("<ul>");

		foreach (var produto in produtos)
		{
			Response.Write("<li>" + produto.CodigoInterno + "<span class=\"informal\"> - " + produto.Nome + "</span></li>");
		}
		Response.Write("</ul>");

		Response.End();

	}
}
