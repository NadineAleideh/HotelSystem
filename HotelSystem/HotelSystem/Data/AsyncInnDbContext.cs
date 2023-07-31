using HotelSystem.Models;//to enabel using the entites classes in the DBset<>
using Microsoft.EntityFrameworkCore; // to enabel using DbContext base class

namespace HotelSystem.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // to add the comopsite keys in the erd
            modelBuilder.Entity<HotelRoom>().HasKey(hr => new { hr.RoomNumber, hr.HotelId });
            modelBuilder.Entity<RoomAmenity>().HasKey(ra => new { ra.AmenityId, ra.RoomId });

            modelBuilder.Entity<Hotel>().ToTable("Hotels");//edit Hotel table name to Hotels
            modelBuilder.Entity<Amenity>().ToTable("Amenities");//edit Hotel table name to Hotels
        }


        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }

    }
}
