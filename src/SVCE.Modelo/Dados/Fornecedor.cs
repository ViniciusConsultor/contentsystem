using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVCE.Modelo.Dados
{
    public class Fornecedor
    {
        //public int IdFornecedor { get; set; }
        //public string Nome { get; set; }
        //public string RazaoSocial { get; set; }
        //public string CNPJ { get; set; }
        //public Status Status { get; set; }
        //public string Endereco { get; set; }
        //public string Telefone { get; set; }
        //public string Email { get; set; }
        //public string NomeContato { get; set; }
        public int IdFornecedor;
        public string Nome;
        public string RazaoSocial;
        public string CNPJ;
        public Status Status;
        public string Endereco;
        public string Telefone;
        public string Email;
        public string NomeContato;


        public static Fornecedor[] Listar(string nome, string razaoSocial, string cnpj)
        {
            return null;
        }
        public void Incluir()
        {

        }
        public void Alterar(Fornecedor fornecedor)
        {

        }
        public static void Exclir(int id_fornecedor)
        {

        }

    }
}
