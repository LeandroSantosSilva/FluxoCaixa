using FluxoCaixa.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace FluxoCaixa.Services.Interface
{
    public interface ILancamentoServices
    {
        void InserirLancamento(LancamentoFinanceiro lancamentoFinanceiro);
        void AtualizarLancamento(LancamentoFinanceiro lancamentoFinanceiro);
        List<LancamentoFinanceiro> BuscarLancamentoFinanceiro(DateTime? dataLancamento, int? tipoLancamento, bool? consolidado);
        LancamentoFinanceiro BuscarLancamentoFinanceiroPorId(int id);
        void ExcluirLancamentoFinanceiro(int id);
    }
}
