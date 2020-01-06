using FluxoCaixa.API.Controllers;
using FluxoCaixa.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
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
        public void API_Controller_Balanco_Sucesso()
        {
            //prepare
            _balancoServicesMock.Setup(_ => _.GerarBalancoDiario());

            //action
            var retorno = _balancoController.GerarBalancoDiario();

            //assert
            Assert.IsTrue(((StatusCodeResult)retorno).StatusCode == (int)HttpStatusCode.OK);
        }

        [TestMethod]
        public void API_Controller_Balanco_Erro()
        {
            //prepare
            _balancoServicesMock.Setup(_ => _.GerarBalancoDiario()).Throws(new Exception("Ocorreu um erro ao gerar balanço"));

            //action
            var retorno = _balancoController.GerarBalancoDiario();

            //assert
            Assert.IsTrue(((ContentResult)retorno).StatusCode == (int)HttpStatusCode.InternalServerError);
        }
    }
}
