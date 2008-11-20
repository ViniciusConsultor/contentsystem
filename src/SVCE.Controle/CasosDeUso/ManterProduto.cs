using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SVCE.Modelo.Dados;

namespace SVCE.Controle.CasosDeUso
{
    public class ManterProduto
    {
        
        public Produto[] Listar(int? codigoInterno, string codigoExterno, string nome, string nFornecedor)
        {
            BancoDeDados b = new BancoDeDados();
            try
            {
                b.Conectar();
                return Produto.Listar(b, codigoInterno, codigoExterno, nome,nFornecedor);
            }
            finally
            {
                b.Desconectar();
            }
        }
        public void Alterar(int codigoInterno,string codigoExterno,int idFornecedor, string nome, decimal precovenda, int quantidade)
        {
            BancoDeDados b = new BancoDeDados();
            Produto p = new Produto();
            p.CodigoInterno = codigoInterno;
            p.CodigoExterno = codigoExterno;
            p.IdFornecedor = idFornecedor;
            p.Nome = nome;
            p.PrecoVenda = precovenda;
            p.QuantidadeMinima = quantidade;

            try
            {
                b.Conectar();
                p.Alterar(b);
               
            }
            finally
            {
                b.Desconectar();
            }
        }
        public void Incluir(string codigoExterno, int idFornecedor, string nome, decimal precovenda, int quantidade)
        {
            BancoDeDados b = new BancoDeDados();
            Produto p = new Produto();
            p.CodigoExterno = codigoExterno;
            p.IdFornecedor = idFornecedor;
            p.Nome = nome;
            p.PrecoVenda = precovenda;
            p.QuantidadeMinima = quantidade;
            try
            {
                b.Conectar();
                p.Incluir(b);
            }
            finally
            {
                b.Desconectar();
            }
        }

        public void Excluir(int cod)
        {
            BancoDeDados b = new BancoDeDados();
            try
            {
                b.Conectar();
                Produto.Excluir(b,cod);
            }
            finally
            {
                b.Desconectar();
            }
        }
    }
}
