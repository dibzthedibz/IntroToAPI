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
                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpGet]

        public async Task<IHttpActionResult> GetAll()
        {
            List<Transaction> transactions = await _context.Transactions.ToListAsync();
            return Ok(transactions);
        }

        [HttpGet]

        public async Task<IHttpActionResult> GetById([FromUri] int id) 
        {
            Transaction transaction = await _context.Transactions.FindAsync(id);
            if(transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateTransaction([FromUri] int id, [FromBody] Transaction newTransaction)
        {
            if (ModelState.IsValid)
            {
                Product product = await _context.Products.FindAsync(newTransaction.ProductId);
                if (product == null)
                {
                    return BadRequest("Invalid Product Id");
                }

                Customer customer = await _context.Customers.FindAsync(newTransaction.CustomerId);
                if (customer == null)
                {
                    return BadRequest("Invalid customer id");
                }

                Transaction oldTransaction = await _context.Transactions.FindAsync(id);
                if(oldTransaction != null)
                {
                    int difference = oldTransaction.PQuan - newTransaction.PQuan;

                    product.Quantity += difference;
                    oldTransaction.ProductId = newTransaction.ProductId;
                    oldTransaction.PQuan = newTransaction.PQuan;
                    oldTransaction.CustomerId = newTransaction.CustomerId;
                    if (newTransaction.DateOfTransaction != null && newTransaction.DateOfTransaction != default)
                    {
                        oldTransaction.DateOfTransaction = newTransaction.DateOfTransaction;
                    }
                    await _context.SaveChangesAsync();
                    return Ok(oldTransaction);
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return Ok("You Did it again!");
        }
    }
}