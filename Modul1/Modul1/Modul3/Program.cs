using System;
using System.Collections.Generic;

namespace Modul3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random();
        }

        static void Methods()
        {
            Console.Write("Enter names separated by comma: ");
            var names = Console.ReadLine().Split(',');

            foreach (var name in names)
            {

            }
        }
        static void Conditionals()
        {
            Console.Write("Enter a number: ");
            var enteredNumber = int.Parse(Console.ReadLine());

            Console.Write("Choose a number to compare your number with: ");
            var compareNumber = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine((enteredNumber == compareNumber) ? "Equal to" : (enteredNumber > compareNumber) ? "Larger than 20" : "Smaller");
            Console.ResetColor();
        }
        static void IfStatement()
        {
            Console.Write("Enter a number: ");
            var enteredNumber = int.Parse(Console.ReadLine());

            Console.Write("Choose a number to compare your number with: ");
            var compareNumber = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            if (enteredNumber == compareNumber)
            {
                Console.WriteLine($"Equals to {compareNumber}");
            }
            else if (enteredNumber < compareNumber)
            {
                Console.WriteLine($"The number is lower than {compareNumber}.");
            }
            else if (enteredNumber > compareNumber)
            {
                Console.WriteLine($"The number is higher than {compareNumber}.");
            }
            
            Console.ResetColor();
        }
        static void Random()
        {
            Random random = new Random();
            int returnValue = random.Next(1, 5);
            Console.WriteLine("Guess number");
            var guess = int.Parse(Console.ReadLine());

            
            if (returnValue == guess)
            {
                Console.WriteLine("Well done!");
            }
            else
            {
                Console.WriteLine("Wrong");
            }
            Console.WriteLine(returnValue);

        }

        static void ForeachWithBreak()
        {
            var nameList = new List<string>();
            Console.WriteLine("Enter names separated by comma, secret imput after Zelda: ");
            var names = Console.ReadLine().Split(',');
            Console.Write("Write the surname: ");
            var surName = Console.ReadLine();

            

            bool allowZelda = false;

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var element in names)
            {
                if (element.Length > 20)
                {
                    Console.WriteLine("Too long name");
                }
                else if (element.Length < 2)
                {
                    Console.WriteLine("Too short name");
                }
                if (element.Contains("AllowZelda"))
                {
                    allowZelda = true;
                    continue;
                }
                else if (element.Contains("Zelda") && !allowZelda)
                {
                    break;
                }
                else
                {
                    //nameList.Add(element);
                    Console.WriteLine(element.Trim() + " " + surName);
                }
                
            }
            Console.ResetColor();
        }
        static void Foreach()
        {
            var nameList = new List<string>();

            Console.WriteLine("Enter names separated by comma (e.g. Lisa,Eva,Klara): ");
            var names = Console.ReadLine().Split(',');

            Console.WriteLine("Write the surname: ");
            var surName = Console.ReadLine();

            foreach (var element in names)
            {
                if (element.Length > 20)
                {
                    Console.WriteLine("Too long name");
                }
                else if (element.Length < 2)
                {
                    Console.WriteLine("Too short name");
                }
                else
                {
                    nameList.Add(element);
                    Console.WriteLine(element.Trim() + " " + surName);
                }
                
                
            }
        }
        static void ForLoop()
        {

            Console.Write("Enter your name: ");
            var name = Console.ReadLine();

            Console.Write("Times to repeat: ");
            var repeat = int.Parse(Console.ReadLine());

            Console.Write("Number of rows: ");
            var rows = int.Parse(Console.ReadLine());

            Console.Write("Number of columns: ");
            var columns = int.Parse(Console.ReadLine());

            char[] nameArray = name.ToCharArray();
            Array.Reverse(nameArray);
            var nameReverse = new string(nameArray);

            Console.ForegroundColor = ConsoleColor.Green;
            for (var i = 0; i < repeat; i++)
            {
                Console.WriteLine($"Your name is {name}");
            }

            for (var j = 0; j < rows; j++)
            {
                for (var k = 0; k < columns; k++)
                {
                    Console.Write(name + nameReverse + "\t");
                }
                Console.WriteLine();
            }


            Console.ResetColor();
        }

        static void While()
        {
            Console.Write("Enter your name: ");
            var nameEntered = Console.ReadLine();

            Console.Write("How many times do u want to repeat? ");
            var timesToRepeat = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            var i = 1;
            
            
            while (i <= timesToRepeat && timesToRepeat < 16 && nameEntered.Length > 1)
            {
                Console.WriteLine($"Your name is: {nameEntered}");
                i++;
            }
            if (timesToRepeat > 15)
            {
                Console.WriteLine("You can't repeat that many times");
            }
            if (nameEntered.Length < 2)
            {
                Console.WriteLine("Enter a longer name");
            }
             
            /*
            while (true)
            {
                if (i <= timesToRepeat)
                {
                    Console.WriteLine($"Your name is: {nameEntered}");
                    i++;
                }
                else
                    break;
            }
            
            */
            /*
            do
            {
                Console.WriteLine($"Your name is {nameEntered}");
                i++;
            }
            while (i <= timesToRepeat);
            */
            Console.ResetColor();

        }

        static void IfStatements()
        {
            /*
            Console.Write("When did you go to sleep last night? ");
            var bedTime = DateTime.Parse(Console.ReadLine());

            Console.Write("When did you wake up? ");
            var wakeUpTime = DateTime.Parse(Console.ReadLine());

            //Console.WriteLine(bedTime);
            var lengthOfSleep = wakeUpTime - bedTime;
            Console.WriteLine(lengthOfSleep);
            */

            
            Console.Write("When did you go to sleep last night? ");
            var bedTime = int.Parse(Console.ReadLine());

            Console.Write("When did you wake up? ");
            var wakeUpTime = int.Parse(Console.ReadLine());

            if (bedTime > wakeUpTime)
            {
                var lengthOfSleep = (wakeUpTime - bedTime) + 24;
                Console.WriteLine($"You have slept {lengthOfSleep} hours");
            }
            else
            {
                var lengthOfSleepLate = (wakeUpTime - bedTime);
                Console.WriteLine($"You have slept {lengthOfSleepLate} hours");
            }
            
            /*
            if (lengthOfSleep < 7)
                Console.WriteLine("You should sleep more");
            else
                Console.WriteLine("You've slept enough!");
                */
        }
    }
}
