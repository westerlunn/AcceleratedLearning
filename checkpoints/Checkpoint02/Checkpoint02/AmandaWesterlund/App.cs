using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
                var splitRoom = userRooms[i].Replace("m2", "").TrimStart().TrimEnd().Trim().Split(' ');
                //Room room = new Room(splitRoom[0], int.Parse(splitRoom[1]));
                //roomArray[i] = room;
                //room.PrintRoom();
                bool lightOn = false;
                if (splitRoom[2].ToLower() == "on")
                {
                    lightOn = true;
                }

                roomArray[i] = new Room(splitRoom[0], int.Parse(splitRoom[1]), lightOn);
                roomArray[i].PrintRoom();

            }

            var maxRoom = 0;//maxArea;
            int maxRoomInt = 0;
            
            for (var i = 0; i < roomArray.Length; i++)
            {
                var roomSize = roomArray[i].Area;
                if (roomSize > maxRoom)
                {
                    maxRoom = roomSize;
                    maxRoomInt = i;
                }
            }

            int numberOfLightsOn = 0;
            List<string> roomsWithLightOn = new List<string>();
            for (var i = 0; i < roomArray.Length; i++)
            {
                if (roomArray[i].LampSwitch)
                {
                    numberOfLightsOn++;
                    roomsWithLightOn.Add(roomArray[i].Name);
                }
            }
            
            var numberOfRooms = roomArray.Length;
            
            Console.WriteLine($"Det största rummet är {roomArray[maxRoomInt].Name} och är {maxRoom} m2");
            Console.WriteLine($"Bostaden består av {numberOfRooms} rum");
            Console.WriteLine($"Ljuset är tänt i {String.Join(" och ", roomsWithLightOn)}");
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
            Console.WriteLine("Ange namn på tre rum, ange även dess storlek och om lyset är på eller av. Separera rummen med '|' (t ex. Kök 30m2 on|Toa 10m2 off|Vardagsrum 40m2 on): ");
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
        public bool LampSwitch { get; set; }
        
        public Room(string name, int area, bool lampSwitch)
        {
            Name = name;
            Area = area;
            LampSwitch = lampSwitch;
        }

        public void PrintRoom()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"* Rumsnamn 1: {Name}");
            //Console.WriteLine($"The biggest room is {Name}, with the area {Area}");
            //Console.WriteLine($"* Rumsnamn 1: {R1}\n* Rumsnamn 2: {R2}\n* Rumsnamn 3: {R3}");
            Console.ResetColor();
        }


    }
    
}
