using GeneralStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace GeneralStore.Controllers
{
    public class TransactionController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [HttpGet]

        public async Task<IHttpActionResult> GetAll()
        {
            List<Transaction> transactions = await _context.Transactions.ToListAsync();
            return Ok(transactions);
        }

        [HttpGet]

        public async Task<IHttpActionResult> GetById(int id)
        {

        }
        [HttpPost]

        public async Task<IHttpActionResult> Post(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                Product product = await _context.Products.FindAsync(transaction.ProductId);
                if (product == null)
                {
                    return BadRequest("Invalid Product Id");
                }

                Customer customer = await _context.Customers.FindAsync(transaction.CustomerId);
                if (customer == null)
                {
                    return BadRequest("Invalid customer id");
                }

                if (transaction.PQuan > product.Quantity)
                {
                    return BadRequest($"There are only {product.Quantity} left in stock!");
                }

                product.Quantity -= transaction.PQuan;

                transaction.DateOfTransaction = DateTime.Now;
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}