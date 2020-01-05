using FluxoCaixa.Data.Configuration;
using FluxoCaixa.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Data
{
    public class FluxoCaixaContext : DbContext
    {
        public FluxoCaixaContext(DbContextOptions<FluxoCaixaContext> options) : base(options)
        { 
        }

        public virtual DbSet<LancamentoFinanceiro> LancamentosFinanceiro { get; set; }
        public DbSet<TipoLancamento> TiposLancamento { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TipoLancamentoConfiguration());
            modelBuilder.ApplyConfiguration(new LancamentoFinanceiroConfiguration());
            modelBuilder.ApplyConfiguration(new BalancoDiaConfiguration());

            base.OnModelCreating(modelBuilder); 
        }
    }
}
