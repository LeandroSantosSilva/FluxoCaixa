using FluxoCaixa.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

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
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new FluxoCaixaContext(builder.Options);
        }
    }
}
