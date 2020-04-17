using Solution.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.Core.Services
{
    public interface IRepositorioPaisEF
    {
        List<Pais> ObtenerTodosEF();
    }
}
