using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVCE.Modelo.Dados
{
    public class Funcionario
    {
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public Perfil IdPerfil { get; set; }
        public string CPF { get; set; }
        public DateTime DataAdmissao { get; set; }
        public decimal Salario { get; set; }
        public Status Status { get; set; }
    }
}
