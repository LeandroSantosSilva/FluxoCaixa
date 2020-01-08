using FluxoCaixa.Common.Enum;
using FluxoCaixa.Data.Interface;
using FluxoCaixa.Dominio.DTO;
using FluxoCaixa.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public List<BalancoMensal> BuscarBalancoMensal(DateTime? ano, DateTime? mesParametro)
        {
            if (ano == null)
                ano = DateTime.Now;

            var listaBalancoAgrupadoPorMes = _fluxoCaixaContext.BalancoDia
                    .Where(_ => _.Data.Year == ano.Value.Year && (mesParametro == null || _.Data.Month == ano.Value.Month))
                    .GroupBy(_ => _.Data.Month).ToList();

            var balancoMensal = new List<BalancoMensal>();

            foreach (var mes in listaBalancoAgrupadoPorMes)
            {
                balancoMensal.Add(new BalancoMensal()
                {
                    Ano = ano.Value.Year,
                    Mes = mes.Key,
                    SomaCredito = mes.Sum(_ => _.ValorCredito),
                    SomaDebito = mes.Sum(_ => _.ValorDebito),
                    SomaSaldo = mes.Sum(_ => _.Saldo)
                });
            }

            return balancoMensal;
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

        private BalancoDia BuscarBalancoDia(DateTime dataLancamento) => _fluxoCaixaContext.BalancoDia.FirstOrDefault(_ => _.Data.Date == dataLancamento);
    }
}
