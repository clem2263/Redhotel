using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DomainModel
{
    [Table("Hotels")]
    public class Hotel : IComparable<Hotel>, IEquatable<Hotel>
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

        public override string ToString()
        {
            return $"HotelID: {HotelID}\n" +
                   $"Name: {Name}\n" +
                   $"Stars: {Stars}\n" +
                   $"City: {City}\n" +
                   $"Country: {Country}\n" +
                   $"PostalCode: {PostalCode}\n" +
                   $"Address: {Address}\n" +
                   $"HaveSwimmingPool: {HaveSwimmingPool}\n" +
                   $"HaveSpa: {HaveSpa}\n" +
                   $"HaveGolf: {HaveGolf}\n" +
                   $"HaveConferenceRoom: {HaveConferenceRoom}";
        }

        public bool Equals(Hotel? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return HotelID == other.HotelID && Name == other.Name && Stars == other.Stars && City == other.City && Country == other.Country && PostalCode == other.PostalCode && Address == other.Address && HaveSwimmingPool == other.HaveSwimmingPool && HaveSpa == other.HaveSpa && HaveGolf == other.HaveGolf && HaveConferenceRoom == other.HaveConferenceRoom && Equals(Rooms, other.Rooms);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Hotel)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(HotelID);
            hashCode.Add(Name);
            hashCode.Add(Stars);
            hashCode.Add(City);
            hashCode.Add(Country);
            hashCode.Add(PostalCode);
            hashCode.Add(Address);
            hashCode.Add(HaveSwimmingPool);
            hashCode.Add(HaveSpa);
            hashCode.Add(HaveGolf);
            hashCode.Add(HaveConferenceRoom);
            hashCode.Add(Rooms);
            return hashCode.ToHashCode();
        }

        public int CompareTo(Hotel? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var hotelIdComparison = Nullable.Compare(HotelID, other.HotelID);
            if (hotelIdComparison != 0) return hotelIdComparison;
            var nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);
            if (nameComparison != 0) return nameComparison;
            var starsComparison = Nullable.Compare(Stars, other.Stars);
            if (starsComparison != 0) return starsComparison;
            var cityComparison = string.Compare(City, other.City, StringComparison.Ordinal);
            if (cityComparison != 0) return cityComparison;
            var countryComparison = string.Compare(Country, other.Country, StringComparison.Ordinal);
            if (countryComparison != 0) return countryComparison;
            var postalCodeComparison = string.Compare(PostalCode, other.PostalCode, StringComparison.Ordinal);
            if (postalCodeComparison != 0) return postalCodeComparison;
            var addressComparison = string.Compare(Address, other.Address, StringComparison.Ordinal);
            if (addressComparison != 0) return addressComparison;
            var haveSwimmingPoolComparison = Nullable.Compare(HaveSwimmingPool, other.HaveSwimmingPool);
            if (haveSwimmingPoolComparison != 0) return haveSwimmingPoolComparison;
            var haveSpaComparison = Nullable.Compare(HaveSpa, other.HaveSpa);
            if (haveSpaComparison != 0) return haveSpaComparison;
            var haveGolfComparison = Nullable.Compare(HaveGolf, other.HaveGolf);
            if (haveGolfComparison != 0) return haveGolfComparison;
            return Nullable.Compare(HaveConferenceRoom, other.HaveConferenceRoom);
        }
    }
}