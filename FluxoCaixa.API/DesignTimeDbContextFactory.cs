using FluxoCaixa.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.API
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FluxoCaixaContext>
    {
        public FluxoCaixaContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var builder = new DbContextOptionsBuilder<FluxoCaixaContext>();
            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FluxoCaixaDB;Integrated Security=True");
            return new FluxoCaixaContext(builder.Options);
        }
    }
}
