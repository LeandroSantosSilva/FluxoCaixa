using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluxoCaixa.Common.Models;
using FluxoCaixa.Dominio.Entidades;
using FluxoCaixa.Services.Interface;
using Microsoft.AspNetCore.Mvc;


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
        public ActionResult FiltrarLancamentoFinanceiro([FromBody] LancamentoFinanceiroFiltro model)
        {
            var listaLancamentos = _lancamentoServices.BuscarLancamentoFinanceiro(model.DataLancamento, model.TipoLancamento, model.Consolidado);

            return Ok(listaLancamentos);
        }




        //// GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] LancamentoFinanceiroModel model)
        //{

        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
