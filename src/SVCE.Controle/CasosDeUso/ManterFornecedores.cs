using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SVCE.Modelo.Dados;

namespace SVCE.Controle.CasosDeUso
{
    public class ManterFornecedores
    {


        public Fornecedor[] ListarFornecedores(string nome, string razaoSocial, string cnpj)
        {
            BancoDeDados banco = new BancoDeDados();
            try
            {
                banco.Conectar();
                return Fornecedor.Listar(banco, nome, razaoSocial, cnpj);
            }
            finally
            {
                banco.Desconectar();
            }
        }

        public void ExcluirFornecedor(int id_fornecedor)
        {
            BancoDeDados banco = new BancoDeDados();
            try
            {
                banco.Conectar();
                Fornecedor.Excluir(banco, id_fornecedor);
            }
            finally
            {
                banco.Desconectar();
            }
        }

        public void IncluirFornecedor(string nome, string razaoSocial, string cnpj, string endereco, string telefone, string email, string contato)
        {


            Fornecedor f = new Fornecedor();
            f.CNPJ = cnpj;
            f.Email = email;
            f.Endereco = endereco;
            f.Nome = nome;
            f.NomeContato = contato;
            f.RazaoSocial = razaoSocial;
            f.Telefone = telefone;

            BancoDeDados banco = new BancoDeDados();
            try
            {
                banco.Conectar();
                f.Incluir(banco);
            }
            finally
            {
                banco.Desconectar();
            }
        }

        public void AlterarFornecedor(int id_fornecedor, string nome, string razaoSocial, string cnpj, string endereco, string telefone, string email, string contato)
        {


            Fornecedor f = new Fornecedor();
            f.CNPJ = cnpj;
            f.Email = email;
            f.Endereco = endereco;
            f.Nome = nome;
            f.NomeContato = contato;
            f.RazaoSocial = razaoSocial;
            f.Telefone = telefone;


            f.IdFornecedor = id_fornecedor;

            BancoDeDados banco = new BancoDeDados();
            try
            {
                banco.Conectar();
                f.Alterar(banco);
            }
            finally
            {
                banco.Desconectar();
            }
        }
    }
}
