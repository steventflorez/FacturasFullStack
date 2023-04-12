using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gestion_facturas.DataAcces;
using Gestion_facturas.Models.DataModels;

namespace Gestion_facturas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceLinesController : ControllerBase
    {
        private readonly FacturasDBContext _context;

        public InvoiceLinesController(FacturasDBContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceLine>>> GetInvoiceLine()
        {
          if (_context.InvoiceLine == null)
          {
              return NotFound();
          }
            return await _context.InvoiceLine.ToListAsync();
        }

        // GET: api/InvoiceLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceLine>> GetInvoiceLine(int id)
        {
          if (_context.InvoiceLine == null)
          {
              return NotFound();
          }
            var invoiceLine = await _context.InvoiceLine.FindAsync(id);

            if (invoiceLine == null)
            {
                return NotFound();
            }

            return invoiceLine;
        }

        // PUT: api/InvoiceLines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceLine(int id, InvoiceLine invoiceLine)
        {
            if (id != invoiceLine.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoiceLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceLineExists(id))
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

        // POST: api/InvoiceLines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvoiceLine>> PostInvoiceLine(InvoiceLine invoiceLine)
        {
          if (_context.InvoiceLine == null)
          {
              return Problem("Entity set 'FacturasDBContext.InvoiceLine'  is null.");
          }
            _context.InvoiceLine.Add(invoiceLine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceLine", new { id = invoiceLine.Id }, invoiceLine);
        }

        // DELETE: api/InvoiceLines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceLine(int id)
        {
            if (_context.InvoiceLine == null)
            {
                return NotFound();
            }
            var invoiceLine = await _context.InvoiceLine.FindAsync(id);
            if (invoiceLine == null)
            {
                return NotFound();
            }

            _context.InvoiceLine.Remove(invoiceLine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceLineExists(int id)
        {
            return (_context.InvoiceLine?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
