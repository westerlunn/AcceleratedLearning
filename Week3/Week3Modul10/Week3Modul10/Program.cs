using System;
using System.Collections.Generic;

namespace Week3Modul10
{
    class klass
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Dictionary<int, string> dictionary = new Dictionary<int, string>();


            while (true)
            {
                GreetUser();
                var userInput = GetUserInput();
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    break;
                }

                var splitInput = SplitUserInput(userInput);
                int id = int.Parse(splitInput[0]);
                string name = splitInput[1];
                dictionary.Add(id, name);




                /*
                string[] userProductInfo = GetUserInput();
                var inputString = userProductInfo[0];
                

                if (string.IsNullOrWhiteSpace(inputString))
                {
                    break;
                }
                int id = int.Parse(userProductInfo[0]);
                string name = userProductInfo[1];
                dictionary.Add(id, name);
                */
            }



            foreach (var part in dictionary)
            {
                Console.WriteLine($"Product id = {part.Key}, product name = {part.Value}");
            }
            
        }

        public static void GreetUser()
        {
            Console.Write("Enter product id and name: ");

        }
        public static string GetUserInput()
        {
            var userProductInfo = Console.ReadLine();
            return userProductInfo;
        }

        public static string[] SplitUserInput(string userProductInfo)
        {
            var splitProductInfo = userProductInfo.Split(',');
            return splitProductInfo;
        }
    }
}
