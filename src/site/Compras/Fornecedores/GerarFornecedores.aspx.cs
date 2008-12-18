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

public partial class Compras_Fornecedores_GerarFornecedores : System.Web.UI.Page
{

    ManterFornecedores Controle = new ManterFornecedores();

    protected void Page_Load(object sender, EventArgs e)
    {
        ListarFornecedores();
    }



    private Fornecedor[] Filtrar()
    {
        string nome = null;
        string razaoSocial = null;
        string cnpj = null;

        var fornecedores = Controle.ListarFornecedores(nome, razaoSocial, cnpj);
        return fornecedores;
    }

    private void ListarFornecedores()
    {


        this.rpListagem.DataSource = this.Filtrar();
        this.rpListagem.DataBind();
    }
}
