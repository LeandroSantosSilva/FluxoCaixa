using FluxoCaixa.ClientServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Web.Controllers
{
    public class BalancoController : Controller
    {
        private readonly IBalancoClientService _balancoClientService;
       
        public BalancoController(IBalancoClientService balancoClientService)
        {
            _balancoClientService = balancoClientService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var balancoMensalLista = _balancoClientService.GetBalancoMensal(null, null);
            return View(balancoMensalLista);
        }

        [HttpPost]
        public IActionResult Index(bool gerarBalancoDiario = true)
        {
            _balancoClientService.GerarBalancoDiario();

            return RedirectToAction("Index");
        }
    }


}