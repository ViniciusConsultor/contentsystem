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

public partial class Administrativo_Funcionarios_Default : ManterFuncionarios
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!IsPostBack)
        {
            MostrarFuncionarios(PesquisarFuncionarios());
        }

    }
    public void MostrarFuncionarios(Funcionario[] funcionarios)
    {
        rpFuncionarios.DataSource = funcionarios;
        rpFuncionarios.DataBind();
    }
    protected void MostrarFormularioInclusao(object sender, CommandEventArgs e)
    {
        mv.ActiveViewIndex = 1;
    }
    public void RetornarListagem(object sender, CommandEventArgs e)
    {
        mv.ActiveViewIndex = 0;
        MostrarFuncionarios(PesquisarFuncionarios());
    }
    public void SalvarFuncionario(object sender, CommandEventArgs e)
    {
        RetornarListagem(sender, e);
    }
}
