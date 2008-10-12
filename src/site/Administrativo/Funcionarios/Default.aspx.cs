﻿using System;
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

        MatriculaEdicao = 0;

        txtMatricula.Text = txtCPF.Text = txtLogin.Text = txtNome.Text = txtSenha.Text = txtSalario.Text = txtDataAdmissao.Text = null;
        rbPerfil.SelectedIndex = -1;


        txtLogin.Enabled = true;
        lblSenha.Text = "Senha";
        rqLogin.Enabled = true;
        rqSenha.Enabled = true;
        mv.ActiveViewIndex = 1;
    }
    protected void MostrarFormularioEdicao(object sender, CommandEventArgs e)
    {

        Funcionario funcionario = CarregarFuncionario(Int32.Parse((string)e.CommandArgument));

        this.txtNome.Text = funcionario.Nome;
        this.txtMatricula.Text = funcionario.Matricula.ToString();
        this.txtLogin.Text = funcionario.Login;
        this.txtCPF.Text = funcionario.CPF;
        this.rbPerfil.SelectedValue = funcionario.Perfil.ToString();
        this.txtSalario.Text = funcionario.Salario.ToString("N");
        this.txtDataAdmissao.Text = funcionario.DataAdmissao.ToString("d");


        txtLogin.Enabled = false;
        lblSenha.Text = "Alterar Senha";

        rqLogin.Enabled = false;
        rqSenha.Enabled = false;


        mv.ActiveViewIndex = 1;
    }

    private Funcionario PreencherFuncionario()
    {
        Funcionario funcionario = new Funcionario();
        funcionario.Matricula = MatriculaEdicao;
        funcionario.CPF = txtCPF.Text;
        funcionario.Nome = txtNome.Text;
        funcionario.Perfil = (Perfil)Enum.Parse(typeof(Perfil), rbPerfil.SelectedValue);
        funcionario.Salario = decimal.Parse(txtSalario.Text);
        funcionario.DataAdmissao = DateTime.Parse(txtDataAdmissao.Text);
        funcionario.Login = txtLogin.Text;
        funcionario.Senha = txtSenha.Text;

        return funcionario;
    }

    protected void ExcluirFuncionario(object sender, CommandEventArgs e)
    {
        MostrarFuncionarios( base.ExcluirFuncionario(Int32.Parse((string)e.CommandArgument)));
    }

    public void RetornarListagem(object sender, CommandEventArgs e)
    {
        mv.ActiveViewIndex = 0;
        MostrarFuncionarios(PesquisarFuncionarios());
    }
    public void SalvarFuncionario(object sender, CommandEventArgs e)
    {
        if (!IsValid)
            return;

        Funcionario funcionario = PreencherFuncionario();
        Funcionario[] listagem;
        if (MatriculaEdicao == 0)
        listagem =    IncluirFuncionario(funcionario);
        else
            listagem = AlterarFuncionario(funcionario);

        MostrarFuncionarios(listagem);
        mv.ActiveViewIndex = 0;
    }
}