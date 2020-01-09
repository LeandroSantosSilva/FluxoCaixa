using AutoMapper;
using FizzWare.NBuilder;
using FluxoCaixa.API.Controllers;
using FluxoCaixa.Common.Models;
using FluxoCaixa.Dominio.Entidades;
using FluxoCaixa.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Net;
using System.Linq;
using System.Collections.Generic;

namespace FluxoCaixa.API.Test
{
    [TestClass]
    public class LancamentosControllerTest
    {
        private LancamentosController _lancamentosController;
        private Mock<IMapper> _mapperMock;
        private Mock<ILancamentoServices> _lancamentosServicesMock;
        private LancamentoFinanceiroApiModel _lancamentoFinanceiroApiModel;
        private LancamentoFinanceiroApiUpdateModel _lancamentoFinanceiroApiUpdateModel;
        private LancamentoFinanceiroFiltro _lancamentoFinanceiroFiltro;
        [TestInitialize]
        public void Inicializar()
        {
            _mapperMock = new Mock<IMapper>();
            _lancamentosServicesMock = new Mock<ILancamentoServices>();
            _lancamentoFinanceiroApiModel = Builder<LancamentoFinanceiroApiModel>.CreateNew().Build();
            _lancamentoFinanceiroApiUpdateModel = Builder<LancamentoFinanceiroApiUpdateModel>.CreateNew().Build();
            _lancamentoFinanceiroFiltro = Builder<LancamentoFinanceiroFiltro>.CreateNew().Build();
            _lancamentosController = new LancamentosController(_lancamentosServicesMock.Object, _mapperMock.Object);
        }

        [TestMethod]
        public void API_Controller_Lancamentos_InserirLancamentoFinanceiro_Sucesso()
        {
            //prepare
            _lancamentosServicesMock.Setup(_ => _.InserirLancamento(It.IsAny<LancamentoFinanceiro>()));

            //action
            var retorno = _lancamentosController.InserirLancamentoFinanceiro(_lancamentoFinanceiroApiModel);

            //assert
            Assert.IsTrue(((StatusCodeResult)retorno).StatusCode == (int)HttpStatusCode.OK);
        }

        [TestMethod]
        public void API_Controller_Lancamentos_InserirLancamentoFinanceiro_Erro()
        {
            //prepare
            _lancamentosServicesMock.Setup(_ => _.InserirLancamento(It.IsAny<LancamentoFinanceiro>())).Throws(new Exception("Ocorreu um erro ao inserir lancamento"));
            
            //action
            var retorno = _lancamentosController.InserirLancamentoFinanceiro(_lancamentoFinanceiroApiModel);

            //assert
            Assert.IsTrue(((ContentResult)retorno).StatusCode == (int)HttpStatusCode.InternalServerError);
        }
        [TestMethod]
        public void API_Controller_Lancamentos_AtualizarLancamentoFinanceiro_Sucesso()
        {
            //prepare
            _lancamentosServicesMock.Setup(_ => _.AtualizarLancamento(It.IsAny<LancamentoFinanceiro>()));

            //action
            var retorno = _lancamentosController.AtualizarLancamentoFinanceiro(_lancamentoFinanceiroApiUpdateModel);

            //assert
            Assert.IsTrue(((StatusCodeResult)retorno).StatusCode == (int)HttpStatusCode.OK);
        }

        [TestMethod]
        public void API_Controller_Lancamentos_AtualizarLancamentoFinanceiro_Erro()
        {
            //prepare
            _lancamentosServicesMock.Setup(_ => _.AtualizarLancamento(It.IsAny<LancamentoFinanceiro>())).Throws(new Exception("Ocorreu um erro ao inserir lancamento"));

            //action
            var retorno = _lancamentosController.AtualizarLancamentoFinanceiro(_lancamentoFinanceiroApiUpdateModel);

            //assert
            Assert.IsTrue(((ContentResult)retorno).StatusCode == (int)HttpStatusCode.InternalServerError);
        }

