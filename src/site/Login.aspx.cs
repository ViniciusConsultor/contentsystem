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



public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Logar(object sender, CommandEventArgs e)
    {
        if (IsValid)
        {
            ManterFuncionarios controle = new ManterFuncionarios();
            var funcionario = controle.AutenticarFuncionario(txtLogin.Text, txtSenha.Text);
            if (funcionario == null)
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "InvalidCredentials", "alert('Usuário inexistente ou senha inválida!');", true);
            else
            {
                FormsAuthentication.RedirectFromLoginPage(funcionario.Matricula.ToString(), false);
                
                
            }

            
        }
    }
}
