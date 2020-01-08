using FluxoCaixa.Common.Comparadores;
using FluxoCaixa.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace FluxoCaixa.Data.Seed
{
    internal class SeedTipoLancamento
    {
        private FluxoCaixaContext _fluxoCaixaContext;

        public SeedTipoLancamento(FluxoCaixaContext fluxoCaixaContext)
        {
            _fluxoCaixaContext = fluxoCaixaContext;
        }

        public void Seed()
        {
            var tiposLancamentos = new List<TipoLancamento>
            {
                new TipoLancamento(){Id = 1, Nome = "Crédito" },
                new TipoLancamento(){Id = 2, Nome = "Débito" }
            };

            var listaLancamentosCadastrados = _fluxoCaixaContext.TiposLancamento.ToList();

            var tipoLancamentoSemCadastro = tiposLancamentos.Except(listaLancamentosCadastrados, new ComparadorTipoLancamento<TipoLancamento>());

            foreach (var lancamento in tipoLancamentoSemCadastro)
            {
                _fluxoCaixaContext.TiposLancamento.Add(new TipoLancamento() { Id = lancamento.Id, Nome = lancamento.Nome });
            }

            _fluxoCaixaContext.SaveChanges();
        }
    }
}