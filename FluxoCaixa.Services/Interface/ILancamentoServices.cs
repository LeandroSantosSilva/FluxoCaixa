using FluxoCaixa.Dominio.Entidades;

namespace FluxoCaixa.Services.Interface
{
    public interface ILancamentoServices
    {
        void InserirLancamento(LancamentoFinanceiro lancamento);
    }
}
