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

public partial class Compras_Produtos_Default : System.Web.UI.Page
{
    ManterProduto produto = new ManterProduto();

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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListaProdutos();
        }
    }

    public void ListaProdutos()
    {
        this.rpListagem.DataSource = this.Listar();
        this.rpListagem.DataBind();
    }
    public Produto[] Listar()
    {
        Nullable<int> codInterno = null;
        string codExterno, nome;

        nome = txtNome.Text;
        codExterno = txtCodExterno.Text;
        if (txtCodInterno.Text != "")
            codInterno = Convert.ToInt32(txtCodInterno.Text);

        if (nome == "")
            nome = null;
        if (codExterno == "")
            codExterno = null;
        if (codInterno == 0)
            codInterno = null;
        
        var produtos = produto.Listar(codInterno, codExterno, nome);

        return produtos;

    }
    protected void ChamarListagem(object sender, CommandEventArgs e)
    {
        ListaProdutos();
    }
     protected void MostrarFormularioEdicao(object sender, CommandEventArgs e)
    {

    }
    protected void ExcluirProduto(object sender, CommandEventArgs e)
    {
        int auxCod =Int32.Parse((string)e.CommandArgument);
        produto.Excluir(auxCod);
        RetornarListagem(sender, e);
    }
    protected void MostrarFormularioInclusao(object sender, CommandEventArgs e)
    {
        Clean();
        mvprodutos.ActiveViewIndex = 1;
    }

    protected void RetornarListagem(object sender, CommandEventArgs e)
    {
        mvprodutos.ActiveViewIndex = 0;
        ListaProdutos();
    }
    protected void SalvarProduto(object sender, CommandEventArgs e)
    {
        if (!IsValid)
            return;


        int auxID = Convert.ToInt32(txtCadastroID.Text);
        int auxQuant= Convert.ToInt32(txtCadastroQuantidade.Text);
        decimal auxPreco = Convert.ToDecimal(txtPrecoVenda.Text);

        if(CodInterno == 0)
            produto.Incluir(txtCadastroExterno.Text, auxID, txtCadastroNome.Text, auxPreco, auxQuant);
        else
            produto.Alterar(CodInterno, txtCodExterno.Text, auxID,txtCadastroNome.Text, auxPreco, auxQuant);
        RetornarListagem(sender, e);
    }

    public void Clean()
    {
        CodInterno = 0;
        txtCadastroExterno.Text = txtCadastroID.Text = txtCadastroNome.Text = txtCodExterno.Text = txtCodInterno.Text = txtNome.Text = txtPrecoVenda.Text = txtCadastroQuantidade.Text = "";
    }
}
 

