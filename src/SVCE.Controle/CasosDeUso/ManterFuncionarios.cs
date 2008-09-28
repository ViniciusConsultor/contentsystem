using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SVCE.Modelo.Dados;
using System.Web.UI;

namespace SVCE.Controle.CasosDeUso
{
    public class ManterFuncionarios : Page
    {


        protected int MatriculaEdicao
        {
            get
            {
                return (int)ViewState["MatriculaEdicao"];
            }
            set
            {
                ViewState["MatriculaEdicao"] = value;
            }
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsPostBack)
                MatriculaEdicao = 0;
        }

        private Funcionario[] ExecutarConsultaFuncionario(FiltrosFuncionario filtros)
        {
            BancoDeDados banco = new BancoDeDados();
            try
            {
                banco.Conectar();

                return Funcionario.Listar(banco, filtros);
            }
            finally
            {
                banco.Desconectar();
            }
        }

        public Funcionario[] PesquisarFuncionarios()
        {
            return ExecutarConsultaFuncionario(null);
        }
        public Funcionario CarregarFuncionario(int matricula)
        {
            FiltrosFuncionario filtros = new FiltrosFuncionario() { Matricula = matricula };
            Funcionario[] selecionados = ExecutarConsultaFuncionario(filtros);
            if (selecionados.Length == 0)
                throw new Exception(string.Format("Funcionário não encontrado: {0}", matricula));

            Funcionario funcionario = selecionados[0];
            MatriculaEdicao = funcionario.Matricula;

            return funcionario;
        }
        public Funcionario[] IncluirFuncionario(Funcionario funcionario)
        {
            BancoDeDados banco = new BancoDeDados();
            try
            {
                banco.Conectar();
                funcionario.Incluir(banco);
                return Funcionario.Listar(banco, new FiltrosFuncionario());
            }
            finally
            {
                banco.Desconectar();
            }
        }

        public Funcionario[] AlterarFuncionario(Funcionario funcionario)
        {
            BancoDeDados banco = new BancoDeDados();
            try
            {
                banco.Conectar();
                funcionario.Alterar(banco);
                return Funcionario.Listar(banco, new FiltrosFuncionario());
            }
            finally
            {
                banco.Desconectar();
            }
        }
        public Funcionario[] ExcluirFuncionario(int matricula)
        {
            BancoDeDados banco = new BancoDeDados();
            try
            {
                banco.Conectar();
                Funcionario.Excluir(banco, matricula);
                return Funcionario.Listar(banco, new FiltrosFuncionario());
            }
            finally
            {
                banco.Desconectar();
            }
        }


    }
}
