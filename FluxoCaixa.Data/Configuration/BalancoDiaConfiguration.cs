using FluxoCaixa.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluxoCaixa.Data.Configuration
{
    public class BalancoDiaConfiguration : IEntityTypeConfiguration<BalancoDia>
    {
        public void Configure(EntityTypeBuilder<BalancoDia> builder)
        {
            builder.ToTable("BalancoDia");
            builder.Property(p => p.Data).IsRequired();
            builder.Property(p => p.ValorCredito).IsRequired();
            builder.Property(p => p.ValorDebito).IsRequired();
            builder.Property(p => p.Saldo).IsRequired();
        }
    }
}
