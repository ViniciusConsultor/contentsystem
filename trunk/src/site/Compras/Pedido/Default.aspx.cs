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

public partial class Compras_Pedido_Default : System.Web.UI.Page
{
    RealizarPedido pedido = new RealizarPedido();

    public int CodInterno
    {
        get
        {
            return (int)ViewState["CodInterno"];
        }
        set
        {
            ViewState["CodInterno"] = value;
        }
    }
    public List<ItemTransacao> Produtos
    {
        get
        {
            return (List<ItemTransacao>)ViewState["Produtos"];
        }
        set 
        { 
            ViewState["Produtos"] = value; 
        }
    }

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
        CodInterno = Int32.Parse((string)e.CommandArgument);
        var cod = (from f in Listar()
                   where CodInterno == f.codInterno
                   select f).First();
        MostrarFornecedor();
        ddlIDFornecedor.SelectedValue = cod.idFornecedor.ToString();
        txtcodInterno.Text = cod.codInterno.ToString();
        txtNome.Text = cod.nome;
        txtQuantidade.Text = cod.qtCompra.ToString();
        mv.ActiveViewIndex = 1;
    }
    protected void RetornarListagem(object sender, CommandEventArgs e)
    {
        ListarEstoque();
    }
    protected void SalvarPedido(object sender, CommandEventArgs e)
    {

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
    public void SalvarProduto()
    {
        int cod = Int32.Parse(txtcodInterno.Text);
        int quant = Int32.Parse(txtQuantidade.Text);

        var itens = (from f in Produtos where f.IdProduto == cod select f);

        if (itens.Count() > 0)
        {
            
        }

    }

}
