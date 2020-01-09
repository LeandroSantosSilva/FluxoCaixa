using System;
using System.Collections.Generic;
using System.Text;

namespace FluxoCaixa.Common.Models
{
    public class LancamentoFinanceiroModel
    {
        public long Id { get; set; }
        public DateTime DataHoraLancamento { get; set; }
        public double Valor { get; set; }
        public int TipoLancamento { get; set; }
        public bool Consolidado { get; set; }
    }
}
