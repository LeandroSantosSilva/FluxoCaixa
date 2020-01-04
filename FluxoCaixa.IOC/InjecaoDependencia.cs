using FluxoCaixa.Services;
using FluxoCaixa.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoCaixa.IOC
{
    public class InjecaoDependencia
    {
        public void Configurar(IServiceCollection services)
        {
            services.AddSingleton<ILancamentoServices, LancamentoServices>();
        }
    }
}
