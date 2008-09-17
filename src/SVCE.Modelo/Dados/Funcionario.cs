using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVCE.Modelo.Dados
{
    public class Funcionario
    {
        //public int Matricula { get; set; }
        //public string Nome { get; set; }
        //public string Login { get; set; }
        //public Perfil IdPerfil { get; set; }
        //public string CPF { get; set; }
        //public DateTime DataAdmissao { get; set; }
        //public decimal Salario { get; set; }
        //public Status Status { get; set; }




        public int Matricula;
        public string Nome;
        public string Login;
        public Perfil IdPerfil;
        public string CPF;
        public DateTime DataAdmissao;
        public decimal Salario;
        public Status Status;

        public static Funcionario[] Listar()
        {
            return null;
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
