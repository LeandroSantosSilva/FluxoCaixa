using FluxoCaixa.Common.Enum;
using System;

namespace FluxoCaixa.Common.Models
{
    public class LancamentoFinanceiroModel
    {
        public double Valor { get; set; }
        public TipoLancamentoEnum TipoLancamento { get; set; }
        public StatusLancamentoEnum StatusLancamento { get; set; }
    }
}
