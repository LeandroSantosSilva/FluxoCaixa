using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluxoCaixa.Common.Models;
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

        // POST api/values
        [HttpPost]
        public void Post([FromBody] LancamentoFinanceiroModel model)
        {
            //TODO: Incluir automapper
            _lancamentoServices.InserirLancamento(new Dominio.Entidades.LancamentoFinanceiro()
                                            {
                                                StatusLancamento = new Dominio.Entidades.StatusLancamento() { Id = (int)model.StatusLancamento},
                                                TipoLancamento = new Dominio.Entidades.TipoLancamento() { Id = (int)model.TipoLancamento },
                                                Valor = model.Valor
                                            });
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
