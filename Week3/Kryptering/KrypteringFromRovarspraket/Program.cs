using System;
using System.Collections.Generic;

namespace KrypteringFromRovarspraket
{
    class Program
    {
        static void Main(string[] args)
        {
            GreetUser();
            var userInputRovarspraket = GetUserInputOnRovarspraket();
            //List<string> translatedInput = TranslateFromRovarspraket(userInputRovarspraket);
            //PrintTranslatedToNormal(translatedInput);

            //var translated = TranslateFromRovarspraket(userInputRovarspraket);
            //Console.WriteLine(translated);
            var translated = TranslateFromRovar(userInputRovarspraket);
            Console.WriteLine(translated);

            void GreetUser()
            {
                Console.Write("Skriv på rövarspråket: ");
            }

            string GetUserInputOnRovarspraket() => Console.ReadLine();

            string TranslateFromRovarspraket(string userInput)  //string instead of List<string>
            {
                var vowels = new List<char> {'a', 'e', 'i', 'y', 'u', 'å', 'ä', 'ö', 'o'};
                
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

            string TranslateFromRovar(string userInput)
            {
                var vowels = new List<char> { 'a', 'e', 'i', 'y', 'u', 'å', 'ä', 'ö', 'o', 'Å', 'Ä', 'Ö', 'A', 'E', 'I', 'Y', 'U', 'O' };
                bool charIsConsonant;
                string allowedChars = "";

                for (int i = 0; i < userInput.Length; i++)
                {
                    charIsConsonant = true;
                    for (int j = 0; j < vowels.Count; j++)
                    {
                        if (userInput[i] == vowels[j])
                        {
                            charIsConsonant = false;
                        }
                    }

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

            void PrintTranslatedToNormal(string translatedInputToNormal) //List<string>
            {
                foreach (var character in translatedInputToNormal)
                {
                    Console.Write(character);
                }
            }
        }
    }
}
