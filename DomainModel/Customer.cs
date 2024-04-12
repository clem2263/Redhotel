using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    [Table("Customers")]
    public class Customer
    {
        public int? CustomerID { get; set; }

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

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

        public ICollection<Reservation>? Reservations { get; set; }
    }
}
