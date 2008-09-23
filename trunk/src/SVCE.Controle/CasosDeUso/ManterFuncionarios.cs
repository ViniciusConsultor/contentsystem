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
        public Funcionario[] PesquisarFuncionarios()
        {
            BancoDeDados banco = new BancoDeDados();
            try
            {
                banco.Conectar();
                return Funcionario.Listar(banco);
            }
            finally
            {
                banco.Desconectar();
            }
        }
        public void IncluirFuncionario(Funcionario funcionario)
        {

        }

        
    }
}
