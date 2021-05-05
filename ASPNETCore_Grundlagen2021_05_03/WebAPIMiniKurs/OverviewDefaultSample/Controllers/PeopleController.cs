using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OverviewDefaultSample.Data;
using OverviewDefaultSample.Models;

namespace OverviewDefaultSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PersonDbContext _context;

        public PeopleController(PersonDbContext context)
        {
            _context = context;
        }

        //Get-All:  -> URL:  https://localhost:12345/api/People
        //Get-ById: -> URL:  https://localhost:12345/api/People/5
        //Post:     -> URL:  https://localhost:12345/api/People/5
        //Put:      -> URL:  https://localhost:12345/api/People
        //Delete:   -> URL:  https://localhost:12345/api/People/5



        #region Get-Methoden
        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonen()
        {
            return await _context.Personen.ToListAsync();
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _context.Personen.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        #endregion


        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _context.Personen.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.Personen.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Personen.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return _context.Personen.Any(e => e.Id == id);
        }
    }
}
