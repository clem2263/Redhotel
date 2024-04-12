using Microsoft.AspNetCore.Mvc;
using Dal;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace RedHotelAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly RedHotelContext context;

        public CustomerController(RedHotelContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var customers = await context.Customers.ToListAsync();

                if (this.context.Customers == null)
                {
                    return NotFound();
                }

                return Ok(customers);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                var customer = await context.Customers.FindAsync(id);

                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                context.Customers.Add(customer);
                await context.SaveChangesAsync();

                return Ok(context.Customers.FindAsync(customer.CustomerID));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            try
            {
                if (id != customer.CustomerID)
                {
                    return BadRequest();
                }

                if (this.context.Customers.Find(id) == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                context.Entry(customer).State = EntityState.Modified;
                await context.SaveChangesAsync();

                return Ok(context.Customers.FindAsync(customer.CustomerID));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var customer = await context.Customers.FindAsync(id);

                if (customer == null)
                {
                    return NotFound();
                }

                context.Customers.Remove(customer);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}