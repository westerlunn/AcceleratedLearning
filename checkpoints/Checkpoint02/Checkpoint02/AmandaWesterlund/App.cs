using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Checkpoint02.AmandaWesterlund
{
    public class App
    {
        public void Run()
        {
            char[] delimiter = {'m', '2'};
            string[] userRooms = GreetUser();
            Room[] roomArray = new Room[userRooms.Length];
            for (var i = 0; i < userRooms.Length; i++)
            {
                var splitRoom = userRooms[i].TrimStart().TrimEnd().Replace("m2", "").Split(' ');
                //Room room = new Room(splitRoom[0], int.Parse(splitRoom[1]));
                //roomArray[i] = room;
                //room.PrintRoom();
                roomArray[i] = new Room(splitRoom[0], int.Parse(splitRoom[1]));
                roomArray[i].PrintRoom();

            }

            Regex Regex = new Regex(" ");
            var maxRoom = 0;//maxArea;
            int maxRoomInt = 0;
            foreach (var room in roomArray)
            {
                
            }
            for (var i = 0; i < roomArray.Length; i++)
            {
                var roomSize = roomArray[i].Area;
                if (roomSize > maxRoom)
                {
                    maxRoom = roomSize;
                    maxRoomInt = i;
                }
            }
            Console.WriteLine($"{maxRoom}, {roomArray[maxRoomInt].Name}");

            //roomArray[1]
            /*
            Room r1 = new Room(userRooms[0]);
            Room r2 = new Room(userRooms[1]);
            Room r3 = new Room(userRooms[2]);
            r1.PrintRoom();
            r2.PrintRoom();
            r3.PrintRoom();
            */
        }

        public string[] GreetUser()
        { 
            //List<string> rooms = new List<string>();
            Console.WriteLine("Ange namn på tre rum, separerade med '|' (Kök|Toa|Vardagsrum): ");
            var userRooms = Console.ReadLine().Split('|');
            var userRoom = userRooms.ToString();
            //rooms.Add(userRoom);
            return userRooms;
           // return userRoom;

        }

        

    }
    public class Room
    {
        public string Name { get; set; }
        public int Area { get; set; }
        public string LampSwitch { get; set; }
        
        public Room(string name, int area)
        {
            Name = name;
            Area = area;
        }

        public void PrintRoom()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Rumsnamn 1: {Name}, rumsarea: {Area}");
            //Console.WriteLine($"The biggest room is {Name}, with the area {Area}");
            //Console.WriteLine($"* Rumsnamn 1: {R1}\n* Rumsnamn 2: {R2}\n* Rumsnamn 3: {R3}");
            Console.ResetColor();
        }


    }
    
}
