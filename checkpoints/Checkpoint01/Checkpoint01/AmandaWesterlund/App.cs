using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Checkpoint01.AmandaWesterlund
{
    class App
    {
        static string[] GreetUser()
        {
            Console.Write("Write numbers separated by hyphens (eg. 5-3-2) to make triangles of that size: ");
            var userNumber = Console.ReadLine().Split('-');
            return userNumber;
        }

        static void WriteStars(string[] userNumber)
        {
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
        }
        public void Run()
        {
            
            //Version 2

            //Console.Write("Write numbers separated by hyphens (eg. 5-3-2) to make triangles of that size: ");
            //var userNumber = Console.ReadLine().Split('-');
            string[] userNumber = GreetUser();
            WriteStars(userNumber);
            /*
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
            

            /*
            //version 3, Här står bara bullshit
            Console.Write("Write numbers separated by hyphens (eg. 5-3-2) to make triangles of that size: ");
            var userNumber = Console.ReadLine().Split('-');

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

            
        }
    }
}
