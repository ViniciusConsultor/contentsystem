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

    public int IdPedido
    {
        get
        {
            return (int)ViewState["Pedido"];
        }
        set
        {
            ViewState["Pedido"] = value;
        }
    }

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
    public void MostrarFornecedor()
    {
        string nome = null;
        string cnpj = null;
        string rz = null;
        ManterFornecedores f = new ManterFornecedores();
        ddlIDFornecedor.DataSource = f.ListarFornecedores(nome, rz, cnpj);
        ddlIDFornecedor.DataTextField = "NOME";
        ddlIDFornecedor.DataValueField = "IDFORNECEDOR";
        ddlIDFornecedor.DataBind();
    }
    public void Pesquisar(object sender, CommandEventArgs e)
    {
        this.Listar();
    }
    public void SelecionarPedido(object sender, CommandEventArgs e)
    {
        IdPedido = Int32.Parse((string)e.CommandArgument);
        RealizarCompra r = new RealizarCompra();
        r.IncluirCompra(IdPedido);
        ListarPedidos();
    }
}
