using Microsoft.EntityFrameworkCore;

namespace Checkpoint05
{
    public class SpaceshipContext : DbContext
    {
        public DbSet<Spaceship> Spaceships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = EfSpaceship; Trusted_Connection = True; ");
        }
    }
}