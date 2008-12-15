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

public partial class Administrativo_Admin_Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Bind();
    }

    protected void ExcluirPagamento(object sender, CommandEventArgs e)
    {
        int id = Int32.Parse((string)e.CommandArgument);
        Administrar a = new Administrar();
        a.RemoverPagamento(id);
        Bind();
    }
    public void Bind()
    {
        Administrar a = new Administrar();
        this.rpListagem.DataSource = a.Listar();
        rpListagem.DataBind();
    }
    protected void Cadastra(object sender, CommandEventArgs e)
    {
        string descricao = txtFormapagamento.Text;
        Administrar a = new Administrar();
        a.IncluirPagamento(descricao);
        txtFormapagamento.Text = "";
        Bind();
    }

}
