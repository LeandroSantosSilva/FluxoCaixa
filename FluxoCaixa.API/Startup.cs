using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using FluxoCaixa.Data;
//using FluxoCaixa.IOC;
using FluxoCaixa.Services;
using FluxoCaixa.Services.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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

            //services.AddEntityFrameworkSqlServer()
            //    .AddDbContext<FluxoCaixaContext>(o => o.UseSqlServer(connectionString));

            services.AddSingleton<ILancamentoServices, LancamentoServices>();

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
