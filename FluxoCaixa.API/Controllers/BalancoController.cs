using FluxoCaixa.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FluxoCaixa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalancoController : FluxoCaixaControllerBase
    {
        private readonly IBalancoServices _balancoServices;
        public BalancoController(IBalancoServices balancoServices)
        {
            _balancoServices = balancoServices;
        }

        [HttpPost]
        [Route("GerarBalancoDiario")]
        public ActionResult GerarBalancoDiario()
        {
            try
            {

                _balancoServices.GerarBalancoDiario();

                return Ok();
            }
            catch (Exception ex)
            {
                return Result(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}