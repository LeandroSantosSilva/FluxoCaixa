using AutoMapper;
using FluxoCaixa.Common.ConfiguracaoAutoMapper;
using FluxoCaixa.Data;
using FluxoCaixa.Data.Interface;
using FluxoCaixa.Data.Repositorio;
using FluxoCaixa.Data.Seed;
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
        private MapperConfiguration MapperConfiguration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperModelToService());
                cfg.AddProfile(new AutoMapperServiceToModel());
            });

            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<FluxoCaixaContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<ILancamentoServices, LancamentoServices>();
            services.AddScoped<ILancamentoRepositorio, LancamentoRepositorio>();
            services.AddScoped<IBalancoServices, BalancoServices>();
            services.AddScoped<IBalancoRepositorio, BalancoRepositorio>();
            services.AddSingleton(sp => MapperConfiguration.CreateMapper());
            services.AddScoped<Seed, SeedProducao>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            RunSeeds(env.EnvironmentName, app);

            app.UseMvc();
        }

        /// <summary>
        /// Método responsável por popular e rodar os migrations iniciais, podendo ser configurado por ambiente
        /// </summary>
        /// <param name="env"></param>
        /// <param name="app"></param>
        private void RunSeeds(string env, IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var seed = serviceScope.ServiceProvider.GetService<Seed>();
               
                switch (env)
                {
                    case "Development":
                        seed.Run(migrate: true);
                        break;
                    default:
                        seed.Run(migrate: true);
                        break;
                }
            }
        }
    }
}
