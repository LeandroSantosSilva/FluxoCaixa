using FluxoCaixa.Common.Enum;
using System;

namespace FluxoCaixa.Common.Models
{
    public class LancamentoFinanceiroFiltro
    {
        public DateTime? DataLancamento { get; set; }
        public int? TipoLancamento { get; set; }
        public bool? Consolidado { get; set; }
    }
}
