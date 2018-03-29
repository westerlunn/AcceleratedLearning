using System;
using System.Collections.Generic;

namespace Kryptering
{
    class Program
    {
        static void Main(string[] args)
        {
            GreetUserRegular();
            var userInput = GetUserInput();
            List<string> translatedInput = TranslateUserInputToRovarspraket(userInput);
            PrintUserInputTranslatedToRovarspraket(translatedInput);
        }

        public static void GreetUserRegular()
        {
            Console.Write("Skriv något du vill översätta till rövarspråket: ");
        }

        public static string GetUserInput() => Console.ReadLine();

        public static List<string> TranslateUserInputToRovarspraket(string userInput)
        {
            var vowels = new List<char> { 'a', 'e', 'i', 'y', 'u', 'å', 'ä', 'ö', 'o' };
            var translatedInput = new List<string>();
            foreach (var character in userInput)
            {
                if (char.IsLetter(character) && !vowels.Contains(character) && !vowels.Contains(Char.ToLower(character)))
                {
                    if (Char.IsLower(character))
                        translatedInput.Add(character + "o" + character);
                    if (Char.IsUpper(character))
                        translatedInput.Add(character + "O" + character);
                }
                else
                    translatedInput.Add(Char.ToString(character));
            }

            return translatedInput;
        }

        public static void PrintUserInputTranslatedToRovarspraket(List<string> translatedInput)
        {
            foreach (var character in translatedInput)
                Console.Write(character);
            Console.WriteLine();
        }

        public static void GreetUser()
        {
            Console.Write("Skriv på rövarspråket: ");
        }

        public static string GetUserInputOnRovarspraket() => Console.ReadLine();

        public static void TranslateFromRovarspraket()
        {
            List<string> konsonanter = new List<string>();
        }

    }
}
