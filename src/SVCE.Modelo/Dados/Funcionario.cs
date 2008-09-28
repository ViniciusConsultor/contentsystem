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
        public string Senha { get { return senha; } set { senha = value; } }
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
        string senha;

        public static Funcionario[] Listar(BancoDeDados banco, FiltrosFuncionario filtros)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            string clausulaWhere = " WHERE ID_STATUS = 1 ";
            if (filtros != null)
            {
                if (filtros.Matricula != null)
                {
                    clausulaWhere += " AND MATRICULA = @MATRICULA ";
                    listaParametros.Add(new SqlParameter("@MATRICULA", filtros.Matricula));
                }
            }

            List<Funcionario> lista = new List<Funcionario>();
            SqlCommand cmd = banco.CriarComando(string.Format("SELECT MATRICULA, NOME,LOGIN, ID_PERFIL, CPF, SALARIO, DATA_ADMISSAO FROM FUNCIONARIOS {0} ORDER BY NOME", clausulaWhere), System.Data.CommandType.Text);
            cmd.Parameters.AddRange(listaParametros.ToArray());
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
                    funcionario.Status = Status.Ativo;
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

        public void Incluir(BancoDeDados banco)
        {
            string sql = @"INSERT INTO FUNCIONARIOS (NOME, CPF, SALARIO, DATA_ADMISSAO, LOGIN, SENHA, ID_PERFIL, ID_STATUS) VALUES (@NOME, @CPF, @SALARIO, @DATA_ADMISSAO, @LOGIN, @SENHA, @ID_PERFIL,1); SELECT @MATRICULA = SCOPE_IDENTITY()";
            SqlCommand cmd = banco.CriarComando(sql, System.Data.CommandType.Text);
            AtribuirParametros(cmd);

            


            int count = cmd.ExecuteNonQuery();
            if (count == 0)
                throw new Exception("Não foi possível incluir o funcionário.");
            else
                matricula = Convert.ToInt32(cmd.Parameters["@MATRICULA"].Value);
        }
        private void AtribuirParametros(SqlCommand cmd)
        {
            cmd.Parameters.Add(new SqlParameter("@MATRICULA", Matricula));
            cmd.Parameters.Add(new SqlParameter("@NOME", Nome));
            cmd.Parameters.Add(new SqlParameter("@CPF", CPF));
            cmd.Parameters.Add(new SqlParameter("@SALARIO", Salario));
            cmd.Parameters.Add(new SqlParameter("@DATA_ADMISSAO", DataAdmissao));
            cmd.Parameters.Add(new SqlParameter("@ID_PERFIL",(int) Perfil));
            if (Matricula == 0)
            {
                cmd.Parameters["@MATRICULA"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new SqlParameter("@LOGIN", Login));
                cmd.Parameters.Add(new SqlParameter("@SENHA", Senha));
            }
        }
        public void Alterar(BancoDeDados banco)
        {
            string sql = @"UPDATE FUNCIONARIOS SET NOME = @NOME, CPF=@CPF, SALARIO=@SALARIO, DATA_ADMISSAO = @DATA_ADMISSAO WHERE MATRICULA = @MATRICULA";
            SqlCommand cmd = banco.CriarComando(sql, System.Data.CommandType.Text);
            AtribuirParametros(cmd);


            int count = cmd.ExecuteNonQuery();
            if (count == 0)
                throw new Exception("Nenhum funcionário atualizado!");

        }
        public static void Excluir(BancoDeDados banco, int matricula)
        {
            string sql = @"UPDATE FUNCIONARIOS SET ID_STATUS = 2  WHERE MATRICULA = @MATRICULA";
            SqlCommand cmd = banco.CriarComando(sql, System.Data.CommandType.Text);
            cmd.Parameters.Add(new SqlParameter("@MATRICULA", matricula));
            int count = cmd.ExecuteNonQuery();
            if (count == 0)
                throw new Exception("O funcionário que você deseja excluir não existe!");
            
        }
    }
}
