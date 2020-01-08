using System;
using System.Collections.Generic;
using System.Text;

namespace FluxoCaixa.Common.Models
{
    public class BalancoMensalModel
    {
        public int Mes { get; set; }
        public string DescricaoMes { get; set; }
        public double SomaCredito { get; set; }
        public double SomaDebito { get; set; }
        public double SomaSaldo { get; set; }
        public int Ano { get; set; }
    }
}
