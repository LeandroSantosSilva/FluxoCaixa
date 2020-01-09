using FluxoCaixa.Common.Constantes;
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
            if (lancamentoFinanceiro.EntidadeValida())
                throw new Exception(Mensagens.MENSAGEM_CAMPOS_OBRIGATORIOS_LANCAMENTO);

            if (_lancamentoRepositorio.ValidarLancamentoExiste(lancamentoFinanceiro.Id))
                throw new Exception(string.Format(Mensagens.MENSAGEM_LANCAMENTO_NAO_ENCONTRADO, lancamentoFinanceiro.Id));

            if (_lancamentoRepositorio.ValidarLancamentoConsolidado(lancamentoFinanceiro.Id))
                throw new Exception(Mensagens.MENSAGEM_NAO_PERMITIDO_ALTERAR_LANCAMENTO);

            if (!_lancamentoRepositorio.ExisteTipoLancamento(lancamentoFinanceiro.TipoLancamento.Id))
                throw new Exception(Mensagens.MENSAGEM_NAO_EXISTE_TIPO_LANCAMENTO_CADASTRADRO);

            _lancamentoRepositorio.Atualizar(lancamentoFinanceiro);
        }

        public List<LancamentoFinanceiro> BuscarLancamentoFinanceiro(DateTime? dataLancamento, int? tipoLancamento, bool? consolidado)
        {
            return _lancamentoRepositorio.Buscar(dataLancamento, tipoLancamento, consolidado);
        }

        public LancamentoFinanceiro BuscarLancamentoFinanceiroPorId(int id)
        {
            return _lancamentoRepositorio.BuscarPorId(id);
        }

        public void ExcluirLancamentoFinanceiro(int id)
        {
            if (_lancamentoRepositorio.ValidarLancamentoExiste(id))
                throw new Exception(string.Format(Mensagens.MENSAGEM_LANCAMENTO_NAO_ENCONTRADO, id));

            if (_lancamentoRepositorio.ValidarLancamentoConsolidado(id))
                throw new Exception(Mensagens.MENSAGEM_NAO_PERMITIDO_EXCLUIR_LANCAMENTO);

            _lancamentoRepositorio.Excluir(id);
        }

        public void InserirLancamento(LancamentoFinanceiro lancamentoFinanceiro)
        {
            if (lancamentoFinanceiro.EntidadeValida())
                throw new Exception(Mensagens.MENSAGEM_CAMPOS_OBRIGATORIOS_LANCAMENTO);

            if (!_lancamentoRepositorio.ExisteTipoLancamento(lancamentoFinanceiro.TipoLancamento.Id))
                throw new Exception(Mensagens.MENSAGEM_NAO_EXISTE_TIPO_LANCAMENTO_CADASTRADRO);

            lancamentoFinanceiro.SetarValoresPadraoInserir();

            _lancamentoRepositorio.Inserir(lancamentoFinanceiro);
        }
    }
}
