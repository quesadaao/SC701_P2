using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solution.APIWDBFirst.Models;

namespace Solution.APIWDBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly CoreContext _context;

        public PaisesController(CoreContext context)
        {
            _context = context;
        }

        // GET: api/Paises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paises>>> GetPaises()
        {
            return await _context.Paises.ToListAsync();
        }

        // GET: api/Paises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paises>> GetPaises(int id)
        {
            var paises = await _context.Paises.FindAsync(id);

            if (paises == null)
            {
                return NotFound();
            }

            return paises;
        }

        // PUT: api/Paises/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaises(int id, Paises paises)
        {
            if (id != paises.Id)
            {
                return BadRequest();
            }

            _context.Entry(paises).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Paises
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Paises>> PostPaises(Paises paises)
        {
            _context.Paises.Add(paises);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaises", new { id = paises.Id }, paises);
        }

        // DELETE: api/Paises/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Paises>> DeletePaises(int id)
        {
            var paises = await _context.Paises.FindAsync(id);
            if (paises == null)
            {
                return NotFound();
            }

            _context.Paises.Remove(paises);
            await _context.SaveChangesAsync();

            return paises;
        }

        private bool PaisesExists(int id)
        {
            return _context.Paises.Any(e => e.Id == id);
        }
    }
}
