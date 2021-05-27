using GeneralStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GeneralStore.Controllers
{

    public class CustomerController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]

        public async Task<IHttpActionResult> Post(Customer Customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(Customer);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpGet]

        public async Task<IHttpActionResult> GetAll()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetById([FromUri] int id)
        {
            Customer Customer = await _context.Customers.FindAsync(id);
            if (Customer == null)
            {
                return NotFound();
            }
            return Ok(Customer);
        }

        [HttpPut]

        public async Task<IHttpActionResult> UpdateProduct([FromUri] int id, [FromBody] Customer newCustomer)
        {
            if (ModelState.IsValid)
            {
                Customer oldCustomer = await _context.Customers.FindAsync(id);

                if (oldCustomer == null)
                {
                    oldCustomer.FirstName = newCustomer.FirstName;
                    oldCustomer.LastName = newCustomer.LastName;
                    await _context.SaveChangesAsync();
                    return Ok(oldCustomer);
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]

        public async Task<IHttpActionResult> DeleteProduct([FromUri] int id)
        {
            Customer customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok("Good Job! You Win!");
        }
    }
}
