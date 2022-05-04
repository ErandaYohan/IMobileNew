using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database.Authentication;
using Database.Models;

namespace Backend_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class categoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public categoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<categories>>> Getcategories()
        {
            return await _context.categories.ToListAsync();
        }

        // GET: api/categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<categories>> Getcategories(int id)
        {
            var categories = await _context.categories.FindAsync(id);

            if (categories == null)
            {
                return NotFound();
            }

            return categories;
        }

        // PUT: api/categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcategories(int id, categories categories)
        {
            if (id != categories.CatId)
            {
                return BadRequest();
            }

            _context.Entry(categories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!categoriesExists(id))
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

        // POST: api/categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<categories>> Postcategories(categories categories)
        {
            _context.categories.Add(categories);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcategories", new { id = categories.CatId }, categories);
        }

        // DELETE: api/categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<categories>> Deletecategories(int id)
        {
            var categories = await _context.categories.FindAsync(id);
            if (categories == null)
            {
                return NotFound();
            }

            _context.categories.Remove(categories);
            await _context.SaveChangesAsync();

            return categories;
        }

        private bool categoriesExists(int id)
        {
            return _context.categories.Any(e => e.CatId == id);
        }
    }
}
