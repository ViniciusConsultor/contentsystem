using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SVCE.Modelo.Dados;
using System.Data;

namespace SVCE.Modelo.Dados
{
    public class BancoDeDados
    {
        private SqlConnection conexao;
        private SqlTransaction transacao;


        public static BancoDeDados Instancia
        {
            get
            {
                return null;
            }
        }

        public void Conectar()
        {

        }
        public void Desconectar()
        {

        }
        public void IniciarTransacao()
        {

        }
        public void ConcluirTransacao()
        {

        }
        public void AbortarTransacao()
        {

        }

        
        
        
       
    }
}
