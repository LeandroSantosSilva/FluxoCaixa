using FluxoCaixa.Common.Models;
using FluxoCaixa.Dominio.Entidades;
using System.Collections.Generic;

namespace FluxoCaixa.ClientServices.Interfaces
{
    public interface ILancamentoFinanceiroClientServices
    {
        IEnumerable<LancamentoFinanceiroModel> FiltrarLancamentosFinanceiro(LancamentoFinanceiroFiltro filtro);
        void AtualizarLancamentoFinanceiro(LancamentoFinanceiroApiUpdateModel model);
        void InserirLancamentoFinaneiro(LancamentoFinanceiroApiModel model);
        void ExcluirLancamentoFinanceiro(int id);
        LancamentoFinanceiroModel GetLancamentoFinanceiro(int id);
    }
}
