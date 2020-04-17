using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Solution.Core.Services;

namespace Solution.Core.Controllers
{
    public class PaisEFController : Controller
    {
        public IRepositorioPaisEF repo { get; set; }

        public PaisEFController(IRepositorioPaisEF repositorio) {
            repo = repositorio;
        }

        public IActionResult Index()
        {
            var paises = repo.ObtenerTodosEF();
            return View(paises);
        }
    }
}