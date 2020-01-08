using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluxoCaixa.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FluxoCaixa.ClientServices.Interfaces;
using Microsoft.Extensions.Options;
using FluxoCaixa.Common.Configuracao;

namespace FluxoCaixa.Web.Controllers
{
    public class BalancoController : Controller
    {
        private readonly IBalancoMensalClientService _balancoMensalClientService;
       
        public BalancoController(IBalancoMensalClientService balancoMensalClientService)
        {
            _balancoMensalClientService = balancoMensalClientService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var balancoMensalLista = _balancoMensalClientService.GetBalancoMensal(null, null);
            return View(balancoMensalLista);
        }

        [HttpPost]
        public IActionResult Index(bool gerarBalancoDiario = true)
        {
            return RedirectToAction("Index");
        }
    }


}