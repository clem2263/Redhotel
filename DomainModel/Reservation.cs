using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DomainModel
{
    [Table("reservations")]
    public class Reservation : IComparable<Reservation>, IEquatable<Reservation>
    {
        public int? ReservationID { get; set; }

        public Hotel? Hotel { get; set; }

        public int? HotelID { get; set; }

        public int? CustomerID { get; set; }

        public Room? Room { get; set; }

        public int? RoomID { get; set; }

        public float? Price { get; set; }

        public override string ToString()
        {
            return $"ReservationID: {ReservationID}\n" +
                   $"Hotel: {Hotel?.ToString()}\n" +
                   $"HotelID: {HotelID}\n" +
                   $"CustomerID: {CustomerID}\n" +
                   $"Room: {Room?.ToString()}\n" +
                   $"RoomID: {RoomID}\n" +
                   $"Price: {Price}";
        }

        public bool Equals(Reservation? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return ReservationID == other.ReservationID && Equals(Hotel, other.Hotel) && HotelID == other.HotelID && CustomerID == other.CustomerID && Equals(Room, other.Room) && RoomID == other.RoomID && Nullable.Equals(Price, other.Price);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Reservation)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ReservationID, Hotel, HotelID, CustomerID, Room, RoomID, Price);
        }

        public int CompareTo(Reservation? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var reservationIdComparison = Nullable.Compare(ReservationID, other.ReservationID);
            if (reservationIdComparison != 0) return reservationIdComparison;
            var hotelComparison = Comparer<Hotel?>.Default.Compare(Hotel, other.Hotel);
            if (hotelComparison != 0) return hotelComparison;
            var hotelIdComparison = Nullable.Compare(HotelID, other.HotelID);
            if (hotelIdComparison != 0) return hotelIdComparison;
            var customerIdComparison = Nullable.Compare(CustomerID, other.CustomerID);
            if (customerIdComparison != 0) return customerIdComparison;
            var roomIdComparison = Nullable.Compare(RoomID, other.RoomID);
            if (roomIdComparison != 0) return roomIdComparison;
            return Nullable.Compare(Price, other.Price);
        }
    }
}
