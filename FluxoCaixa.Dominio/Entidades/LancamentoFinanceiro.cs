using System;

namespace FluxoCaixa.Dominio.Entidades
{
    public class LancamentoFinanceiro
    {
        public long Id { get; set; }
        public DateTime DataHoraLancamento { get; set; }
        public double Valor { get; set; }
        public TipoLancamento TipoLancamento { get; set; }
        public StatusLancamento StatusLancamento { get; set; }
    }
}
