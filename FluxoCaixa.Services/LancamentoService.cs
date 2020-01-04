using FluxoCaixa.Data.Interface;
using FluxoCaixa.Dominio.Entidades;
using FluxoCaixa.Services.Interface;
using System;
using System.Collections.Generic;

namespace FluxoCaixa.Services
{
    public class LancamentoServices : ILancamentoServices
    {
        private readonly ILancamentoRepositorio _lancamentoRepositorio;

        public LancamentoServices(ILancamentoRepositorio lancamentoRepositorio)
        {
            _lancamentoRepositorio = lancamentoRepositorio;
        }

        public void AtualizarLancamento(LancamentoFinanceiro lancamentoFinanceiro)
        {
            if(lancamentoFinanceiro.ValidarPermiteEdicaoOuExclusao())
                throw new Exception("O lançamento informado já foi consolidado não é permitido atualizar, por favor entre em contato com administrador");

            if (lancamentoFinanceiro.EntidadeValida())
                throw new Exception("Os dados de lançamentos estão inválidos o campo valor e tipo lançamento são obrigatórios, por favor entre em contato com administrador");

            if (!_lancamentoRepositorio.ExisteTipoLancamento(lancamentoFinanceiro.TipoLancamento.Id))
                throw new Exception("O tipo de lançamento enviado não está cadastrado, por favor entre em contato com administrador");

            _lancamentoRepositorio.Atualizar(lancamentoFinanceiro);
        }

        public List<LancamentoFinanceiro> BuscarLancamentoFinanceiro(DateTime? dataLancamento, int? tipoLancamento, bool? consolidado)
        {
            return _lancamentoRepositorio.Buscar(dataLancamento, tipoLancamento, consolidado);
        }

        public void InserirLancamento(LancamentoFinanceiro lancamentoFinanceiro)
        {
            if (lancamentoFinanceiro.EntidadeValida())
                throw new Exception("Os dados de lançamentos estão inválidos o campo valor e tipo lançamento são obrigatórios, por favor entre em contato com administrador");

            if (!_lancamentoRepositorio.ExisteTipoLancamento(lancamentoFinanceiro.TipoLancamento.Id))
                throw new Exception("O tipo de lançamento enviado não está cadastrado, por favor entre em contato com administrador");

            lancamentoFinanceiro.SetarValoresPadraoInserir();

            _lancamentoRepositorio.Inserir(lancamentoFinanceiro);
        }
    }
}
