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

public partial class Administrativo_Funcionarios_GerarFuncionarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ManterFuncionarios Controle = new ManterFuncionarios();
        MostrarFuncionarios(Controle.PesquisarFuncionarios());
    }

    public void MostrarFuncionarios(Funcionario[] funcionarios)
    {
        rpFuncionarios.DataSource = funcionarios;
        rpFuncionarios.DataBind();
    }
    protected string TraduzirPerfil(Perfil perfil)
    {
        switch (perfil)
        {
            case Perfil.Master:
                return "Master";
            case Perfil.Administrativo:
                return "Administrativo";
            case Perfil.Compras:
                return "Setor de Compras";
            case Perfil.Estoque:
                return "Estoquista";
            case Perfil.Vendas:
                return "Vendedor";
            default:
                return "";
        }
    }
}
