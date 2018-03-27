using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            //MakeRoom(userRooms);
            bool resultMatch = CheckUserInputFormat(userRooms);
            if (!resultMatch)
            {
                FormatErrorMessage();
            }

            bool lightInputValid = true;
            //bool resultMatch = true;
            int countParts = 0;

            /*
            foreach (var item in userRooms)
            {
                //bool result = Regex.IsMatch(item, @"^((\w[a-zåäö]+)(\d+)(on|off))$");
                bool result = Regex.IsMatch(item.Trim(), @"^(\w[a-zåäöA-ZÅÄÖ]+)\s(\d+(\s|)m2)\s(on|off)$");
                if (!result)
                {
                    resultMatch = false;
                    //Console.WriteLine("WRONG!");
                    //Console.WriteLine(item);
                }
            }
            */
            
            for (var i = 0; i < userRooms.Length; i++)
            {
                var splitRoom = userRooms[i].Replace("m2", "").Split(' ', StringSplitOptions.RemoveEmptyEntries); //
                 
                countParts = splitRoom.Length;
                
                //Room room = new Room(splitRoom[0], int.Parse(splitRoom[1]));
                //roomArray[i] = room;
                //room.PrintRoom();
                
                bool lightOn = false;
                if (splitRoom[2].ToLower() == "on")
                {
                    lightOn = true;
                }
                else if (splitRoom[2].ToLower() != "off")
                {
                    lightInputValid = false;
                }
                
                roomArray[i] = new Room(splitRoom[0], int.Parse(splitRoom[1]), lightOn);
                roomArray[i].PrintRoom();
            }
            
            if (countParts != 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The input must be three parts");
                Console.ResetColor();
            }

            if (lightInputValid == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You didn't enter a valid input for the status of the light switch");
                Console.ResetColor();
            }
            /*
            if (!result)
            {
                resultMatch = false;
                //Console.WriteLine("WRONG!");
                //Console.WriteLine(item);
            }
            */

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

            if (countParts == 3 && lightInputValid && resultMatch)
            {
                var numberOfRooms = roomArray.Length;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Det största rummet är {roomArray[maxRoomInt].Name} och är {maxRoom} m2");
                Console.WriteLine($"Bostaden består av {numberOfRooms} rum");
                Console.WriteLine($"Ljuset är tänt i {String.Join(" och ", roomsWithLightOn)}");
                Console.ResetColor();
            }
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
            Console.WriteLine("Ange namn på tre rum, ange även dess storlek och om lyset är på eller av. \nSeparera rummen med '|' (t ex. Kök 30m2 on|Toa 10m2 off|Vardagsrum 40m2 on): ");
            var userRooms = Console.ReadLine().Split('|');
            var userRoom = userRooms.ToString();
            return userRooms;

        }

        public bool CheckUserInputFormat(string[] userRooms)
        {
            bool resultMatch = true;
            
            foreach (var item in userRooms)
            {
                //bool result = Regex.IsMatch(item, @"^((\w[a-zåäö]+)(\d+)(on|off))$");
                bool result = Regex.IsMatch(item.Trim(), @"^(\w[a-zåäöA-ZÅÄÖ]+)\s(\d+(\s|)m2)\s(on|off)$");
                if (!result)
                {
                    resultMatch = false;
                    //Console.WriteLine("WRONG!");
                    //Console.WriteLine(item);
                }

                    
            }

            return resultMatch;

        }

        public void FormatErrorMessage()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The input was not in the right format");
            Console.ResetColor();
        }
        /*
        public Room[] MakeRoom(string[] userRooms)
        {
            Room[] roomArray = new Room[userRooms.Length];
            bool lightInputValid = true;
            int countParts = 0;
            for (var i = 0; i < userRooms.Length; i++)
            {
                var splitRoom = userRooms[i].Replace("m2", "").Split(' ', StringSplitOptions.RemoveEmptyEntries); //

                countParts = splitRoom.Length;

                //Room room = new Room(splitRoom[0], int.Parse(splitRoom[1]));
                //roomArray[i] = room;
                //room.PrintRoom();

                bool lightOn = false;
                if (splitRoom[2].ToLower() == "on")
                {
                    lightOn = true;
                }
                else if (splitRoom[2].ToLower() != "off")
                {
                    lightInputValid = false;
                }

                roomArray[i] = new Room(splitRoom[0], int.Parse(splitRoom[1]), lightOn);
                roomArray[i].PrintRoom();
            }

            return roomArray;
        }
        */
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
    
}
