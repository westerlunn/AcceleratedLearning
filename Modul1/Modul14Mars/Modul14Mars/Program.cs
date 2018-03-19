using System;
using System.Collections.Generic;

namespace Modul14Mars
{
    class Program
    {
        static void Main(string[] args)
        {
            //AskUserForErrorMessage();
            string[] names = null;
            List<string> cleanList = new List<string>();
            while (true)
            {
                var separator = AskUserForSeparator();
                var error = AskUserForErrorMessage();
                names = Greet(separator);

                
                cleanList = CleanUp(names);

                if (namesAreValid(names, error))
                    break;
                else
                    continue;
                /*if (!namesAreValid(names, error))
                {
                    continue;
                }
                break;
                */
            }
            //var cleanList = new List<string>(CleanUp(names));     //Konverterar en List<string> till en list<string>
            Consol();
            CleanFunction(cleanList);
            Console.ResetColor();
        }

        static string[] Greet(char separator)
        {
            Console.Write("Enter names separated by commas: ");
            var names = Console.ReadLine().Split(separator);
            return names;
        }
        static char AskUserForSeparator()
        {
            string separator = null;
            while (true)
            {
                Console.WriteLine("Which separator do u want to use?");
                separator = Console.ReadLine();

                if (separator.Length == 0)
                {
                    return ',';
                }
                else if (separator.Length > 1)
                {
                        Console.WriteLine("You can only use one character");
                    
                    continue;
                }
                break;
            }
            var separatorChar = Convert.ToChar(separator);
            return separatorChar;
        }
        static void Consol()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        static bool AskUserForErrorMessage()
        {
            Console.Write("Do you want to display error messages? ");
            var answer = Console.ReadLine();
            if (answer.ToLower().Trim().Contains("yes"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool namesAreValid(string[] names, bool AskUserForErrorMessage)
        {
            foreach (var element in names)
            {
                if (string.IsNullOrWhiteSpace(element))
                {
                    if (AskUserForErrorMessage) 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input");
                        Console.ResetColor();
                    }
                    return false;
                }
                else if (element.Length > 9 || element.Length < 2)
                {
                    if (AskUserForErrorMessage)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Name must be 2-9 characters.");
                        Console.ResetColor();
                    }
                    return false;
                }
            }
            return true;
        }
        
        static List<string> CleanUp(string[] names)
        {
            var nameList = new List<string>();
            foreach (var clean in names)
            {
                nameList.Add(clean.ToUpper().Trim());
                //nameList.Add(clean);
            }
            return nameList;
        }
        
        static void CleanFunction(List<string> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine("***SUPER-" + name + "***");
            }
        }

        
        
        /*
        static void Function(string[] names)
        {
            foreach (var name in names)
            {
                    Console.WriteLine("***SUPER-" + name.ToUpper().Trim() + "***");
            }
        }
        */
        static void Methods()
        {
            Console.Write("Enter names separated by comma: ");
            var names = Console.ReadLine().Split(',');

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var name in names)
            {
                
                {
                    Console.WriteLine("***SUPER-" + name.ToUpper().Trim() + "***");
                }
            }
            Console.ResetColor();
        }
    }
}
