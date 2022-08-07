using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetReactJs.Models;

namespace NetReactJs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DCandidatesController : ControllerBase
    {
        private readonly DonationDBContext _context;

        public DCandidatesController(DonationDBContext context)
        {
            _context = context;
        }

        // GET: api/DCandidates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DCandidate>>> GetDcandidates()
        {
          if (_context.Dcandidates == null)
          {
              return NotFound();
          }
            return await _context.Dcandidates.ToListAsync();
        }

        // GET: api/DCandidates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DCandidate>> GetDCandidate(int id)
        {
          if (_context.Dcandidates == null)
          {
              return NotFound();
          }
            var dCandidate = await _context.Dcandidates.FindAsync(id);

            if (dCandidate == null)
            {
                return NotFound();
            }

            return dCandidate;
        }

        // PUT: api/DCandidates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCandidate(int id, DCandidate dCandidate)
        {
            if (id != dCandidate.Id)
            {
                return BadRequest();
            }

            _context.Entry(dCandidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DCandidateExists(id))
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

        // POST: api/DCandidates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DCandidate>> PostDCandidate(DCandidate dCandidate)
        {
          if (_context.Dcandidates == null)
          {
              return Problem("Entity set 'DonationDBContext.Dcandidates'  is null.");
          }
            _context.Dcandidates.Add(dCandidate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCandidate", new { id = dCandidate.Id }, dCandidate);
        }

        // DELETE: api/DCandidates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDCandidate(int id)
        {
            if (_context.Dcandidates == null)
            {
                return NotFound();
            }
            var dCandidate = await _context.Dcandidates.FindAsync(id);
            if (dCandidate == null)
            {
                return NotFound();
            }

            _context.Dcandidates.Remove(dCandidate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DCandidateExists(int id)
        {
            return (_context.Dcandidates?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
