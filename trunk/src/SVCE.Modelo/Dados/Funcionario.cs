using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SVCE.Modelo.Dados
{
    public class Funcionario
    {
        public int Matricula { get { return matricula; } set { matricula = value; } }
        public string Nome { get { return nome; } set { nome = value; } }
        public string Login { get { return login; } set { login = value; } }
        public Perfil Perfil { get { return perfil; } set { perfil = value; } }
        public string CPF { get { return cpf; } set { cpf = value; } }
        public DateTime DataAdmissao { get { return dataAdmissao; } set { dataAdmissao = value; } }
        public decimal Salario { get { return salario; } set { salario = value; } }
        public Status Status { get { return Status; } set { this.status = value; } }




         int matricula;
         string nome;
         string login;
         Perfil perfil;
         string cpf;
         DateTime dataAdmissao;
         decimal salario;
         Status status;

        public static Funcionario[] Listar(BancoDeDados banco)
        {
            List<Funcionario> lista = new List<Funcionario>();
            SqlCommand cmd = banco.CriarComando("SELECT MATRICULA, NOME,LOGIN, ID_PERFIL, CPF, SALARIO, DATA_ADMISSAO, ID_STATUS FROM FUNCIONARIOS ORDER BY NOME", System.Data.CommandType.Text);
            SqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.Matricula = (int)reader["MATRICULA"];
                    funcionario.Nome = (string)reader["NOME"];
                    funcionario.CPF = (string)reader["CPF"];
                    funcionario.Login = (string)reader["LOGIN"];
                    funcionario.Salario = (decimal)reader["SALARIO"];
                    funcionario.DataAdmissao = (DateTime)reader["DATA_ADMISSAO"];
                    funcionario.Perfil = (Perfil)(int)reader["ID_PERFIL"];
                    funcionario.Status = (Status)(int)reader["ID_STATUS"];
                    lista.Add(funcionario);
                }

            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return lista.ToArray();
        }

        public void Incluir()
        {

        }
        public void Alterar()
        {

        }
        public static void Excluir(int matricula)
        {

        }
    }
}
