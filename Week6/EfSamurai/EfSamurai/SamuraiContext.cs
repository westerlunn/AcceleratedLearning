using System;
using Microsoft.EntityFrameworkCore;

namespace EfSamurai
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Battle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = EfSamurai; Trusted_Connection = True; ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>()
                .HasKey(sb => new { sb.SamuraiId, sb.BattleId });

            //Solve cascade issues
            /*
            modelBuilder.Entity<Samurai>()
                .HasMany(x => x.Quote)
                .WithOne(x => x.Samurai)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Samurai>()
                .HasMany(x => x.Quote)
                .WithOne(x => x.Samurai)
                .OnDelete(DeleteBehavior.Cascade);
                */
        }

        
    }
}