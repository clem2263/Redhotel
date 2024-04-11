using DomainModel;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class RedHotelContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        #region Constructors
        public RedHotelContext()
            : base()
        {
        }

        public RedHotelContext(DbContextOptions options)
            : base(options)
        {
        }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=dmdotnet;User=root;Password=;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
