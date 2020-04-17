using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solution.Core.Data;
using Solution.Core.Models;

namespace Solution.Core.Services
{
    public class PaisRepositorioEF : IRepositorioPaisEF
    {
        public ApplicationDbContext DbContext;
        public PaisRepositorioEF(ApplicationDbContext dbContext) {
            DbContext = dbContext;
        }

        public List<Pais> ObtenerTodosEF()
        {
            return DbContext.Paises.ToList();
        }
    }
}
