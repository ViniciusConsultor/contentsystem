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

public partial class Administrativo_Relatorios_SemEstoque : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.ListarRelatorioEstoque();
    }

    public ItemRelatorioProdutosSemEstoque[] Listar()
    {
        GeraRelatorio g = new GeraRelatorio();
        var item = g.ListarProdutosSemEstoque();
        return item;
    }

    public void ListarRelatorioEstoque()
    {
        this.rpItens.DataSource = this.Listar();
        this.rpItens.DataBind();
    }
}
