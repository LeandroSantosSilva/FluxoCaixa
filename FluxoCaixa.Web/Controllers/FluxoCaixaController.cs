using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FluxoCaixa.Web.Models;
using System.Net;
using System.Net.Http;

namespace FluxoCaixa.Web.Controllers
{
    public class FluxoCaixaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }      
    }
}
