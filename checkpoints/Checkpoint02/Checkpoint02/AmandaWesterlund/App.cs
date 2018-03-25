using System;
using System.Collections.Generic;
using System.Text;

namespace Checkpoint02.AmandaWesterlund
{
    public class App
    {
        public void Run()
        {
            string[] userRooms = GreetUser();
            Room[] roomArray = new Room[userRooms.Length];
            for (var i = 0; i < userRooms.Length; i++)
            {
                Room room = new Room(userRooms[i]);
                room.PrintRoom();
            }
            Room r1 = new Room(userRooms[0]);
            Room r2 = new Room(userRooms[1]);
            Room r3 = new Room(userRooms[2]);
            r1.PrintRoom();
            r2.PrintRoom();
            r3.PrintRoom();
        }

        public string[] GreetUser()
        {
            //List<string> rooms = new List<string>();
            Console.WriteLine("Ange namn på tre rum, separerade med '|' (Kök|Toa|Vardagsrum): ");
            var userRooms = Console.ReadLine().Trim().Split('|');
            var userRoom = userRooms.ToString();
            //rooms.Add(userRoom);
            return userRooms;
           // return userRoom;

        }

        

    }
    public class Room
    {
        public string Name { get; set; }
        public string Area { get; set; }
        public string LampSwitch { get; set; }
        
        public Room(string name)
        {
            Name = name;
            
        }

        public void PrintRoom()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Rumsnamn 1: {Name}");
            //Console.WriteLine($"* Rumsnamn 1: {R1}\n* Rumsnamn 2: {R2}\n* Rumsnamn 3: {R3}");
            Console.ResetColor();
        }


    }
    
}
