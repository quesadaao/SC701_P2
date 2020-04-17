using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Solution.Core.Services;

namespace Solution.Core.Controllers
{
    public class PaisController : Controller
    {
        public IRepositorioPais repo { get; }
        public PaisController(IRepositorioPais repositorio) {
            repo = repositorio;
        }
        public IActionResult Index()
        {
            //throw new ApplicationException("Ha ocurrido algo malo");
            //List<string> paises = new List<string>() { "Islandia", "Noruega", "Finlandia","Costa Rica" };
            var paises = repo.ObtenerTodos();
            return View(paises);
        }
    }
}