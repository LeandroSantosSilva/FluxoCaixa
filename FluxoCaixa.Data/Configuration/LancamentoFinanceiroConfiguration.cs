using System;
using System.Collections.Generic;
using System.Text;
using FluxoCaixa.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Data.Configuration
{
    public class LancamentoFinanceiroConfiguration
    {
        public static void Configurar(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LancamentoFinanceiro>(tbl =>
            {
                tbl.ToTable("LancamentoFinanceiro");
                
            });
        }
    }
}
