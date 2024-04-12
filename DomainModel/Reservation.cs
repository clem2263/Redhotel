using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DomainModel
{
    [Table("reservations")]
    public class Reservation
    {
        public int? ReservationID { get; set; }

        public Hotel? Hotel { get; set; }

        public int? HotelID { get; set; }

        public int? CustomerID { get; set; }

        public Room? Room { get; set; }

        public int? RoomID { get; set; }

        public float? Price { get; set; }
    }
}
