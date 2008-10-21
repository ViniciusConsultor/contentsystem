using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SVCE.Modelo.Dados;

namespace SVCE.Controle.CasosDeUso
{
    public class ManterProduto
    {
        BancoDeDados b = new BancoDeDados();
        public Produto[] Listar(int? codigoInterno, string codigoExterno, string nome)
        {
            try
            {
                b.Conectar();
                return Produto.Listar(codigoInterno, codigoExterno, nome);
            }
            finally
            {
                b.Desconectar();
            }
        }
        public void Alterar(int codigoInterno,string codigoExterno,int idFornecedor, string nome, decimal precovenda, int quantidade,Status status)
        {
            Produto p = new Produto();
            p.CodigoInterno = codigoInterno;
            p.CodigoExterno = codigoExterno;
            p.IdFornecedor = idFornecedor;
            p.Nome = nome;
            p.PrecoVenda = precovenda;
            p.QuantidadeMinima = quantidade;
            p.Status = status;

            try
            {
                b.Conectar();
                p.Alterar();
               
            }
            finally
            {
                b.Desconectar();
            }
        }
        public void Incluir(int codigoInterno, string codigoExterno, int idFornecedor, string nome, decimal precovenda, int quantidade, Status status)
        {
            Produto p = new Produto();
            p.CodigoInterno = codigoInterno;
            p.CodigoExterno = codigoExterno;
            p.IdFornecedor = idFornecedor;
            p.Nome = nome;
            p.PrecoVenda = precovenda;
            p.QuantidadeMinima = quantidade;
            p.Status = status;
            try
            {
                b.Conectar();
                p.Incluir();
            }
            finally
            {
                b.Desconectar();
            }
        }

        public void Excluir(int codigoExterno)
        {
            try
            {
                b.Conectar();
                Produto.Excluir(codigoExterno);
            }
            finally
            {
                b.Desconectar();
            }
        }
    }
}
