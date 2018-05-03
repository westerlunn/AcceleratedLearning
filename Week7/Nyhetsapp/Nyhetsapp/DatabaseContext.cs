using Microsoft.EntityFrameworkCore;

namespace Nyhetsapp
{
    public class DatabaseContext : DbContext
    {
        public DbSet<News> News { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MyNewsDatabase.db");
        }
    }
}