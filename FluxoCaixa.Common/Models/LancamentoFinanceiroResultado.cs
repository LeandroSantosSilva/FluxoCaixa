using FluxoCaixa.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluxoCaixa.Common.Models
{
    public class LancamentoFinanceiroResultado
    {
        public string Id { get; set; }
        public string DataHoraLancamento { get; set; }
        public double Valor { get; set; }
        public string TipoLancamento { get; set; }
        public string Consolidado { get; set; }
    }
}
