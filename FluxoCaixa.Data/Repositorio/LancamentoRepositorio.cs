using FluxoCaixa.Data.Interface;
using FluxoCaixa.Dominio.Entidades;
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

        public bool ExisteTipoLancamento(int id)
        {
            return _fluxoCaixaContext.TiposLancamento.Any(_ => _.Id == id);
        }

        public void Inserir(LancamentoFinanceiro lancamentoFinanceiro)
        {
            var tipoLancamento = _fluxoCaixaContext.TiposLancamento.FirstOrDefault(_ => _.Id == lancamentoFinanceiro.TipoLancamento.Id);

            lancamentoFinanceiro.TipoLancamento = tipoLancamento;

            _fluxoCaixaContext.LancamentosFinanceiro.Add(lancamentoFinanceiro);

            _fluxoCaixaContext.SaveChanges();
        }
    }
}
