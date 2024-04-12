using Dal;
using DomainModel;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet] // Accéder à l'hôtel
        public IActionResult GetAll()
        {
            return Ok(this.context.Hotels.ToList());
        }

        [HttpGet("{id}")] // Lister un hôtel

        public async Task<IActionResult> GetHotelById(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var hotel = await context.Hotels.FindAsync(id);

                if (hotel == null)
                {
                    Console.WriteLine($"[ HotelController ] - GetHotelById - the specified hotel was not found in the database, id : {id}");
                    return NotFound();
                }

                return Ok(hotel);
            }
            catch (Exception e)
            {
                Console.WriteLine($"[ HotelController ] - GetAll - an error has occurred while retrieving all hotels : {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost] // Créer un hôtel

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

                return CreatedAtRoute("GetHotel", new { id = hotel.HotelID }, hotel);
            }
            catch (Exception e)
            {
                Console.WriteLine($"[ HotelController ] - GetAll - an error has occurred while retrieving all hotels : {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")] // Modifier un hôtel 

        public async Task<IActionResult> UpdateHotel(int id, [FromBody] Hotel hotel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != hotel.HotelID)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine($"[ HotelController ] - GetAll - an error has occurred while retrieving all hotels : {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")] // Supprime un hôtel

        public async Task<IActionResult> DeleteHotel(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

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
                Console.WriteLine($"[ CustomerController ] - GetAll - an error has occurred while retrieving all hotels : {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

    }
}
