using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database.Authentication;
using Database.Models;

namespace Backend_API.Controllers.Shipping
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingInfoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ShippingInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ShippingInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShippingInfo>>> GetShippingInfo()
        {
            return await _context.ShippingInfo.ToListAsync();
        }

        // GET: api/ShippingInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShippingInfo>> GetShippingInfo(int id)
        {
            var shippingInfo = await _context.ShippingInfo.FindAsync(id);

            if (shippingInfo == null)
            {
                return NotFound();
            }

            return shippingInfo;
        }

        // PUT: api/ShippingInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShippingInfo(int id, ShippingInfo shippingInfo)
        {
            if (id != shippingInfo.shippingId)
            {
                return BadRequest();
            }

            _context.Entry(shippingInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippingInfoExists(id))
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

        // POST: api/ShippingInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShippingInfo>> PostShippingInfo(ShippingInfo shippingInfo)
        {
            _context.ShippingInfo.Add(shippingInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShippingInfo", new { id = shippingInfo.shippingId }, shippingInfo);
        }

        // DELETE: api/ShippingInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShippingInfo>> DeleteShippingInfo(int id)
        {
            var shippingInfo = await _context.ShippingInfo.FindAsync(id);
            if (shippingInfo == null)
            {
                return NotFound();
            }

            _context.ShippingInfo.Remove(shippingInfo);
            await _context.SaveChangesAsync();

            return shippingInfo;
        }

        private bool ShippingInfoExists(int id)
        {
            return _context.ShippingInfo.Any(e => e.shippingId == id);
        }
    }
}
