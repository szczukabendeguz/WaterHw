using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Water.Entities;

namespace Water.Data
{
    public class WaterContext : IdentityDbContext
    {
        public DbSet<WaterLevel> WaterLevels { get; set; }

        public WaterContext(DbContextOptions<WaterContext> ctx)
            :base(ctx)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
