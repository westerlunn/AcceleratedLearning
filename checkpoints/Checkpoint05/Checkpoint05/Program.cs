using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;

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

            AddRavioliForSpaceship("Cylon Raider", 1, new DateTime(2017, 12, 3));
            AddRavioliForSpaceship("Millennium Falcon", 3, DateTime.Now);


            var list = GetAllSpaceships();
            DisplaySpaceships(list);
            
        }
        
        private static void AddRavioliForSpaceship(string spaceship, int ravioliAmount, DateTime packageDate)
        {
            var list = new List<Ravioli>();


            ravioliAmount = 0;
            
            using (var context = new SpaceshipContext())
            {
                var selectedSpaceship = context.Spaceships.FirstOrDefault(x => x.Name == spaceship);
                for (var i = 0; i < ravioliAmount; i++)
                {
                    selectedSpaceship.Ravioli.Add(new Ravioli { Spaceship = selectedSpaceship, PackingDate = packageDate });

                }
                context.SaveChanges();
            }
            /*
            using (var context = new SpaceshipContext())
            {

                var ravioli = context.Spaceships.Include(x => x.Ravioli)
            }
            */
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

        private static void DisplaySpaceships(List<Spaceship> spaceships) //, List<Ravioli> list)
        {
            foreach (var spaceship in spaceships)
            {
                Console.WriteLine(spaceship.Name);
                WriteRavioli(spaceship.Ravioli);
                /*
                if (raviolis != null)
                {
                    foreach (var ravioli in raviolis)
                    {
                        Console.WriteLine("Ravioli");
                    }
                }

                if (raviolis == null)
                {
                    Console.WriteLine("Slut på ravioli");
                }
                */
            }
        }

        private static void WriteRavioli(List<Ravioli> raviolis) 
        {
            if (raviolis != null)
            {
                foreach (var ravioli in raviolis)
                {
                    Console.WriteLine($"Ravioli, {ravioli.PackingDate}");
                }
            }

            if (raviolis == null)
            {
                Console.WriteLine("Slut på ravioli");
            }
        }

    }


}


