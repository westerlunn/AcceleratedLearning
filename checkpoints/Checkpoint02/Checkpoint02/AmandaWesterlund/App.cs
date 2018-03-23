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
            //userRooms[0] = r1;
            Room home1 = new Room("Vardagsrum", "Toa", "Sovrum");
            Room home2 = new Room(userRooms[0], userRooms[1], userRooms[2]);
            //home1.GetRoom();
            home2.GetRoom();
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
        public string R1 { get; set; }
        public string R2 { get; set; }
        public string R3 { get; set; }
        
        public Room(string r1, string r2, string r3)
        {
            R1 = r1;
            R2 = r2;
            R3 = r3;
        }

        public void GetRoom()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"* Rumsnamn 1: {R1}\n* Rumsnamn 2: {R2}\n* Rumsnamn 3: {R3}");
            Console.ResetColor();
        }


    }
    
}
