using FizzWare.NBuilder;
using FluxoCaixa.Data.Interface;
using FluxoCaixa.Dominio.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

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

        [TestMethod]
        public void Service_Balanco_Gerar_Balanco_Mensal_Sucesso()
        {
            //prepare
            var listaRetorno = Builder<BalancoMensal>.CreateListOfSize(10).Build().ToList();

            _balancoRepositorio.Setup(_ => _.BuscarBalancoMensal(It.IsAny<DateTime?>(), It.IsAny<DateTime?>())).Returns(listaRetorno);

            //action
            var balancoMensalLista = _balancoServices.BuscarBalancoMensal(null, null);

            Assert.AreEqual(balancoMensalLista, listaRetorno);
        }
    }
}
