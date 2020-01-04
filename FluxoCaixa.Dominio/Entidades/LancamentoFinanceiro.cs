using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluxoCaixa.Dominio.Entidades
{
    public class LancamentoFinanceiro
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime DataHoraLancamento { get; set; }
        public double Valor { get; set; }
        public TipoLancamento TipoLancamento { get; set; }
        public bool Consolidado { get; set; }

        public void SetarValoresPadraoInserir()
        {
            DataHoraLancamento = DateTime.Now;
            Id = 0;
            Consolidado = false; 
        }

        public bool ValidarPermiteEdicaoOuExclusao() => Consolidado;

        public bool EntidadeValida() => Valor == 0 || TipoLancamento == null;
    }
}
