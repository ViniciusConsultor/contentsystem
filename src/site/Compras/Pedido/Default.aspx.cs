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
public partial class Compras_Pedido_Default : System.Web.UI.Page
{
    RealizarPedido pedido = new RealizarPedido();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListarEstoque();
        }
    }

    public void ListarEstoque()
    {
        this.rpListagem.DataSource = this.Listar();
        this.rpListagem.DataBind();
    }
    public Estoque[] Listar()
    {
        var estoque = pedido.ListarBaixoEstoque();
        return estoque;
    }
    protected void SelecionarProduto(object sender, CommandEventArgs e)
    {
    }

}
