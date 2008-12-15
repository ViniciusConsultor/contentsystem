using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SVCE.Modelo.Dados;

namespace SVCE.Controle.CasosDeUso
{
    public class Administrar
    {
        #region FORMAPAGAMENTO
        public FormaPagamento[] Listar()
        {
            BancoDeDados b = new BancoDeDados();
            try
            {
                b.Conectar();
                return FormaPagamento.Listar(b);
            }
            finally
            {
                b.Desconectar();
            }
        }

        public void IncluirPagamento(string descricao)
        {
            BancoDeDados b = new BancoDeDados();
            try
            {
                b.Conectar();
                FormaPagamento f = new FormaPagamento();
                f.Descricao = descricao;
                f.Inserir(b);
            }
            finally
            {
                b.Desconectar();
            }
        }

        public void RemoverPagamento(int id)
        {
            BancoDeDados b = new BancoDeDados();
            try
            {
                b.Conectar();
                FormaPagamento f = new FormaPagamento();
                f.ID = id;
                f.Remover(b);
            }
            finally
            {
                b.Desconectar();
            }
        }
        #endregion

        #region MOTIVOTROCA
        public void IncluirMotivo(string descricao)
        {
            BancoDeDados b = new BancoDeDados();
            try
            {
                b.Conectar();
                MotivoTroca m = new MotivoTroca();
                m.Descricao = descricao;
                m.Inserir(b);
            }
            finally
            {
                b.Desconectar();
            }
        }
        public void RemoverMotivo(int id)
        {
            BancoDeDados b = new BancoDeDados();
            try
            {
                b.Conectar();
                MotivoTroca m = new MotivoTroca();
                m.IdMotivoTroca = id;
                m.Remover(b);
            }
            finally
            {
                b.Desconectar();
            }
        }
        #endregion
    }
}
