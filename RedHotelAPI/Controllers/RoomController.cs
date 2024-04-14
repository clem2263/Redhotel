using Microsoft.AspNetCore.Mvc;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using Dal;

namespace RedHotelAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly RedHotelContext context;

        public RoomController(RedHotelContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            try
            {
                var rooms = await context.Rooms.ToListAsync();

                if (this.context.Rooms == null)
                {
                    return NotFound();
                }
                return Ok(rooms);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            try
            {
                var room = await context.Rooms.FindAsync(id);

                if (room == null)
                {
                    return NotFound();
                }
                return Ok(room);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] Room room)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                context.Rooms.Add(room);
                await context.SaveChangesAsync();

                return Ok(context.Rooms.FindAsync(room.RoomID));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] Room room)
        {
            try
            {
                if (id != room.RoomID)
                {
                    return BadRequest();
                }

                context.Entry(room).State = EntityState.Modified;
                await context.SaveChangesAsync();

                return Ok(context.Rooms.FindAsync(room.RoomID));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            try
            {
                var room = await context.Rooms.FindAsync(id);

                if (room == null)
                {
                    return NotFound();
                }

                context.Rooms.Remove(room);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        public string ToUppercase(string inputString)
        {
            return inputString.ToUpper();
        }
    }
}