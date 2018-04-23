using System;
using System.Collections.Generic;

namespace Checkpoint05
{
    public class Spaceship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Ravioli> Ravioli { get; set; }
    }

    public class Ravioli
    {
        public int Id { get; set; } 
        public Spaceship Spaceship { get; set; }
        //public int RavioliAmount { get; set; }
        public DateTime PackingDate { get; set; }   
    }
}