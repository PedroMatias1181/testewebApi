using FirstExercice.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FirstExercice.Controllers
{
    [Produces("application/json")]
    [Route("v1/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {

        private readonly DbApiContext _context;
        public InvoicesController(DbApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _context.Invoices.Select(
                   (i => new
                   {
                       i.InvoiceCode,
                       Date = i.Date.ToString("dd/MM/yyyy"),
                       CustomerName = i.Customer.FirstName + i.Customer.LastName,
                       CustomerContact = i.Customer.Contact,
                       TotalItens = i.Items.Sum(x => x.Quantity),
                       TotalValue = i.Items.Sum(x => x.Quantity * x.Price)
                   }));

            return Ok(response);
        }

    }
}
