using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVCE.Modelo.Dados
{
    public class RelatorioProdutosMaisVendidos
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public ItemRelatorioProdutosMaisVendidos[] Produtos { get; set; }
    }

    public class ItemRelatorioProdutosMaisVendidos
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public int IdFornecedor { get; set; }

        public string NomeFornecedor { get; set; }
        public int QuantidadeVendida { get; set; }
        public decimal VolumeVendas { get; set; }

    }
}
