using HotelSystem.Data;
using HotelSystem.Interfaces;
using HotelSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Services
{
    public class AmenityService : IAmenity
    {
        private readonly AsyncInnDbContext _context;

        public AmenityService(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<Amenity> CreateAmenity(Amenity amenity)
        {
            await _context.Amenities.AddAsync(amenity);
            var amentiy = await GetAmenityById(amenity.Id);
            await _context.SaveChangesAsync();
            return amentiy;
        }

        public async Task<Amenity> UpdateAmenity(int id, Amenity amenity)
        {
            var amenitytoupdate = await GetAmenityById(id);

            if (amenitytoupdate != null)
            {
                amenitytoupdate.Name = amenity.Name;

                await _context.SaveChangesAsync();
            }


            return amenitytoupdate;
        }

        public async Task DeleteAmenity(int id)
        {
            var amenity = await GetAmenityById(id);
            _context.Amenities.Remove(amenity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Amenity>> GetAllAmenities()
        {
            var amenities = await _context.Amenities.Include(a => a.RoomAmenities).ToListAsync();
            return amenities;
        }

        public async Task<Amenity> GetAmenityById(int id)
        {
            var amenity = await _context.Amenities.FindAsync(id);

            return amenity;
        }


    }
}
