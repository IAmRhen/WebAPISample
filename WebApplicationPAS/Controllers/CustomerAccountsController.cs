using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationPAS.Data;
using WebApplicationPAS.Models;

namespace WebApplicationPAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAccountsController : ControllerBase
    {
        private readonly PasContext _context;

        public CustomerAccountsController(PasContext context)
        {
            _context = context;
        }

        // GET: api/CustomerAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customeraccount>>> GetCustomeraccounts()
        {
            return await _context.Customeraccounts.ToListAsync();
        }

        // GET: api/CustomerAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customeraccount>> GetCustomeraccount(int id)
        {
            var customeraccount = await _context.Customeraccounts.FindAsync(id);

            if (customeraccount == null)
            {
                return NotFound();
            }

            return customeraccount;
        }

        // PUT: api/CustomerAccounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomeraccount(int id, Customeraccount customeraccount)
        {
            if (id != customeraccount.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customeraccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomeraccountExists(id))
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

        // POST: api/CustomerAccounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customeraccount>> PostCustomeraccount(Customeraccount customeraccount)
        {
            _context.Customeraccounts.Add(customeraccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomeraccount", new { id = customeraccount.CustomerId }, customeraccount);
        }

        // DELETE: api/CustomerAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomeraccount(int id)
        {
            var customeraccount = await _context.Customeraccounts.FindAsync(id);
            if (customeraccount == null)
            {
                return NotFound();
            }

            _context.Customeraccounts.Remove(customeraccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomeraccountExists(int id)
        {
            return _context.Customeraccounts.Any(e => e.CustomerId == id);
        }
    }
}
