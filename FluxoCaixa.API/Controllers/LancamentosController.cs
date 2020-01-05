using FluxoCaixa.Common.Models;
using FluxoCaixa.Dominio.Entidades;
using FluxoCaixa.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;

namespace FluxoCaixa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentosController : ControllerBase
    {
        private readonly ILancamentoServices _lancamentoServices;

        public LancamentosController(ILancamentoServices lancamentoServices)
        {
            _lancamentoServices = lancamentoServices;
        }

        [HttpPost]
        public void InserirLancamentoFinanceiro([FromBody] LancamentoFinanceiroApiModel model)
        {
            _lancamentoServices.InserirLancamento(new LancamentoFinanceiro()
            {
                Valor = model.Valor,
                TipoLancamento = new TipoLancamento() { Id = (int)model.TipoLancamento }
            });
        }

        [HttpPut]
        public void AtualizarLancamentoFinanceiro([FromBody] LancamentoFinanceiroApiUpdateModel model)
        {
            _lancamentoServices.AtualizarLancamento(new LancamentoFinanceiro()
            {
                Id = model.Id,
                Valor = model.Valor,
                TipoLancamento = new TipoLancamento() { Id = (int)model.TipoLancamento }
            });
        }

        [HttpGet]
        public ActionResult FiltrarLancamentoFinanceiro([FromQuery] LancamentoFinanceiroFiltro model)
        {
            try
            {
                var listaLancamentos = _lancamentoServices.BuscarLancamentoFinanceiro(model.DataLancamento, model.TipoLancamento, model.Consolidado);

                if (listaLancamentos.Any())
                    return NotFound();

                return Ok(listaLancamentos);
            }
            catch (Exception)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _lancamentoServices.ExcluirLancamentoFinanceiro(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
