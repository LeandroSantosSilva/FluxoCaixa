using AutoMapper;
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
    public class LancamentosController : FluxcoCaixaControllerBase
    {
        private readonly ILancamentoServices _lancamentoServices;
        private readonly IMapper _mapper;

        public LancamentosController(ILancamentoServices lancamentoServices, IMapper mapper)
        {
            _lancamentoServices = lancamentoServices;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult InserirLancamentoFinanceiro([FromBody] LancamentoFinanceiroApiModel model)
        {
            try
            {
                _lancamentoServices.InserirLancamento(_mapper.Map<LancamentoFinanceiroApiModel, LancamentoFinanceiro>(model));
                
                return Ok();
            }
            catch (Exception ex)
            {
                return Result(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult AtualizarLancamentoFinanceiro([FromBody] LancamentoFinanceiroApiUpdateModel model)
        {
            try
            {
                _lancamentoServices.AtualizarLancamento(_mapper.Map<LancamentoFinanceiroApiUpdateModel, LancamentoFinanceiro>(model));

                return Ok();
            }
            catch (Exception ex)
            {
                return Result(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult FiltrarLancamentoFinanceiro([FromQuery] LancamentoFinanceiroFiltro model)
        {
            try
            {
                var listaLancamentos = _lancamentoServices.BuscarLancamentoFinanceiro(model.DataLancamento, model.TipoLancamento, model.Consolidado);

                if (!listaLancamentos.Any())
                    return NotFound();

                return Ok(listaLancamentos);
            }
            catch (Exception ex)
            {
                return Result(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _lancamentoServices.ExcluirLancamentoFinanceiro(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return Result(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
