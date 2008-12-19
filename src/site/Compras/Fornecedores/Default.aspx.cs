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

public partial class Compras_Fornecedores_Default : System.Web.UI.Page
{

    ManterFornecedores Controle = new ManterFornecedores();


    public int IdFornecedor
    {
        get
        {
            return (int)ViewState["Fornecedor"];
        }
        set
        {
            ViewState["Fornecedor"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        txtTelefone.Attributes.Add("onkeypress", "return formataTEL(event);");
        txtCNPJ.Attributes.Add("onkeypress", "return formataCNPJ(event);");
        txtFiltroCNPJ.Attributes.Add("onkeypress", "return formataCNPJ(event);");

        if (!IsPostBack)
        {
            ListarFornecedores();
        }
    }

    private Fornecedor[] Filtrar()
    {
        string nome = txtFiltroNome.Text;
        string razaoSocial = txtFiltroRazaoSocial.Text;
        string cnpj = txtFiltroCNPJ.Text;

        nome = nome.Trim();
        razaoSocial = razaoSocial.Trim();
        cnpj = cnpj.Trim();

        if (nome == "")
            nome = null;
        if (razaoSocial == "")
            razaoSocial = null;
        if (cnpj == "")
            cnpj = null;

        var fornecedores = Controle.ListarFornecedores(nome, razaoSocial, cnpj);
        return fornecedores;
    }

    private void ListarFornecedores()
    {
        

        this.rpListagem.DataSource = this.Filtrar();
        this.rpListagem.DataBind();
    }
    protected void ChamarListagem(object sender, CommandEventArgs e)
    {
        ListarFornecedores();
    }

    protected void MostrarFormularioEdicao(object sender, CommandEventArgs e)
    {




        
            IdFornecedor  = Int32.Parse((string)e.CommandArgument);
        var fornecedor = (from f in Filtrar()
                          where IdFornecedor == f.IdFornecedor
                          select f).First();

        this.txtCNPJ.Text = fornecedor.CNPJ;
        this.txtContato.Text = fornecedor.NomeContato;
        this.txtEmail.Text = fornecedor.Email;
        this.txtEndereco.Text = fornecedor.Endereco;
        this.txtNome.Text = fornecedor.Nome;
        this.txtRazaoSocial.Text = fornecedor.RazaoSocial;
        this.txtTelefone.Text = fornecedor.Telefone;


        mv.ActiveViewIndex = 1;

    }
    protected void ExcluirFornecedor(object sender, CommandEventArgs e)
    {

        Controle.ExcluirFornecedor(Int32.Parse((string)e.CommandArgument));
        ListarFornecedores();
    }
    protected void MostrarFormularioInclusao(object sender, CommandEventArgs e)
    {


        IdFornecedor = 0;

        txtNome.Text = txtCNPJ.Text = txtContato.Text = txtEmail.Text = txtEndereco.Text = txtRazaoSocial.Text = txtTelefone.Text = "";



        mv.ActiveViewIndex = 1;
    }

    protected void RetornarListagem(object sender, CommandEventArgs e)
    {
        mv.ActiveViewIndex = 0;
        ListarFornecedores();
    }
    protected void SalvarFornecedor(object sender, CommandEventArgs e)
    {
        if (!IsValid)
            return;

        if (IdFornecedor == 0)
        {

            Controle.IncluirFornecedor(txtNome.Text, txtRazaoSocial.Text, txtCNPJ.Text, txtEndereco.Text, txtTelefone.Text, txtEmail.Text, txtContato.Text);
        }
        else
            Controle.AlterarFornecedor(IdFornecedor, txtNome.Text, txtRazaoSocial.Text, txtCNPJ.Text, txtEndereco.Text, txtTelefone.Text, txtEmail.Text, txtContato.Text);
        RetornarListagem(sender, e);
    }
}
