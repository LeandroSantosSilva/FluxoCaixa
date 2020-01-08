using FizzWare.NBuilder;
using FluxoCaixa.API.Controllers;
using FluxoCaixa.Dominio.DTO;
using FluxoCaixa.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Net;

namespace FluxoCaixa.API.Test
{
    [TestClass]
    public class BalancoControllerTest
    {
        private BalancoController _balancoController;
        private Mock<IBalancoServices> _balancoServicesMock;

        [TestInitialize]
        public void Inicializar()
        {
            _balancoServicesMock = new Mock<IBalancoServices>();

            _balancoController = new BalancoController(_balancoServicesMock.Object);
        }


        [TestMethod]
        public void API_Controller_Gerar_Balanco_Diario_Sucesso()
        {
            //prepare
            _balancoServicesMock.Setup(_ => _.GerarBalancoDiario());

            //action
            var retorno = _balancoController.GerarBalancoDiario();

            //assert
            Assert.IsTrue(((StatusCodeResult)retorno).StatusCode == (int)HttpStatusCode.OK);
        }

        [TestMethod]
        public void API_Controller_Gerar_Balanco_Diario_Erro()
        {
            //prepare
            _balancoServicesMock.Setup(_ => _.GerarBalancoDiario()).Throws(new Exception("Ocorreu um erro ao gerar balanço"));

            //action
            var retorno = _balancoController.GerarBalancoDiario();

            //assert
            Assert.IsTrue(((ContentResult)retorno).StatusCode == (int)HttpStatusCode.InternalServerError);
        }

        [TestMethod]
        public void API_Controller_Buscar_Balanco_Mensal_Sucesso()
        {
            //prepare
            var listaRetorno = Builder<BalancoMensal>.CreateListOfSize(10).Build().ToList();

            _balancoServicesMock.Setup(_ => _.BuscarBalancoMensal(It.IsAny<DateTime?>(), It.IsAny<DateTime?>())).Returns(listaRetorno);

            //action
            var retorno = _balancoController.GetBalancoMensal(null, null);

            //assert
            Assert.IsTrue(((ObjectResult)retorno).StatusCode == (int)HttpStatusCode.OK);
        }

        [TestMethod]
        public void API_Controller_Buscar_Balanco_Mensal_Erro()
        {
            //prepare
            _balancoServicesMock.Setup(_ => _.BuscarBalancoMensal(It.IsAny<DateTime?>(), It.IsAny<DateTime?>())).Throws(new Exception("Ocorreu um erro ao gerar balanço"));

            //action
            var retorno = _balancoController.GetBalancoMensal(null, null);

            //assert
            Assert.IsTrue(((ContentResult)retorno).StatusCode == (int)HttpStatusCode.InternalServerError);
        }
    }
}
