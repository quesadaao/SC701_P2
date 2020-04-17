using Microsoft.AspNetCore.Mvc;
using Solution.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.Core.ViewComponents
{
    public class PaisesViewComponent: ViewComponent
    {
        public IRepositorioPaisEF RepositorioPaisEF { get; set; }

        public PaisesViewComponent(IRepositorioPaisEF repositorioPaisEF) {
            RepositorioPaisEF = repositorioPaisEF;
        }

        public IViewComponentResult Invoke() {
            var paises = RepositorioPaisEF.ObtenerTodosEF();
            return View(paises);
        }
    }
}
