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
using SVCE.Modelo.Dados;

public partial class Administrativo_Relatorios_MaisVendido : System.Web.UI.Page
{
    //GeraRelatorio g = new GeraRelatorio();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Listagem();
        }
    }

    public void Pesquisar(object sender, CommandEventArgs e)
    {
		if (!Page.IsValid)
			return;
        this.Listagem();
    }

    public void Listagem()
    {
        this.rpListagem.DataSource = this.Listar();
        this.rpListagem.DataBind();
    }

    public ItemRelatorioProdutosMaisVendidos[] Listar()
    {

		

        GeraRelatorio g = new GeraRelatorio();
        Nullable<DateTime> df = null;
        Nullable<DateTime> di = null;
        if(txtdi.Text != "")
            di = DateTime.Parse(txtdi.Text);
        if (txtdf.Text != "")
            df = DateTime.Parse(txtdf.Text);

        var maisVendido = g.ListarProdutosMaisVendido(df, di);
        return maisVendido;

    }

}
