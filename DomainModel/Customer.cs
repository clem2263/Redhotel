using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    [Table("Customers")]
    public class Customer : IComparable<Customer>, IEquatable<Customer>
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

        public override string ToString()
        {
            return $"CustomerID: {CustomerID}\n" +
                   $"FirstName: {FirstName}\n" +
                   $"LastName: {LastName}\n" +
                   $"City: {City}\n" +
                   $"Country: {Country}\n" +
                   $"PostalCode: {PostalCode}\n" +
                   $"Address: {Address}";
        }

        public bool Equals(Customer? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return CustomerID == other.CustomerID && FirstName == other.FirstName && LastName == other.LastName && City == other.City && Country == other.Country && PostalCode == other.PostalCode && Address == other.Address && Equals(Reservations, other.Reservations);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Customer)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CustomerID, FirstName, LastName, City, Country, PostalCode, Address, Reservations);
        }

        public int CompareTo(Customer? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var customerIdComparison = Nullable.Compare(CustomerID, other.CustomerID);
            if (customerIdComparison != 0) return customerIdComparison;
            var firstNameComparison = string.Compare(FirstName, other.FirstName, StringComparison.Ordinal);
            if (firstNameComparison != 0) return firstNameComparison;
            var lastNameComparison = string.Compare(LastName, other.LastName, StringComparison.Ordinal);
            if (lastNameComparison != 0) return lastNameComparison;
            var cityComparison = string.Compare(City, other.City, StringComparison.Ordinal);
            if (cityComparison != 0) return cityComparison;
            var countryComparison = string.Compare(Country, other.Country, StringComparison.Ordinal);
            if (countryComparison != 0) return countryComparison;
            var postalCodeComparison = string.Compare(PostalCode, other.PostalCode, StringComparison.Ordinal);
            if (postalCodeComparison != 0) return postalCodeComparison;
            return string.Compare(Address, other.Address, StringComparison.Ordinal);
        }
    }
}