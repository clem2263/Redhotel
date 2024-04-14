using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    [Table("Rooms")]
    public class Room : IComparable<Room>, IEquatable<Room>
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

        public override string ToString()
        {
            return $"RoomID: {RoomID}\n" +
                   $"Category: {Category}\n" +
                   $"BedsNumber: {BedsNumber}\n" +
                   $"HaveBath: {HaveBath}\n" +
                   $"HotelID: {HotelID}";
        }

        public bool Equals(Room? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return RoomID == other.RoomID && Category == other.Category && BedsNumber == other.BedsNumber && HaveBath == other.HaveBath && HotelID == other.HotelID;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Room)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RoomID, Category, BedsNumber, HaveBath, HotelID);
        }

        public int CompareTo(Room? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var roomIdComparison = Nullable.Compare(RoomID, other.RoomID);
            if (roomIdComparison != 0) return roomIdComparison;
            var categoryComparison = string.Compare(Category, other.Category, StringComparison.Ordinal);
            if (categoryComparison != 0) return categoryComparison;
            var bedsNumberComparison = Nullable.Compare(BedsNumber, other.BedsNumber);
            if (bedsNumberComparison != 0) return bedsNumberComparison;
            var haveBathComparison = Nullable.Compare(HaveBath, other.HaveBath);
            if (haveBathComparison != 0) return haveBathComparison;
            return Nullable.Compare(HotelID, other.HotelID);
        }

    }
}
