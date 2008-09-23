using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SVCE.Modelo.Dados;
using System.Data;
using System.Configuration;

namespace SVCE.Modelo.Dados
{
    public class BancoDeDados
    {
        private SqlConnection conexao;
        private SqlTransaction transacao;
        public void Conectar()
        {
            this.conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString);
            conexao.Open();
        }
        public void Desconectar()
        {
            if (conexao != null)
                conexao.Close();
        }
        public void IniciarTransacao()
        {
            transacao =  conexao.BeginTransaction();
        }
        public void ConcluirTransacao()
        {
            transacao.Commit();
        }
        public void AbortarTransacao()
        {
            transacao.Rollback();
        }

        public SqlCommand CriarComando(string sql, CommandType tipoComando)
        {
            var cmd = conexao.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = tipoComando;
            return cmd;
        }
        
        
       
    }
}
