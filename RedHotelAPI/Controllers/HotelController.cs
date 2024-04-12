using Microsoft.AspNetCore.Mvc;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using Dal;

namespace RedHotelAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HotelController : Controller
    {
        private readonly RedHotelContext context;

        public HotelController(RedHotelContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            try
            {
                var hotels = await context.Hotels.ToListAsync();

                if (this.context.Hotels == null)
                {
                    return NotFound();
                }

                return Ok(hotels);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            try
            {
                var hotel = await context.Hotels.Include(h => h.Rooms).FirstOrDefaultAsync(h => h.HotelID == id);

                if (hotel == null)
                {
                    return NotFound();
                }
                return Ok(hotel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] Hotel hotel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                context.Hotels.Add(hotel);
                await context.SaveChangesAsync();

                return Ok(context.Hotels.FindAsync(hotel.HotelID));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] Hotel hotel)
        {
            try
            {
                if (id != hotel.HotelID)
                {
                    return BadRequest();
                }

                if (this.context.Hotels.Find(id) == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                context.Entry(hotel).State = EntityState.Modified;
                await context.SaveChangesAsync();

                return Ok(context.Hotels.FindAsync(hotel.HotelID));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            try
            {
                var hotel = await context.Hotels.FindAsync(id);

                if (hotel == null)
                {
                    return NotFound();
                }

                context.Hotels.Remove(hotel);
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