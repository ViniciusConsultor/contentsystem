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

public partial class Compras_Produtos_GerarProdutos : System.Web.UI.Page
{
    ManterProduto produto = new ManterProduto();

    protected void Page_Load(object sender, EventArgs e)
    {
        ListaProdutos();
    }


    public void ListaProdutos()
    {
        this.rpListagem.DataSource = this.Listar();
        this.rpListagem.DataBind();
    }
    public Produto[] Listar()
    {
        Nullable<int> codInterno = null;
        string codExterno = null; 
        string  nome = null; 
        string nForncedor = null;


        var produtos = produto.Listar(codInterno, codExterno, nome, nForncedor);

        return produtos;

    }
}
