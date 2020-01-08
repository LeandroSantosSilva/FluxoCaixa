using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Web.Controllers
{
    public class LancamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}