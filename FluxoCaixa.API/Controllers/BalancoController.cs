using FluxoCaixa.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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

        /// <summary>
        /// Gera o balanço por dia de tudo que está pendendo de consolidação
        /// </summary>
        /// <returns>StatusCode 200 caso consigar gerar o balanço sem erro e 500 caso dê algum erro</returns>
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

        /// <summary>
        /// Busca o balanço por mês de todos os registros que já foram consolidados
        /// </summary>
        /// <param name="ano">Ano para recuperar o balanço, se informar nulo retornará o ano atual</param>
        /// <param name="mesParametro">Mês retorna somente o do mês especificado</param>
        /// <returns>StatusCode 200 caso consiga recuperar os registros, 404 caso não encontre nenhum registro e 500 caso dê algum erro</returns>
        [HttpGet]
        [Route("GetBalancoMensal")]
        public ActionResult GetBalancoMensal([FromQuery] DateTime? ano, DateTime? mesParametro)
        {
            try
            {
                var retornoBalancoMensal = _balancoServices.BuscarBalancoMensal(ano, mesParametro);

                if (!retornoBalancoMensal.Any())
                    return NotFound();

                return Ok(retornoBalancoMensal);
            }
            catch (Exception ex)
            {
                return Result(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}