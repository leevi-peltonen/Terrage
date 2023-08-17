using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TerrageApi.Models;

namespace TerrageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillagesController : ControllerBase
    {
        private readonly TerrageApiDBContext _context;

        public VillagesController(TerrageApiDBContext context)
        {
            _context = context;
        }

        // GET: api/Villages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Village>>> GetVillages()
        {
          if (_context.Villages == null)
          {
              return NotFound();
          }
            return await _context.Villages.ToListAsync();
        }

        // GET: api/Villages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Village>> GetVillage(int id)
        {
          if (_context.Villages == null)
          {
              return NotFound();
          }
            var village = await _context.Villages.FindAsync(id);

            if (village == null)
            {
                return NotFound();
            }

            return village;
        }

        // PUT: api/Villages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVillage(int id, Village village)
        {
            if (id != village.ID)
            {
                return BadRequest();
            }

            _context.Entry(village).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VillageExists(id))
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

        // POST: api/Villages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Village>> PostVillage(Village village)
        {
          if (_context.Villages == null)
          {
              return Problem("Entity set 'TerrageApiDBContext.Villages'  is null.");
          }
            _context.Villages.Add(village);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVillage", new { id = village.ID }, village);
        }

        // DELETE: api/Villages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVillage(int id)
        {
            if (_context.Villages == null)
            {
                return NotFound();
            }
            var village = await _context.Villages.FindAsync(id);
            if (village == null)
            {
                return NotFound();
            }

            _context.Villages.Remove(village);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VillageExists(int id)
        {
            return (_context.Villages?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
