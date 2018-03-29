using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace KrypteringFromRovarspraket
{
    class Program
    {
        static void Main(string[] args)
        {
            GreetUser();
            var userInputRovarspraket = GetUserInputOnRovarspraket();
            bool inputOkay = CheckIfInputIsRovarspraket(userInputRovarspraket);
            if (inputOkay)
            {
                var translated = AddAllowedCharsToString(userInputRovarspraket);
                Console.WriteLine(translated);
            }
            

        }

        public static void GreetUser()
        {
            Console.Write("Skriv på rövarspråket: ");
        }

        public static string GetUserInputOnRovarspraket() => Console.ReadLine();

       
        public static bool CheckIfInputIsRovarspraket(string userInput)
        {
            var vowels = new List<char> { 'a', 'e', 'i', 'y', 'u', 'å', 'ä', 'ö', 'o', 'Å', 'Ä', 'Ö', 'A', 'E', 'I', 'Y', 'U', 'O' };
            bool inputOkey = true;

            for (var i = 0; i < userInput.Length; i++)
            {
                if (!vowels.Contains(userInput[i]) && char.IsLetter(userInput[i]))
                {
                    if (i < userInput.Length - 2)
                    {
                        var rovarPart = userInput.Substring(i, 3); 

                        if ((rovarPart[1] == 'o' || rovarPart[1] == 'O') & rovarPart[2] == rovarPart[0])
                        {
                            i = i + 2;
                        }
                        else
                        {
                            inputOkey = false;
                            Console.WriteLine("Incorrect format");
                            break;
                        }
                    }
                    else
                    {
                        inputOkey = false;
                        Console.WriteLine("The end of the word wasn't in the correct format");
                        break;
                    }
                }
            }
            
            return inputOkey;
        }

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

        public static void PrintTranslatedToNormal(string translatedInputToNormal) //onödig.
        {
            foreach (var character in translatedInputToNormal)
            {
                Console.Write(character);
            }
        }
    }
}

