using FluxoCaixa.Data.Interface;
using FluxoCaixa.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FluxoCaixa.Data.Repositorio
{
    public class LancamentoRepositorio : ILancamentoRepositorio
    {
        private readonly FluxoCaixaContext _fluxoCaixaContext;

        public LancamentoRepositorio(FluxoCaixaContext fluxoCaixaContext)
        {
            _fluxoCaixaContext = fluxoCaixaContext;
        }

        public void Atualizar(LancamentoFinanceiro lancamentoFinanceiro)
        {
            var lancamento = _fluxoCaixaContext.LancamentosFinanceiro.FirstOrDefault(_ => _.Id == lancamentoFinanceiro.Id);

            var tipoLancamento = _fluxoCaixaContext.TiposLancamento.FirstOrDefault(_ => _.Id == lancamentoFinanceiro.TipoLancamento.Id);

            lancamento.TipoLancamento = tipoLancamento;
            lancamento.Valor = lancamentoFinanceiro.Valor;

            _fluxoCaixaContext.SaveChanges();
        }

        public List<LancamentoFinanceiro> Buscar(DateTime? dataLancamento, int? tipoLancamento, bool? consolidado)
        {
            return _fluxoCaixaContext.LancamentosFinanceiro
                        .Where(_ =>
                                (dataLancamento == null || _.DataHoraLancamento == dataLancamento) &&
                                (tipoLancamento == null || _.TipoLancamento.Id == tipoLancamento) &&
                                (consolidado == null || _.Consolidado == consolidado)
                             ).ToList();
        }

        public void Excluir(int id)
        {
            var lancamento = _fluxoCaixaContext.LancamentosFinanceiro.FirstOrDefault(_ => _.Id == id);

            _fluxoCaixaContext.LancamentosFinanceiro.Remove(lancamento);

            _fluxoCaixaContext.SaveChanges();
        }

        public void Inserir(LancamentoFinanceiro lancamentoFinanceiro)
        {
            var tipoLancamento = _fluxoCaixaContext.TiposLancamento.FirstOrDefault(_ => _.Id == lancamentoFinanceiro.TipoLancamento.Id);

            lancamentoFinanceiro.TipoLancamento = tipoLancamento;

            _fluxoCaixaContext.LancamentosFinanceiro.Add(lancamentoFinanceiro);

            _fluxoCaixaContext.SaveChanges();
        }

        public bool ExisteTipoLancamento(int id) => _fluxoCaixaContext.TiposLancamento.Any(_ => _.Id == id);

        public bool ValidarLancamentoExiste(long id) =>
            _fluxoCaixaContext.LancamentosFinanceiro.FirstOrDefault(_ => _.Id == id) == null;

        public bool ValidarLancamentoConsolidado(long id) =>
            _fluxoCaixaContext.LancamentosFinanceiro.FirstOrDefault(_ => _.Id == id).Consolidado;

    }
}
