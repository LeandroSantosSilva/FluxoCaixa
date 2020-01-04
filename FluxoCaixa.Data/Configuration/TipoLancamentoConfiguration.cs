using FluxoCaixa.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluxoCaixa.Data.Configuration
{
    public class TipoLancamentoConfiguration : IEntityTypeConfiguration<TipoLancamento>
    {
        public void Configure(EntityTypeBuilder<TipoLancamento> builder)
        {
            builder.ToTable("TipoLancamento");
            builder.Property(p => p.Nome).IsRequired();
        }
    }
}
