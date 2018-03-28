using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace KrypteringFromRovarspraket
{
    class Program
    {
        static void Main(string[] args)
        {
            GreetUser();
            var userInputRovarspraket = GetUserInputOnRovarspraket();
            var translated = AddAllowedCharsToString(userInputRovarspraket);
            Console.WriteLine(translated);

        }

        public static void GreetUser()
        {
            Console.Write("Skriv på rövarspråket: ");
        }

        public static string GetUserInputOnRovarspraket() => Console.ReadLine();

        /*
        public static string TranslateFromRovarspraket(string userInput)  //string instead of List<string> //Not using
        {
            var vowels = new List<char> { 'a', 'e', 'i', 'y', 'u', 'å', 'ä', 'ö', 'o' };

            var translatedInputToNormal = new List<string>();
            var stringWithRemovedChars = "";

            foreach (var character in userInput)
            {
                if (vowels.Contains(character))
                {
                    translatedInputToNormal.Add(character.ToString());
                }

                if (!vowels.Contains(character))
                {
                    translatedInputToNormal.Add(character.ToString());
                    stringWithRemovedChars = userInput.Remove(userInput.IndexOf(character) + 1, userInput.IndexOf(character) + 1);
                    break;
                }
            }
            return stringWithRemovedChars;
            //return translatedInputToNormal;
        }
        */

        public static string AddAllowedCharsToString(string userInput) 
        {
            string allowedChars = "";

            for (int i = 0; i < userInput.Length; i++)
            {

                bool charIsConsonant = CheckIfInputAreVowels(userInput[i]);

                if (charIsConsonant && char.IsLetter(userInput[i]))    
                {
                    allowedChars = allowedChars + userInput[i];
                    i = i + 2;
                }
                else
                {
                    allowedChars = allowedChars + userInput[i];
                }
            }

            return allowedChars;
        }

        public static bool CheckIfInputAreVowels(char userInput)
        {
            var vowels = "aeiyuåäöoÅÄÖAEIYUO";
            bool charIsConsonant;

            charIsConsonant = true;
            for (int j = 0; j < vowels.Length; j++)
            {
                if (userInput == vowels[j])
                {
                    charIsConsonant = false;
                }
            }

            return charIsConsonant;
        }

        public static void PrintTranslatedToNormal(string translatedInputToNormal) //List<string>
        {
            foreach (var character in translatedInputToNormal)
            {
                Console.Write(character);
            }
        }
    }
}

