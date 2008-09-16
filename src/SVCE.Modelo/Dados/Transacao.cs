using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVCE.Modelo.Dados
{
    public class Transacao
    {
        public int IdTransacao { get; set; }
        public int? IdTransacaoPai { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public int IdFornecedor { get; set; }
        public int IdResponsavel { get; set; }
        public DateTime DataTransacao { get; set; }
        public StatusTransacao StatusTransacao { get; set; }
        public decimal ValorTotal { get; set; }
        public int? NumeroNotaFiscal { get; set; }
        public List<ItemTransacao> Itens { get; set; }
    }
}
