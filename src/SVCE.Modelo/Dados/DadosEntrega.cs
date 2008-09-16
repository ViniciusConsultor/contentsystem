using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SVCE.Modelo.Dados
{
    public class DadosEntrega
    {
        public string NomeCliente { get; set; }
        public string Endereco { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string HorarioPreferenciaç { get; set; }
    }
}
