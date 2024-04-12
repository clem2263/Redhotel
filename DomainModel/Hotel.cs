using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DomainModel
{
    [Table("Hotels")]
    public class Hotel
    {
        public int? HotelID { get; set; }

        [Required]
        [StringLength(30)]
        public string? Name { get; set; }

        [Required]
        public int? Stars { get; set; }

        [Required]
        [StringLength(30)]
        public string? City { get; set; }

        [Required]
        [StringLength(30)]
        public string? Country { get; set; }

        [Required]
        [StringLength(15)]
        public string? PostalCode { get; set; }

        [Required]
        [StringLength(80)]
        public string? Address { get; set; }

        [Required]
        public Boolean? HaveSwimmingPool { get; set; }

        [Required]
        public Boolean? HaveSpa { get; set; }

        [Required]
        public Boolean? HaveGolf { get; set; }

        [Required]
        public Boolean? HaveConferenceRoom { get; set; }

        public ICollection<Room>? Rooms { get; set; }
    }
}
