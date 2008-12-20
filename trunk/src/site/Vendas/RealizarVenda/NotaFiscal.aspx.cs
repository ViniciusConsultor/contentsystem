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

public partial class Vendas_RealizarVenda_NotaFiscal : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		RealizarVenda controle = new RealizarVenda();
		DataSet ds = controle.BuscarDadosNotaFiscal(Int32.Parse(Request["v"]));


		this.rpHeader.DataSource = ds.Tables[0];
		this.rpItens.DataSource = ds.Tables[1];
		this.DataBind();





	}

    public string ValidaNotafiscal(object x)
    {
        int aux = 1 ;
        if (x != null)
            aux = Convert.ToInt32(x);

        if (aux == 0)
        {
            return "TROCA";
        }
        else
        {
            return Eval("FORMA_PAGAMENTO").ToString();
        }
    }
}