        [TestMethod]
        public void API_Controller_Lancamentos_FiltrarLancamentoFinanceiro_Sucesso()
        {
            //prepare
            var listaLancamentos = Builder<LancamentoFinanceiro>.CreateListOfSize(10).Build();

            _lancamentosServicesMock.Setup(_ => _.BuscarLancamentoFinanceiro(It.IsAny<DateTime?>(), It.IsAny<int?>(), It.IsAny<bool?>())).Returns(listaLancamentos.ToList());

            //action
            var retorno = _lancamentosController.FiltrarLancamentoFinanceiro(_lancamentoFinanceiroFiltro);

            //assert
            Assert.IsTrue(((ObjectResult)retorno).StatusCode == (int)HttpStatusCode.OK);
        }

        [TestMethod]
        public void API_Controller_Lancamentos_FiltrarLancamentoFinanceiro_Erro()
        {
            //prepare
            _lancamentosServicesMock.Setup(_ => _.BuscarLancamentoFinanceiro(It.IsAny<DateTime?>(), It.IsAny<int?>(), It.IsAny<bool?>())).Throws(new Exception("Ocorreu um erro ao buscar lancamento"));

            //action
            var retorno = _lancamentosController.FiltrarLancamentoFinanceiro(_lancamentoFinanceiroFiltro);

            //assert
            Assert.IsTrue(((ContentResult)retorno).StatusCode == (int)HttpStatusCode.InternalServerError);
        }

        [TestMethod]
        public void API_Controller_Lancamentos_ExcluirLancamentoFinanceiro_Sucesso()
        {
            //prepare
            _lancamentosServicesMock.Setup(_ => _.ExcluirLancamentoFinanceiro(It.IsAny<int>()));

            //action
            var retorno = _lancamentosController.Delete(1);

            //assert
            Assert.IsTrue(((StatusCodeResult)retorno).StatusCode == (int)HttpStatusCode.OK);
        }

        [TestMethod]
        public void API_Controller_Lancamentos_ExcluirLancamentoFinanceiro_Erro()
        {
            //prepare
            _lancamentosServicesMock.Setup(_ => _.ExcluirLancamentoFinanceiro(It.IsAny<int>())).Throws(new Exception("Ocorreu um erro ao excluir lancamento"));

            //action
            var retorno = _lancamentosController.Delete(1);

            //assert
            Assert.IsTrue(((ContentResult)retorno).StatusCode == (int)HttpStatusCode.InternalServerError);
        }

        [TestMethod]
        public void API_Controller_Lancamentos_BuscarLancamentoFinanceiroPorID_Sucesso()
        {
            //prepare
            var lancamento = Builder<LancamentoFinanceiro>.CreateNew().Build();

            _lancamentosServicesMock.Setup(_ => _.BuscarLancamentoFinanceiroPorId(It.IsAny<int>())).Returns(lancamento);

            //action
            var retorno = _lancamentosController.BuscarLancamentoFinanceiroPorId(1);

            //assert
            Assert.IsTrue(((ObjectResult)retorno).StatusCode == (int)HttpStatusCode.OK);
        }

        [TestMethod]
        public void API_Controller_Lancamentos_BuscarLancamentoFinanceiroPorID_Nao_Encontrado()
        {
            //prepare
            LancamentoFinanceiro lancamento = null;

            _lancamentosServicesMock.Setup(_ => _.BuscarLancamentoFinanceiroPorId(It.IsAny<int>())).Returns(lancamento);

            //action
            var retorno = _lancamentosController.BuscarLancamentoFinanceiroPorId(1);

            //assert
            Assert.IsTrue(((StatusCodeResult)retorno).StatusCode == (int)HttpStatusCode.NotFound);
        }

        [TestMethod]
        public void API_Controller_Lancamentos_BuscarLancamentoFinanceiroPorID_Erro()
        {
            //prepare
            _lancamentosServicesMock.Setup(_ => _.BuscarLancamentoFinanceiroPorId(It.IsAny<int>())).Throws(new Exception("Ocorreu um erro ao buscar lancamento"));

            //action
            var retorno = _lancamentosController.BuscarLancamentoFinanceiroPorId(1);

            //assert
            Assert.IsTrue(((ContentResult)retorno).StatusCode == (int)HttpStatusCode.InternalServerError);
        }
    }
}
