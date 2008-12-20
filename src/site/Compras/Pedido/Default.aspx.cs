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

        txtQuantidade.Attributes.Add("onkeypress", "return formataNUMBER(event)");
        if (!IsPostBack)
        {
            BindProdutosEmEstoque();


            int matricula = Int32.Parse(Page.User.Identity.Name);
            ManterFuncionarios m = new ManterFuncionarios();
            var func = m.CarregarFuncionario(matricula);
            if (func.Perfil == Perfil.Estoque || func.Perfil == Perfil.Master || func.Perfil == Perfil.Compras)
            {
                lblAbaixoestoque.Visible = true;
                ListarEstoque();
            }
            else
            {
                lblAbaixoestoque.Visible = false;
            }

            Produtos = new List<ItemTransacao>();
        }
    }

    public void ListarEstoque()
    {
        this.mv.ActiveViewIndex = 0;
        this.rpListagem.DataSource = this.Listar();
        this.rpListagem.DataBind();
    }
    public void BindProdutosEmEstoque()
    {
        this.mv.ActiveViewIndex = 0;
        this.rpEstoque.DataSource = this.ListarProdutosEmEstoque();
        this.rpEstoque.DataBind();
    }
    public Estoque[] Listar()
    {
        var estoque = pedido.ListarBaixoEstoque();
        return estoque;
    }
    public Estoque[] ListarProdutosEmEstoque()
    {
        var estoque = pedido.ListarEstoque();
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
        BindProdutosEmEstoque();
    }
    protected void SalvarPedido(object sender, CommandEventArgs e)
    {
        SalvarProduto();
        ListarEstoque();
        BindProdutosEmEstoque();
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
        int idF =Int32.Parse(ddlIDFornecedor.SelectedValue);
        int matricula = Int32.Parse(Page.User.Identity.Name);

     
        RealizarVenda controle = new RealizarVenda();
        var produto =controle.BuscarProduto(cod);

        var sequencial = 0;

        if (produto != null)
        {
            decimal vlTotal = produto.PrecoVenda * quant;   
            var item = new ItemTransacao() { IdProduto = produto.CodigoInterno, Sequencial = sequencial, NomeProduto = produto.Nome, PrecoUnitario = produto.PrecoVenda, Quantidade = quant };
            List<ItemTransacao> it = new List<ItemTransacao>();
            it.Add(item);
            pedido.IncluirPedido(idF, matricula, vlTotal, it); 
        }

    }

}
