using System;

namespace Checkpoint05
{
    public class Ravioli
    {
        public int Id { get; set; }
        public int SpaceshipId { get; set; }
        public Spaceship Spaceship { get; set; }
        public DateTime PackingDate { get; set; }
        public DateTime ExpiryDate => PackingDate.AddMonths(6).AddDays(15);
    }
}