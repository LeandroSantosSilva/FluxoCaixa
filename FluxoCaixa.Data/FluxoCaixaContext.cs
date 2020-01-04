using FluxoCaixa.Data.Configuration;
using FluxoCaixa.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;

namespace FluxoCaixa.Data
{
    public class FluxoCaixaContext : DbContext
    {
        public FluxoCaixaContext()
        {
        }

        public FluxoCaixaContext(DbContextOptions<FluxoCaixaContext> options) : base(options)
        { 
        }

        public DbSet<LancamentoFinanceiro> LancamentosFinanceiro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            LancamentoFinanceiroConfiguration.Configurar(modelBuilder);

            base.OnModelCreating(modelBuilder); 
        }
    }
}
