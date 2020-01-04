using FluxoCaixa.Data.Interface;
using FluxoCaixa.Data.Repositorio;
using FluxoCaixa.Services;
using FluxoCaixa.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoCaixa.IOC
{
    public class InjecaoDependencia
    {
        public void Configurar(IServiceCollection services)
        {
            services.AddScoped<ILancamentoServices, LancamentoServices>();
            services.AddScoped<ILancamentoRepositorio, LancamentoRepositorio>();
        }
    }
}
