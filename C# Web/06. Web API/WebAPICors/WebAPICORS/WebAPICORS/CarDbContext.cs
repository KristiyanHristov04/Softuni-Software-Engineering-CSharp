using Microsoft.EntityFrameworkCore;

namespace WebAPICORS
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Car> Cars { get; set; }
    }
}
