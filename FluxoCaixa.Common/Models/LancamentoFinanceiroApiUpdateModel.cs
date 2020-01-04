using FluxoCaixa.Common.Enum;
using System;

namespace FluxoCaixa.Common.Models
{
    public class LancamentoFinanceiroApiUpdateModel
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public TipoLancamentoEnum TipoLancamento { get; set; }
    }
}
