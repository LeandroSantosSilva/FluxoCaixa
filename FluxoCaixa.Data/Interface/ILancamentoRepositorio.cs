using FluxoCaixa.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace FluxoCaixa.Data.Interface
{
    public interface ILancamentoRepositorio
    {
        void Inserir(LancamentoFinanceiro lancamentoFinanceiro);
        void Atualizar(LancamentoFinanceiro lancamentoFinanceiro);
        List<LancamentoFinanceiro> Buscar(DateTime? dataLancamento, int? tipoLancamento, bool? consolidado);
        bool ExisteTipoLancamento(int id);
    }
}
