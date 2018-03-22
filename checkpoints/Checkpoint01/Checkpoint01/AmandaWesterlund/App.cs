﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Checkpoint01.AmandaWesterlund
{
    class App
    {
        static string[] GreetUser()
        {
            Console.Write("Write numbers separated by hyphens to make triangles of that size. Write A before the number to make a triangle with the top upwards, and write B to make a triangle with the bottom up (eg. A5-B3-A2): ");
            var userNumber = Console.ReadLine().Split('-');
            return userNumber;
        }

        static void MakeStars(string[] userNumber)
        {
            foreach (var number in userNumber)
            {
                var intNumber = int.Parse(number);
                for (var i = 0; i <= intNumber; i++)
                {
                    WriteTopUpTriangle(i);
                }
            }
        }

        static void WriteTopUpTriangle(int i)
        {
            for (var j = 0; j < i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine("");
        }

        static void WriteBottomUpTriangle(int i)
        {
            for (var j = i; j > 0; j--)
            {
                Console.Write("*");
            }
            Console.WriteLine("");
        }
        public void Run()
        {
            //Kalla på metoder för att köra version 2. //MakeStars(userNumber);
            string[] userNumber = GreetUser();
            


            //Console.Write("Write numbers separated by hyphens (eg. 5-3-2) to make triangles of that size: ");
            //var userNumber = Console.ReadLine().Split('-');
            
            foreach (var character in userNumber)
            {
                var number = Convert.ToInt32(character.Substring(1, character.Length - 1));
                if (character[0] == 'A')
                {
                    for (var i = 1; i <= number; i++)
                    {
                        WriteTopUpTriangle(i);
                        
                    }
                }
                else if (character[0] == 'B')
                {
                    for (var i = number; i > 0; i--)
                    {
                        WriteBottomUpTriangle(i);
                    }
                }
                //version 3, KING, men utan metoder.
                /*
                Console.Write("Write numbers separated by hyphens (eg. 5-3-2) to make triangles of that size: ");
                var userNumber = Console.ReadLine().Split('-');

                foreach (var character in userNumber)
                {
                    var number = Convert.ToInt32(character.Substring(1, character.Length - 1));
                    if (character[0] == 'A')
                    {
                        for (var i = 0; i <= number; i++)
                        {
                            for (var j = 0; j < i; j++)
                            {
                                Console.Write("*");
                            }
                            Console.WriteLine("");
                        }
                    }
                    else if (character[0] == 'B')
                    {
                        for (var i = number; i > 0; i--)
                        {
                            for (var j = i; j > 0; j--)
                            {
                                Console.Write("*");
                            }
                            Console.WriteLine("");
                        }
                    }
                    */
                    /*
                    //version 3, fungerar bara upp till 9.
                    Console.Write("Write numbers separated by hyphens (eg. 5-3-2) to make triangles of that size: ");
                var userNumber = Console.ReadLine().Split('-');

                foreach (var character in userNumber)
                {
                    var number = Convert.ToInt32(character[1].ToString());

                    if (character[0] == 'A')
                    {
                        for (var i = 0; i <= number; i++)
                        {
                            for (var j = 0; j < i; j++)
                            {
                                Console.Write("*");
                            }
                            Console.WriteLine("");
                        }
                    }
                    else if (character[0] == 'B')
                    {
                        for (var i = number; i > 0; i--)
                        {
                            for (var j = i; j > 0; j--)
                            {
                                Console.Write("*");
                            }
                            Console.WriteLine("");
                        }
                    }
                    */
                }
                /*
            foreach (var number in userNumber)
            {
                var charInput = number.ToCharArray();
                
                foreach (var character in charInput)
                {
                    

                    if (Char.IsLetter(character) && character == 'A')
                    {
                        if (Char.IsDigit(character))
                        {
                            var intList = new List<int>();
                            intList.Add(character);
                            //var intNumber = int.Parse(number);

                            foreach (var digit in intList)

                                for (var row = 0; row <= digit; row++)
                                {
                                    for (var column = 0; column < row; column++)
                                    {
                                        Console.Write("*");
                                    }
                                    Console.WriteLine("");
                                }
                        }
                    }
                }
                }
                */

            //Version 2. allt i en.
            /*
            Console.Write("Write numbers separated by hyphens (eg. 5-3-2) to make triangles of that size: ");
            var userNumber = Console.ReadLine().Split('-');

            foreach (var number in userNumber)
            {
                var intNumber = int.Parse(number);
                for (var i = 0; i <= intNumber; i++)
                {
                    for (var j = 0; j < i; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine("");
                }
            }
            */

        }
    }
}
