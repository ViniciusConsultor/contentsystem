using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVCE.Modelo.Dados
{
    public class Produto
    {

        //public int CodigoInterno { get; set; }
        //public string CodigoExterno { get; set; }
        //public string Nome { get; set; }
        //public decimal PrecoVenda { get; set; }
        //public Status Status { get; set; }
        //public int IdFornecedor { get; set; }
        //public int QuantidadeMinima { get; set; }



        public int CodigoInterno;
        public string CodigoExterno;
        public string Nome;
        public decimal PrecoVenda;
        public Status Status;
        public int IdFornecedor;
        public int QuantidadeMinima;




        public static Produto[] Listar(int? codigoInterno, string codigoExterno, string nome)
        {
            return null;
        }
        public void Incluir()
        {

        }
        public void Alterar()
        {

        }
        public static void Excluir(int codigoExterno)
        {

        }

    }
}
