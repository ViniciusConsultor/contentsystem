using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVCE.Modelo.Dados
{
    public class Produto
    {

        public int CodigoInterno { get; set; }
        public string CodigoExterno { get; set; }
        public string Nome { get; set; }
        public decimal PrecoVenda { get; set; }
        public Status Status { get; set; }
        public int IdFornecedor { get; set; }
        public int QuantidadeMinima { get; set; }
    }
}
