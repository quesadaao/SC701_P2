using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.Core.Services
{
    public class PaisRepositorioEnMemoria : IRepositorioPais
    {
        public List<string> ObtenerTodos() {
            List<string> paises = new List<string>() { "Islandia", "Noruega", "Finlandia", "Costa Rica", "Argentina" };
            return paises;
        }
    }
}
