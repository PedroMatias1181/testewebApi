using System;
using System.Linq;
using System.Threading.Tasks;
using FirstExercice.Infrastructure;
using FirstExercice.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstExercice.Controllers
{
    [Produces("application/json")]
    [Route("v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly DbApiContext _context;
        public CustomerController(DbApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _context.Customers
                   .Select(
                   (c => new
                   {
                       c.FirstName,
                       c.LastName,
                       c.Address,
                       Contact = c.Address,
                       TotalInvoices = c.Invoices.Count
                   }));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var response = _context.Customers.Where(x => x.CustomerId == id)
                   .Select(
                   (c => new
                   {
                       c.FirstName,
                       c.LastName,
                       c.Address,
                       c.Contact,
                       TotalInvoices = c.Invoices.Count()
                   }));

            if (response.Count() == 0)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Add(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            try
            {
                customer.CustomerId = await _context.Customers.MaxAsync(x => x.CustomerId) + 1;
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();

                var response = new
                {
                    FullName = customer.FirstName + " " + customer.LastName,
                    customer.Address,
                    customer.Contact
                };
                return Ok(response);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }
            try
            {
                Customer originalCustomer = await _context.Customers.SingleOrDefaultAsync(x => x.CustomerId == id);
                _context.Entry(originalCustomer).CurrentValues.SetValues(customer);
                await _context.SaveChangesAsync();
                return Ok();
            }

            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteTodoItem(int id)
        {
            Customer customers = await _context.Customers.FindAsync(id);

            if (customers == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customers);
            await _context.SaveChangesAsync();

            return customers;
        }

    }
}
