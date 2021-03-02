using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployedAPI.Context;
using EmployedAPI.Models;

namespace EmployedAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionTalksController : ControllerBase
    {
        private readonly ConferenceDbContext _context;

        public SessionTalksController(ConferenceDbContext context)
        {
            _context = context;
        }

        // GET: api/SessionTalks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SessionTalk>>> GetSessionTalks()
        {
            return await _context.SessionTalks.ToListAsync();
        }

        // GET: api/SessionTalks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SessionTalk>> GetSessionTalk(int id)
        {
            var sessionTalk = await _context.SessionTalks.FindAsync(id);

            if (sessionTalk == null)
            {
                return NotFound();
            }

            return sessionTalk;
        }

        // PUT: api/SessionTalks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSessionTalk(int id, SessionTalk sessionTalk)
        {
            if (id != sessionTalk.SessionTalkId)
            {
                return BadRequest();
            }

            _context.Entry(sessionTalk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionTalkExists(id))
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

        // POST: api/SessionTalks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SessionTalk>> PostSessionTalk(SessionTalk sessionTalk)
        {
            _context.SessionTalks.Add(sessionTalk);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSessionTalk", new { id = sessionTalk.SessionTalkId }, sessionTalk);
        }

        // DELETE: api/SessionTalks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSessionTalk(int id)
        {
            var sessionTalk = await _context.SessionTalks.FindAsync(id);
            if (sessionTalk == null)
            {
                return NotFound();
            }

            _context.SessionTalks.Remove(sessionTalk);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SessionTalkExists(int id)
        {
            return _context.SessionTalks.Any(e => e.SessionTalkId == id);
        }
    }
}
