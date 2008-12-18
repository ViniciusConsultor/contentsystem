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

public partial class Administrativo_Relatorios_VolumeVendas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            this.Listagem();
    }

    public void Pesquisar(object sender, CommandEventArgs e)
    {
		if (!IsValid)
			return;
        this.Listagem();
    }

    public ItemRelatorioProdutosMaisVendidos[] Listar()
    {
        Nullable<DateTime> df = null;
        Nullable<DateTime> di = null;
        string periodo = null;
        GeraRelatorio g = new GeraRelatorio();
        if (txtdf.Text != "")
            df = DateTime.Parse(txtdf.Text);
        if (txtdi.Text != "")
            di = DateTime.Parse(txtdi.Text);



        if (df > DateTime.Today)
            df = DateTime.Today;

        if (di > DateTime.Today)
            di = DateTime.Today;


        if (rdbPeriodo.Items[0].Selected)
            periodo = rdbPeriodo.Items[0].Value;
        else if (rdbPeriodo.Items[1].Selected)
            periodo = rdbPeriodo.Items[1].Value;
        else if (rdbPeriodo.Items[2].Selected)
            periodo = rdbPeriodo.Items[2].Value;

        return g.ListarVolumeVendas(di, df, periodo);
    }
    public void Listagem()
    {
        this.rpListagem.DataSource = this.Listar();
        this.rpListagem.DataBind();
    }
}
