using System;
using System.Collections.Generic;
using System.Linq;

namespace Week2Modul9
{
    class Program
    {
        static void Main(string[] args)
        {
            AskForInputAndPrintOutput(ConvertStringToUpper);
            AskForInputAndPrintOutput(TrippleString);
            AskForInputAndPrintOutput(AddStarsToString);
        }

        private static void AskForInputAndPrintOutput(Func<string, string> method)
        {
            Console.Write("Enter a string to convert: ");
            Console.ForegroundColor = ConsoleColor.Green;
            var stringToConvert = Console.ReadLine();
            Console.ResetColor();
            var convertedString = method(stringToConvert);
            Console.WriteLine(convertedString);
        }

        static string ConvertStringToUpper(string stringToConvert) => stringToConvert.ToUpper();
        

        static string TrippleString(string stringToConvert) => stringToConvert + stringToConvert + stringToConvert;

        static string AddStarsToString(string stringToConvert) => string.Join<char>("*", stringToConvert);
       

    }
}
