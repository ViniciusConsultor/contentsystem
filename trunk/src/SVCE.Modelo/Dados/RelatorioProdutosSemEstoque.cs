using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVCE.Modelo.Dados
{
    public class RelatorioProdutosSemEstoque
    {
        public ItemRelatorioProdutosSemEstoque[] Produtos { get; set; }
    }

    public class ItemRelatorioProdutosSemEstoque
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public int IdFornecedor { get; set; }

        public string NomeFornecedor { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public int QuantidadeMinima { get; set; }
        public decimal PrecoVenda { get; set; }

    }
}
