using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluxoCaixa.Dominio.Entidades
{
    public class TipoLancamento
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<LancamentoFinanceiro> LancamentoFinanceiro { get; set; }
    }
}
