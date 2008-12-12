using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using SVCE.Controle.CasosDeUso;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            int matricula = Int32.Parse(Page.User.Identity.Name);
            ManterFuncionarios controle = new ManterFuncionarios();
            var funcionario = controle.CarregarFuncionario(matricula);
            if (funcionario == null)
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
            switch (funcionario.Perfil)
            {
                case SVCE.Modelo.Dados.Perfil.Master:
                    pnlAdministrativo.Visible = true;
                    pnlCompras.Visible = true;
                    pnlEstoque.Visible = true;
                    pnlVendas.Visible = true;
                    break;
                case SVCE.Modelo.Dados.Perfil.Administrativo:
                    pnlAdministrativo.Visible = true;
                    pnlEstoque.Visible = true;
                    break;
                case SVCE.Modelo.Dados.Perfil.Compras:
                    pnlCompras.Visible = true;
                    pnlEstoque.Visible = true;
                    break;
                case SVCE.Modelo.Dados.Perfil.Estoque:
                    pnlEstoque.Visible = true;
                    break;
                case SVCE.Modelo.Dados.Perfil.Vendas:
                    pnlVendas.Visible = true;
                    pnlEstoque.Visible = true;
                    break;
            }

        }


    }
	protected void Logout(object sender, CommandEventArgs e)
	{
		FormsAuthentication.SignOut();
		Session.Abandon();
		Response.Redirect("~/Login.aspx");
	}
}
