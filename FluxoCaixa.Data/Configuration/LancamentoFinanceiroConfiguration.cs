using FluxoCaixa.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluxoCaixa.Data.Configuration
{
    public class LancamentoFinanceiroConfiguration : IEntityTypeConfiguration<LancamentoFinanceiro>
    {
        public void Configure(EntityTypeBuilder<LancamentoFinanceiro> builder)
        {
            builder.ToTable("LancamentoFinanceiro").HasKey(p => p.Id);
            builder.Property(p => p.DataHoraLancamento).IsRequired();
            builder.Property(p => p.Valor).IsRequired();
            builder.Property(p => p.Consolidado).IsRequired();
            builder.HasOne(p => p.TipoLancamento).WithMany(p => p.LancamentoFinanceiro);
        }
    }
}
