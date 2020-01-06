using FluxoCaixa.Data.Interface;
using FluxoCaixa.Services.Interface;

namespace FluxoCaixa.Services
{
    public class BalancoServices : IBalancoServices
    {
        private readonly IBalancoRepositorio _balancoRepositorio;
        public BalancoServices(IBalancoRepositorio balancoRepositorio)
        {
            _balancoRepositorio = balancoRepositorio;
        }

        public void GerarBalancoDiario()
        {
            _balancoRepositorio.GerarBalancoDiario();
        }
    }
}
