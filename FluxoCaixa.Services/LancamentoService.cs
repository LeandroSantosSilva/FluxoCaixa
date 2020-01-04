using FluxoCaixa.Data.Interface;
using FluxoCaixa.Data.Repositorio;
using FluxoCaixa.Dominio.Entidades;
using FluxoCaixa.Services.Interface;
using System;

namespace FluxoCaixa.Services
{
    public class LancamentoServices : ILancamentoServices
    {
        private readonly ILancamentoRepositorio _lancamentoRepositorio;

        public LancamentoServices(ILancamentoRepositorio lancamentoRepositorio)
        {
            _lancamentoRepositorio = lancamentoRepositorio;
        }

        public void InserirLancamento(LancamentoFinanceiro lancamento)
        {
            if (lancamento.EntidadeValida())
                throw new Exception("Os dados de lançamentos estão inválidos, o campo valor, tipo  e tipo lançamento são obrigatórios, por favor entre em contato com administrador");

            if (!_lancamentoRepositorio.ExisteTipoLancamento(lancamento.TipoLancamento.Id))
                throw new Exception("O tipo de lançamento enviado não está cadastrado, por favor entre em contato com administrador");

            lancamento.SetarValoresPadraoInserir();

            _lancamentoRepositorio.Inserir(lancamento);
        }
    }
}
