using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    [Table("Rooms")]
    public class Room
    {
        public int? RoomID { get; set; }

        [Required]
        [StringLength(50)]
        public string? Category { get; set; }

        [Required]
        public int? BedsNumber { get; set; }

        [Required]
        public Boolean? HaveBath { get; set; }

        public int? HotelID { get; set; }
    }
}
