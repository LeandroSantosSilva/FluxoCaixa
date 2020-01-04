using FluxoCaixa.Data;
using FluxoCaixa.Data.Interface;
using FluxoCaixa.Data.Repositorio;
using FluxoCaixa.Services;
using FluxoCaixa.Services.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoCaixa.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //new InjecaoDependencia().Configurar(services);

            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<FluxoCaixaContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<ILancamentoServices, LancamentoServices>();
            services.AddScoped<ILancamentoRepositorio, LancamentoRepositorio>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
