using FluxoCaixa.Common.Models;
using FluxoCaixa.Dominio.Entidades;
using System.Collections.Generic;

namespace FluxoCaixa.ClientServices.Interfaces
{
    public interface ILancamentoFinanceiroClientServices
    {
        IEnumerable<LancamentoFinanceiro> FiltrarLancamentosFinanceiro(LancamentoFinanceiroFiltro filtro);
        void AtualizarLancamentoFinanceiro(LancamentoFinanceiroApiUpdateModel model);
        void InserirLancamentoFinaneiro(LancamentoFinanceiroApiModel model);
        void ExcluirLancamentoFinanceiro(int id);
    }
}
