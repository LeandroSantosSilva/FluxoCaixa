using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Data.Seed
{
    public class Seed
    {
        protected readonly FluxoCaixaContext _fluxoCaixaContext;

        public Seed(FluxoCaixaContext fluxoCaixaContext)
        {
            _fluxoCaixaContext = fluxoCaixaContext;
        }

        public virtual void Run(bool migrate = false) => RunAsync(migrate);

        protected virtual void RunAsync(bool migrate)
        {
            if (migrate) MigrateAsync();

            AdicionarTipoLancamentoIfEmpty();
        }

        protected void MigrateAsync()
        {
            _fluxoCaixaContext.Database.Migrate();
        }

        protected void AdicionarTipoLancamentoIfEmpty() => new SeedTipoLancamento(_fluxoCaixaContext).Seed();

    }
}
