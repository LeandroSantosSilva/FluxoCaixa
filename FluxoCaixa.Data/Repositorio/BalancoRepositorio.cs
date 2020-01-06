using FluxoCaixa.Common.Enum;
using FluxoCaixa.Data.Interface;
using FluxoCaixa.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FluxoCaixa.Data.Repositorio
{
    public class BalancoRepositorio : IBalancoRepositorio
    {
        private readonly FluxoCaixaContext _fluxoCaixaContext;
        public BalancoRepositorio(FluxoCaixaContext fluxoCaixaContext)
        {
            _fluxoCaixaContext = fluxoCaixaContext;
        }

        public void GerarBalancoDiario()
        {
            var listaLancamentosNaoConsolidados = _fluxoCaixaContext.LancamentosFinanceiro.Where(_ => !_.Consolidado).Include(_ => _.TipoLancamento);

            var listaLancamentosAgrupadoData = listaLancamentosNaoConsolidados.GroupBy(_ => _.DataHoraLancamento.Date);

            foreach (var data in listaLancamentosAgrupadoData)
            {
                var totalCredito = data.Where(_ => _.TipoLancamento.Id == (int)TipoLancamentoEnum.Credito).Sum(_ => _.Valor);
                var totalDebito = data.Where(_ => _.TipoLancamento.Id == (int)TipoLancamentoEnum.Debito).Sum(_ => _.Valor);

                var balanco = BuscarBalancoDia(data.Key);

                if (balanco == null)
                {
                    _fluxoCaixaContext.BalancoDia.Add(new BalancoDia()
                    {
                        Data = data.Key,
                        ValorCredito = totalCredito,
                        ValorDebito = totalDebito,
                        Saldo = totalCredito - totalDebito
                    });
                }
                else
                {
                    balanco.ValorCredito += totalCredito;
                    balanco.ValorDebito += totalDebito;
                    balanco.Saldo = balanco.ValorCredito - balanco.ValorDebito;
                }

                data.ToList().ForEach(_ => _.Consolidado = true);
            }

            _fluxoCaixaContext.SaveChanges();
        }

        private BalancoDia BuscarBalancoDia(DateTime dataLancamento)
        {
            return _fluxoCaixaContext.BalancoDia.FirstOrDefault(_ => _.Data.Date == dataLancamento);
        }
    }
}
