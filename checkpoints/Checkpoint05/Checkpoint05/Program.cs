using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Checkpoint05
{
    class Program
    {
        static void Main(string[] args)
        {
            RecreateDatabase();
            AddSpaceship("Millenium Falcon");
            AddSpaceship("Cylon Raider");
            AddSpaceship("Spaceship XX");
            var list = GetAllSpaceships();
            DisplaySpaceships(list);
        }


        private static void RecreateDatabase()
        {
            using (var context = new SpaceshipContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }

        private static void MakeSpaceship()
        {
            var spaceship = new Spaceship() { Name = "Millenium Falcon" };

            using (var context = new SpaceshipContext())
            {
                context.Spaceships.Add(spaceship);
                context.SaveChanges();
            }
        }

        private static void AddSpaceship(string name)
        {
            var spaceship = new Spaceship()
            {
                Name = name
            };
            using (var context = new SpaceshipContext())
            {
                context.Spaceships.Add(spaceship);
                context.SaveChanges();
            }
        }

        

        private static List<Spaceship> GetAllSpaceships()
        {
            using (var context = new SpaceshipContext())
            {
                var spaceships = context.Spaceships.ToList();
                return spaceships;
            }
        }

        private static void DisplaySpaceships(List<Spaceship> spaceships)
        {
            foreach (var spaceship in spaceships)
            {
                Console.WriteLine(spaceship.Name);
            }
        }
    }
}
