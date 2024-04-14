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
                return Ok(reservations);
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
                var reservation = await context.Reservations.Include(r => r.Hotel).Include(r => r.Room).FirstOrDefaultAsync(r => r.ReservationID == id);

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

        [HttpGet("byHotel/{hotelId}")]
        public async Task<IActionResult> GetReservationsByHotel(int hotelId)
        {
            try
            {
                var reservations = await context.Reservations.Where(r => r.Room != null && r.Room.HotelID == hotelId).ToListAsync();

                if (reservations == null)
                {
                    return NotFound();
                }

                return Ok(reservations);
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

                if (HasOverlappingReservation(reservation))
                {
                    return BadRequest("This room is already booked for the selected dates. Please choose different dates.");
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

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (HasOverlappingReservation(reservation))
                {
                    return BadRequest("This room is already booked for the selected dates. Please choose different dates.");
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

        private bool HasOverlappingReservation(Reservation reservation)
        {
            var existingReservations = context.Reservations
                .Where(r => r.RoomID == reservation.RoomID &&
                           (r.ReservationID != reservation.ReservationID) &&
                           ((r.StartDate < reservation.EndDate && r.EndDate > reservation.StartDate) ||
                            (reservation.StartDate < r.StartDate && reservation.EndDate > r.EndDate)))
                .Any();

            return existingReservations;
        }
    }
}