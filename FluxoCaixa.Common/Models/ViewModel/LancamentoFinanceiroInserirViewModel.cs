using FluxoCaixa.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Common.Models.ViewModel
{
    public class LancamentoFinanceiroInserirViewModel
    {
        public long Id { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        public double Valor { get; set; }

        [Required]
        public bool TipoLancamento { get; set; }
    }
}
