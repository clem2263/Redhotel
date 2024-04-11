using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    [Table("Hotels")]
    public class Hotel
    {
        public int HotelID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public int Stars { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }

        [Required]
        [StringLength(30)]
        public string Country { get; set; }

        [Required]
        [StringLength(30)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(30)]
        public string Address { get; set; }

        public Boolean HaveSwimmingPool { get; set; }

        public Boolean HaveSpa { get; set; }

        public Boolean HaveGolf { get; set; }

        public Boolean HaveConferenceRoom { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
