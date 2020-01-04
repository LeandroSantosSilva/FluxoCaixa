using FluxoCaixa.Dominio.Entidades;

namespace FluxoCaixa.Data.Interface
{
    public interface ILancamentoRepositorio
    {
        void Inserir(LancamentoFinanceiro lancamentoFinanceiro);
        bool ExisteTipoLancamento(int id);
    }
}
