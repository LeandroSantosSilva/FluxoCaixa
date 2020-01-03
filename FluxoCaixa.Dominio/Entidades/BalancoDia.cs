using System;
using System.Collections.Generic;
using System.Text;

namespace FluxoCaixa.Dominio.Entidades
{
    public class BalancoDia
    {
        public DateTime Data { get; set; }
        public double ValorCredito { get; set; }
        public double ValorDebito { get; set; }
        public double Saldo { get; set; }

    }
}
