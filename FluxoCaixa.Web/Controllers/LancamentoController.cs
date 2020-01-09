using AutoMapper;
using FluxoCaixa.ClientServices.Interfaces;
using FluxoCaixa.Common.Models;
using FluxoCaixa.Common.Models.ViewModel;
using FluxoCaixa.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FluxoCaixa.Web.Controllers
{
    public class LancamentoController : Controller
    {
        private readonly ILancamentoFinanceiroClientServices _lancamentoFinanceiroClientServices;
        private readonly IMapper _mapper;

        public LancamentoController(ILancamentoFinanceiroClientServices lancamentoFinanceiroClientServices, IMapper mapper)
        {
            _lancamentoFinanceiroClientServices = lancamentoFinanceiroClientServices;
            _mapper = mapper;
        }

        public IActionResult Index(DateTime? data, int? tipoLancamento, bool? consolidado)
        {
            try
            {
                var model = new LancamentoFinanceiroFiltroViewModel();

                var listaLancamentos = _lancamentoFinanceiroClientServices.FiltrarLancamentosFinanceiro(new LancamentoFinanceiroFiltro() { DataLancamento = data, TipoLancamento = tipoLancamento, Consolidado = consolidado });
                model.ListaLancamentoFinanceiro = _mapper.Map<List<LancamentoFinanceiroModel>, List<LancamentoFinanceiroViewModel>>(listaLancamentos.ToList());

                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            var model = new LancamentoFinanceiroInserirViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Cadastrar(LancamentoFinanceiroInserirViewModel model)
        {
            try
            {
                _lancamentoFinanceiroClientServices.InserirLancamentoFinaneiro(_mapper.Map<LancamentoFinanceiroInserirViewModel, LancamentoFinanceiroApiModel>(model));

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult Excluir(int id)
        {
            try
            {
                _lancamentoFinanceiroClientServices.ExcluirLancamentoFinanceiro(id);
            }
            catch (Exception ex)
            {
                return Json(new { erro = true, mensagem = $"Ocorre um erro ao excluir lançamento {ex.Message}" });
            }
            return Json(new { erro = false, mensagem = "Lançamento excluído com sucesso" });
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            try
            {
                var model = _mapper.Map<LancamentoFinanceiroModel, LancamentoFinanceiroInserirViewModel>(_lancamentoFinanceiroClientServices.GetLancamentoFinanceiro(id));

                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Editar(LancamentoFinanceiroInserirViewModel model)
        {
            try
            {
                _lancamentoFinanceiroClientServices.AtualizarLancamentoFinanceiro(_mapper.Map<LancamentoFinanceiroInserirViewModel, LancamentoFinanceiroApiUpdateModel>(model));

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}