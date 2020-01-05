using FluxoCaixa.Data.Repositorio;
using FluxoCaixa.Dominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FizzWare.NBuilder;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace FluxoCaixa.Data.Test
{
    [TestClass]
    public class LancamentoRepositorioTest
    {
        private LancamentoRepositorio _lancamentoRepositorio;
        private Mock<FluxoCaixaContext> _fluxoCaixaContext;
        private LancamentoFinanceiro _lancamentoFinanceiro;

        [TestInitialize]
        public void Inicializar()
        {
            _lancamentoFinanceiro = Builder<LancamentoFinanceiro>.CreateNew().Build();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Repositorio_Atualizar_Lancamento_Nao_Encontrado()
        {
            var mockDbSet = new Mock<DbSet<LancamentoFinanceiro>>();

            var _fluxoCaixaContext = new Mock<FluxoCaixaContext>();
            _fluxoCaixaContext.Setup(m => m.LancamentosFinanceiro).Returns(mockDbSet.Object);

            _lancamentoRepositorio = new LancamentoRepositorio(_fluxoCaixaContext.Object);

            _lancamentoRepositorio.Atualizar(_lancamentoFinanceiro);
        }
    }
}
