﻿// <auto-generated />
using System;
using FluxoCaixa.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FluxoCaixa.Data.Migrations
{
    [DbContext(typeof(FluxoCaixaContext))]
    partial class FluxoCaixaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FluxoCaixa.Dominio.Entidades.BalancoDia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data");

                    b.Property<double>("Saldo");

                    b.Property<double>("ValorCredito");

                    b.Property<double>("ValorDebito");

                    b.HasKey("Id");

                    b.ToTable("BalancoDia");
                });

            modelBuilder.Entity("FluxoCaixa.Dominio.Entidades.LancamentoFinanceiro", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Consolidado");

                    b.Property<DateTime>("DataHoraLancamento");

                    b.Property<int?>("TipoLancamentoId");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("TipoLancamentoId");

                    b.ToTable("LancamentoFinanceiro");
                });

            modelBuilder.Entity("FluxoCaixa.Dominio.Entidades.TipoLancamento", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("TipoLancamento");
                });

            modelBuilder.Entity("FluxoCaixa.Dominio.Entidades.LancamentoFinanceiro", b =>
                {
                    b.HasOne("FluxoCaixa.Dominio.Entidades.TipoLancamento", "TipoLancamento")
                        .WithMany("LancamentoFinanceiro")
                        .HasForeignKey("TipoLancamentoId");
                });
#pragma warning restore 612, 618
        }
    }
}
