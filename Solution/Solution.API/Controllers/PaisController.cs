using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Solution.DAL.EF;
using data = Solution.DO.Objects;

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : Controller
    {
        private readonly SolutionDBContext _context;

        public PaisController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/Pais
        //[Route("api/Pais/GetPais")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Pais>>> GetPais()
        {
            return new Solution.BS.Pais(_context).GetAll().ToList();
        }

        // GET: api/Pais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Pais>> GetPais(int id)
        {
            var Pais = new Solution.BS.Pais(_context).GetOneById(id);

            if (Pais == null)
            {
                return NotFound();
            }

            return Pais;
            //return null;
        }

        // PUT: api/Pais/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPais(int id, data.Pais Pais)
        {
            if (id != Pais.Id)
            {
                return BadRequest();
            }

            try
            {
                new Solution.BS.Pais(_context).Updated(Pais);
            }
            catch (Exception)
            {
                if (!PaisExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
            //return null;
        }

        // POST: api/Pais
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<data.Pais>> PostPais(data.Pais Pais)
        {
            new Solution.BS.Pais(_context).Insert(Pais);
            int _id = Pais.Id.Value;
            //return new Solution.BS.Pais(_context).GetOneById(_id); 3
            return Pais;
        }

        // DELETE: api/Pais/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Pais>> DeletePais(int id)
        {
            var Pais = new Solution.BS.Pais(_context).GetOneById(id);
            if (Pais == null)
            {
                return NotFound();
            }

            new Solution.BS.Pais(_context).Delete(Pais);


            return Pais;
            //return null;
        }

        private bool PaisExists(int id)
        {
            return (new Solution.BS.Pais(_context).GetOneById(id)!=null);
        }
    }


}