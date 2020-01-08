using FluxoCaixa.Common.Enum;
using System;

namespace FluxoCaixa.Common.Models
{
    public class LancamentoFinanceiroApiModel
    {

        public double Valor { get; set; }
        public TipoLancamentoEnum TipoLancamento { get; set; }
    }
}
