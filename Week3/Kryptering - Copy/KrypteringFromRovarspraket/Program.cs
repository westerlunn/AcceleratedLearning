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
            
            //bool inputOkey = CheckInput(userInputRovarspraket);
            //bool inputOkay = CheckIfInputIsRovarspraket(userInputRovarspraket);

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
        public static bool CheckInput(string userInput)
        {
            var vowels = new List<char> { 'a', 'e', 'i', 'y', 'u', 'å', 'ä', 'ö', 'o' };
            bool inputOkey = true;
            bool isVowel;
            var vowels2 = "aeiyuåäöoÅÄÖAEIYUO";
            for (var i = 0; i < userInput.Length -1; i++)
            {
                if (vowels.Contains(userInput[i]))
                {
                    inputOkey = true;
                    isVowel = true;
                }
                if (!vowels.Contains(userInput[i]))
                {
                    isVowel = false;
                    var rovarPart = userInput.Substring(userInput[0], userInput[3]);
                    for (int j = 0; j < rovarPart.Length - 1; j++)
                    { 
                        if (rovarPart[1 + j] == 'o' & rovarPart[2 + j] == rovarPart[j])
                        {
                            inputOkey = true;
                            //i = i + 2;
                        }
                        else
                        {
                            inputOkey = false;
                        }
                    }

                    if (!isVowel == true && inputOkey == true)
                    {
                        i = i + 2;
                    }
                    else
                    {
                        
                        Console.WriteLine("AJAJAJ");
                        break;
                    }

                }
            }
            return inputOkey;
        }
        public static bool CheckIfInputIsRovarspraket(string userInput)
        {
            var vowels = "aeiyuåäöoÅÄÖAEIYUO";
            bool inputOkey = true;

            for (int i = 0; i > userInput.Length; i++)
            {
                //if (vowels.Contains(userInput))
                //{
                    inputOkey = true;
                //}
                if (!vowels.Contains(userInput))
                {
                    //var userInputConsonant = userInput.Substring(userInput[i], userInput[i] + 2) =
                    bool result = Regex.IsMatch(userInput.Substring(userInput[i], userInput[i] + 2), @"^({userInput[i]}+'o'+{userInput[i]})$");
                    if (!result)
                    {
                        Console.WriteLine("Wrong input");
                        inputOkey = false;
                        break;
                    }
                    else
                    {
                        i = i + 2;
                    }
                    
                    //bool result = Regex.IsMatch(userInput, @"^(userinput)$");
                    //bool result = Regex.IsMatch(userInput, @"^(\w[a-zåäöA-ZÅÄÖ]+)\s(\d+(\s|)m2)\s(on|off)$");
                }
            }

            return inputOkey;
        }
        
        public static void ShitDoesntWork(string userInputRovarspraket)
        {
            var vowels = "aeiyuåäöoÅÄÖAEIYUO";
            bool inputOkey;


            for (int i = 0; i > userInputRovarspraket.Length; i++)
            {
                //if (vowels.Contains(userInput))
                //{
                inputOkey = true;
                //}
                if (vowels.Contains(userInputRovarspraket))
                {
                    inputOkey = true;
                    //var userInputConsonant = userInput.Substring(userInput[i], userInput[i] + 2) =
                    //for (int j = 0; j < userInputRovarspraket.Length; j++)
                    //{
                    if (!vowels.Contains(userInputRovarspraket))
                        foreach (var character in userInputRovarspraket.Substring(userInputRovarspraket[i], userInputRovarspraket[i] + 2))
                        {
                            if (character + 1 == 'o' && character + 2 == character)
                            {
                                inputOkey = true;
                                Console.WriteLine("YÄÄÄS");
                            }
                            else
                            {
                                inputOkey = false;
                            }

                        }

                    if (inputOkey == true)
                    {
                        i = i + 2;
                    }
                    else
                    {
                        Console.WriteLine("DAMN");
                    }
                }
            }
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

