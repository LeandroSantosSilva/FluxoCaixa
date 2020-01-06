using FluxoCaixa.Data.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FluxoCaixa.Services.Test
{
    [TestClass]
    public class BalancoServiceTest
    {
        private BalancoServices _balancoServices;
        private Mock<IBalancoRepositorio> _balancoRepositorio;

        [TestInitialize]
        public void Inicializar()
        {
            _balancoRepositorio = new Mock<IBalancoRepositorio>();

            _balancoServices = new BalancoServices(_balancoRepositorio.Object);
        }

        [TestMethod]
        public void Service_Balanco_Gerar_Balanco_Dia()
        {
            //prepare
            _balancoRepositorio.Setup(_ => _.GerarBalancoDiario());

            //action
            _balancoServices.GerarBalancoDiario();
        }
    }
}
