using System;
using System.Text.RegularExpressions;

namespace Week4Regex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write product number in this format 'DE-234-456': ");
            var userInput = Console.ReadLine();
            bool match = ProductNumberIsValid(userInput);
            PrintPartOfProductNumber(match, userInput);
        }

        public static void PrintPartOfProductNumber(bool match, string userInput)
        {
            var splitInput = userInput.Split('-');

            foreach (var part in splitInput)
            {
                if (match)

                {
                    Console.WriteLine(part);
                }
                else
                {
                    Console.WriteLine("You didn't enter a correct product number.");
                    break;
                }

            }
        }
        public static bool ProductNumberIsValid(string productName)
        {
            bool match = Regex.IsMatch(productName, @"(^[A-Z]{2}-[\d]{3}-[\d]{3}$)");
            return match;
        }
    }
}
