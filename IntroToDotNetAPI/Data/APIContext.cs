using Microsoft.EntityFrameworkCore;
using IntroToDotNetAPI.Models;

namespace IntroToDotNetAPI.Data
{
    public class APIContext: DbContext
    { 
        public DbSet<HotelBooking> Bookings { get; set; }
        public APIContext(DbContextOptions<APIContext> options): base(options)
        {

        }
    }
}
