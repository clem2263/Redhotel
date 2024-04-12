using Microsoft.AspNetCore.Mvc;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using Dal;

namespace RedHotelAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservationController : Controller
    {
        private readonly RedHotelContext context;

        public ReservationController(RedHotelContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            try
            {
                var reservations = await context.Reservations.ToListAsync();

                if(reservations == null)
                {
                    return NotFound();
                }
                return Ok(this.context.Customers.ToList());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById(int id)
        {
            try
            {
                var reservation = await context.Reservations.FindAsync(id);

                if (reservation == null)
                {
                    return NotFound();
                }
                return Ok(reservation);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] Reservation reservation)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                context.Reservations.Add(reservation);
                await context.SaveChangesAsync();

                return Ok(context.Reservations.FindAsync(reservation.ReservationID));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, [FromBody] Reservation reservation)
        {
            try
            {
                if (id != reservation.ReservationID)
                {
                    return BadRequest();
                }

                if (this.context.Reservations.Find(id) == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                context.Entry(reservation).State = EntityState.Modified;
                await context.SaveChangesAsync();

                return Ok(context.Reservations.FindAsync(reservation.ReservationID));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            try
            {
                var reservation = await context.Reservations.FindAsync(id);

                if (reservation == null)
                {
                    return NotFound();
                }

                context.Reservations.Remove(reservation);
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