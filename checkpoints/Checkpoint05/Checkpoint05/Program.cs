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

            AddSpaceship("USS Enterprise");
            AddSpaceship("Millennium Falcon");
            AddSpaceship("Cylon Raider");

            AddRavioliForSpaceship("Cylon Raider", 1, "2018-04-19");
            AddRavioliForSpaceship("Millennium Falcon", 1, "2017-01-01");
            AddRavioliForSpaceship("Millennium Falcon", 2, "2018-01-01");
            AddRavioliForSpaceship("Nalle Puh", 99, "1950-01-01");

            List<Spaceship> list = GetAllSpaceships();
            DisplaySpaceships(list);

        }
        
        private static void AddRavioliForSpaceship(string spaceship, int ravioliAmount, string packingDate)
        {
            var packingDateTime = ConvertStringToDateTime(packingDate);
            
            using (var context = new SpaceshipContext())
            {
                var selectedSpaceship = context.Spaceships.Include(s => s.Ravioli).FirstOrDefault(s => s.Name == spaceship);

                if (selectedSpaceship != null)
                {
                    for (var i = 0; i < ravioliAmount; i++)
                    {
                        selectedSpaceship.Ravioli.Add(new Ravioli { Spaceship = selectedSpaceship, PackingDate = packingDateTime });
                    }
                    context.SaveChanges();
                }
            }
        }
        
        private static void RecreateDatabase()
        {
            using (var context = new SpaceshipContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
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
                var spaceships = context.Spaceships.Include(s => s.Ravioli).ToList();
                return spaceships;
            }
        }

        private static void DisplaySpaceships(List<Spaceship> spaceships)
        {
            foreach (var spaceship in spaceships)
            {
                Console.WriteLine(spaceship.Name);
                WriteRavioli(spaceship.Ravioli);
            }
        }

        private static void WriteRavioli(List<Ravioli> raviolis) 
        {
            if (raviolis.Count != 0) 
            {
                foreach (var ravioli in raviolis)
                {
                    Console.WriteLine($"Ravioli, {ravioli.PackingDate}, {ravioli.ExpiryDate}");
                }
            }

            else
            {
                Console.WriteLine("Slut på ravioli");
            }
        }

        private static DateTime ConvertStringToDateTime(string date)
        {
            return Convert.ToDateTime(date);
        }
    }
}


