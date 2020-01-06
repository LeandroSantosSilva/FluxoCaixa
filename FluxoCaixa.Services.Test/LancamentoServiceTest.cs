using FizzWare.NBuilder;
using FluxoCaixa.Data.Interface;
using FluxoCaixa.Dominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework.Internal;
using System;
using System.Linq;

namespace FluxoCaixa.Services.Test
{
    [TestClass]
    public class LancamentoServiceTest
    {
        private LancamentoServices _lancamentoServices;
        private Mock<ILancamentoRepositorio> _lancamentoRepositorioMock;
        private LancamentoFinanceiro _lancamentoFinanceiro;

        [TestInitialize]
        public void Iniciarlizar()
        {
            _lancamentoRepositorioMock = new Mock<ILancamentoRepositorio>();
            _lancamentoServices = new LancamentoServices(_lancamentoRepositorioMock.Object);
            _lancamentoFinanceiro =Builder<LancamentoFinanceiro>.CreateNew().Build();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Service_Atualizar_Lancamento_Sem_Permissao_Edicao_Com_Valor0()
        {
            //prepare
            _lancamentoFinanceiro.Valor = 0;
            _lancamentoFinanceiro.TipoLancamento = new TipoLancamento() { Id = 1 };

            //action
            _lancamentoServices.AtualizarLancamento(_lancamentoFinanceiro);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Service_Atualizar_Lancamento_Sem_Permissao_Edicao_Sem_TipoLancamento()
        {
            //prepare
            _lancamentoFinanceiro.Valor = 10;
            
            //action
            _lancamentoServices.AtualizarLancamento(_lancamentoFinanceiro);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Service_Atualizar_Lancamento_Sem_Permissao_Edicao_Consolidado()
        {
            //prepare
            _lancamentoFinanceiro.Valor = 10;
            _lancamentoFinanceiro.TipoLancamento = new TipoLancamento() { Id = 1 };

            _lancamentoRepositorioMock.Setup(_ => _.ValidarLancamentoConsolidado(It.IsAny<int>())).Returns(true);

            //action
            _lancamentoServices.AtualizarLancamento(_lancamentoFinanceiro);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Service_Atualizar_Lancamento_Sem_Permissao_Edicao_Nao_Existe_Lancamento()
        {
            //prepare
            _lancamentoFinanceiro.Valor = 10;
            _lancamentoFinanceiro.TipoLancamento = new TipoLancamento() { Id = 1 };

            _lancamentoRepositorioMock.Setup(_ => _.ValidarLancamentoExiste(It.IsAny<int>())).Returns(false);

            //action
            _lancamentoServices.AtualizarLancamento(_lancamentoFinanceiro);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Service_Atualizar_Lancamento_Sem_Permissao_Edicao_Nao_Existe_TipoLancamento_Cadastrado()
        {
            //prepare
            _lancamentoFinanceiro.Valor = 10;
            _lancamentoFinanceiro.TipoLancamento = new TipoLancamento() { Id = 1 };

            _lancamentoRepositorioMock.Setup(_ => _.ExisteTipoLancamento(It.IsAny<int>())).Returns(false);

            //action
            _lancamentoServices.AtualizarLancamento(_lancamentoFinanceiro);
        }

        [TestMethod]
        public void Service_Atualizar_Lancamento_Sucesso()
        {
            //prepare
            _lancamentoFinanceiro.Valor = 10;
            _lancamentoFinanceiro.TipoLancamento = new TipoLancamento() { Id = 1 };

            _lancamentoRepositorioMock.Setup(_ => _.ExisteTipoLancamento(It.IsAny<int>())).Returns(true);
            _lancamentoRepositorioMock.Setup(_ => _.Atualizar(It.IsAny<LancamentoFinanceiro>()));

            //action
            _lancamentoServices.AtualizarLancamento(_lancamentoFinanceiro);

            //assert
            _lancamentoRepositorioMock.Verify();
        }

        [TestMethod]
        public void Service_Buscar_Lancamento_Sucesso()
        {
            //prepare
            var listaRetorno = Builder<LancamentoFinanceiro>.CreateListOfSize(10).Build();

            _lancamentoRepositorioMock.Setup(_ => _.Buscar(It.IsAny<DateTime?>(), It.IsAny<int?>(), It.IsAny<bool?>())).Returns(listaRetorno.ToList());

            //action
            var lancamentos = _lancamentoServices.BuscarLancamentoFinanceiro(null, null, null);

            //assert
            _lancamentoRepositorioMock.Verify();
            Assert.IsTrue(lancamentos.Any());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Service_Excluir_Lancamento_Nao_Existe_Lancamento()
        {
            //prepare
            _lancamentoRepositorioMock.Setup(_ => _.ValidarLancamentoExiste(It.IsAny<long>())).Returns(false);

            //action
            _lancamentoServices.ExcluirLancamentoFinanceiro(1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Service_Excluir_Lancamento_Consolidado()
        {
            //prepare
            _lancamentoRepositorioMock.Setup(_ => _.ValidarLancamentoConsolidado(It.IsAny<long>())).Returns(true);

            //action
            _lancamentoServices.ExcluirLancamentoFinanceiro(1);
        }

        [TestMethod]
        public void Service_Excluir_Lancamento_Sucesso()
        {
            //prepare
            _lancamentoRepositorioMock.Setup(_ => _.Excluir(It.IsAny<int>()));
            _lancamentoRepositorioMock.Setup(_ => _.ValidarLancamentoExiste(It.IsAny<long>())).Returns(true);
            _lancamentoRepositorioMock.Setup(_ => _.ValidarLancamentoConsolidado(It.IsAny<long>())).Returns(false);

            //action
            _lancamentoServices.ExcluirLancamentoFinanceiro(1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Service_Inserir_Lancamento_Sem_Permissao_Inserir_Valor0()
        {
            // prepare
            _lancamentoFinanceiro.Valor = 0;
            _lancamentoFinanceiro.TipoLancamento = new TipoLancamento() { Id = 1 };

            //action
            _lancamentoServices.InserirLancamento(_lancamentoFinanceiro);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Service_Inserir_Lancamento_Sem_Permissao_Sem_Tipo_Lancamento()
        {
            //prepare
            _lancamentoFinanceiro.Valor = 10;

            //action
            _lancamentoServices.InserirLancamento(_lancamentoFinanceiro);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Service_Inserir_Lancamento_Sem_Permissao_Edicao_Nao_Existe_TipoLancamento_Cadastrado()
        {
            //prepare
            _lancamentoFinanceiro.Valor = 10;
            _lancamentoFinanceiro.TipoLancamento = new TipoLancamento() { Id = 1 };

            _lancamentoRepositorioMock.Setup(_ => _.ExisteTipoLancamento(It.IsAny<int>())).Returns(false);

            //action
            _lancamentoServices.InserirLancamento(_lancamentoFinanceiro);
        }
    }
}
