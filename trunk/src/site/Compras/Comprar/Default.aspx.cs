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
using System.Collections.Generic;

public partial class Compras_Comprar_Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        ListarPedidos();
    }

    public void ListarPedidos()
    {
        this.rpListagem.DataSource = this.Listar();
        rpListagem.DataBind();
    }
    public PedidoCompra[] Listar()
    {
        RealizarCompra r = new RealizarCompra();
        Nullable<int> idProduto = 0;
        
        if (txtProduto.Text != "")
            idProduto = Int32.Parse(txtProduto.Text);

        if(idProduto == 0)
            idProduto = null;


        var produto = r.Listarpedido(idProduto);
        return produto;
    }
}
