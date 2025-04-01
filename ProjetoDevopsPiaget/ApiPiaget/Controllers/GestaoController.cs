using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiPiaget.Data;
using ApiPiaget.Models;

namespace ApiPiaget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestaoController : ControllerBase
    {
        private readonly ApiPiagetContext _context;

        public GestaoController(ApiPiagetContext context)
        {
            _context = context;
        }

        // GET: api/Gestao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gestao>>> GetGestao()
        {
            return await _context.Gestao.ToListAsync();
        }

        // GET: api/Gestao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gestao>> GetGestao(int id)
        {
            var gestao = await _context.Gestao.FindAsync(id);

            if (gestao == null)
            {
                return NotFound();
            }

            return gestao;
        }

        // PUT: api/Gestao/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGestao(int id, Gestao gestao)
        {
            if (id != gestao.Id)
            {
                return BadRequest();
            }

            _context.Entry(gestao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GestaoExists(id))
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

        // POST: api/Gestao
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gestao>> PostGestao(Gestao gestao)
        {
            _context.Gestao.Add(gestao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGestao", new { id = gestao.Id }, gestao);
        }

        // DELETE: api/Gestao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGestao(int id)
        {
            var gestao = await _context.Gestao.FindAsync(id);
            if (gestao == null)
            {
                return NotFound();
            }

            _context.Gestao.Remove(gestao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GestaoExists(int id)
        {
            return _context.Gestao.Any(e => e.Id == id);
        }
    }
}
