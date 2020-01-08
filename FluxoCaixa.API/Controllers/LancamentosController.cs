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
    public class LancamentosController : FluxoCaixaControllerBase
    {
        private readonly ILancamentoServices _lancamentoServices;
        private readonly IMapper _mapper;

        public LancamentosController(ILancamentoServices lancamentoServices, IMapper mapper)
        {
            _lancamentoServices = lancamentoServices;
            _mapper = mapper;
        }

        /// <summary>
        /// Insere um lançamento financeiro
        /// </summary>
        /// <param name="model">Parametro que será utilizado para informar o valor e o tipo lançamento</param>
        /// <returns>StatusCode 200 caso consiga inserir com sucesso e 500 caso dê algum erro</returns>
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

        /// <summary>
        /// Atualiza um lançamento financeiro
        /// Após atualização o registro é marcado para ser consolidado novamente
        /// </summary>
        /// <param name="model">Parametro que será utilizado para informar o valor e o tipo lançamento</param>
        /// <returns>StatusCode 200 se não deu erro ao atualizar e 500 caso dê algum erro</returns>
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

        /// <summary>
        /// Busca os lançamentos financeiros cadastrados
        /// </summary>
        /// <param name="model">Parametro que será utilizado para informar a data,tipo lançamento e consolidado</param>
        /// <returns>StatusCode 200 se não deu erro e a lista com os resultados, 404 caso não encontre nenhum registro e 500 caso dê algum erro</returns>
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

        /// <summary>
        /// Excluir um lançamento financeiro
        /// Caso o lançamento já esteja consolidado será retornado um mensagem que não é permitido excluir o lançamento
        /// </summary>
        /// <param name="id">Id do lançamento financeiro salvo na base de dados</param>
        /// <returns>StatusCode 200 se conseguiu excluir e 500 caso dê algum erro</returns>
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
