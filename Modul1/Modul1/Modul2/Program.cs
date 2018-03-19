using System;

namespace Modul2
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkingWithTypes();


        }
        static void Fruits()
        {
            Console.WriteLine("How many fruits would you like to add? ");
            var numberOfFruits = int.Parse(Console.ReadLine());

            for (var i = 0; i < numberOfFruits; i++)
            {
                Console.WriteLine("Enter fruit: ");
            }
            Console.Write("Enter fruit 1: ");
            var fruit1 = Console.ReadLine();

            Console.Write("Enter fruit 2: ");
            var fruit2 = Console.ReadLine();

            Console.Write("Enter fruit 3: ");
            var fruit3 = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("You entered the fruits: " +fruit1 +", " + fruit2 + ", " + fruit3 +". \n");
            Console.WriteLine("You entered the fruits: {0}, {1}, {2}.", fruit1, fruit2, fruit3);
            Console.WriteLine($"You entered the fruits: {fruit1}, {fruit2}, {fruit3}.");

        }
        static void WorkingWithTypes()
        {
            //TODO: Här skulle man kunna göra en metod som heter "GetName" eller liknande, som anropas. 
            Console.Write("What is your name? ");
            var userName = Console.ReadLine();

            //TODO: Samma som ovan, getAge()
            Console.Write("How old are you? ");
            var userAge = Convert.ToInt32(Console.ReadLine());
            var yearsUntilPension = 65 - userAge;

            //TODO: Samma som ovan, getCharacter()
            Console.Write("What is your favorite character? ");
            var userFavoriteCharacter = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Thank you!");
            Console.WriteLine("Your name is: " + userName);
            Console.WriteLine("You have " + yearsUntilPension + " years until pension");

            bool youLikeNumbers = true;
            
            //TODO: Här skulle man också kunna göra en metod
            foreach (var character in userFavoriteCharacter)
            {
                if (char.IsDigit(character))
                {
                    youLikeNumbers = true;
                }
                if (char.IsLetter(character))
                {
                    youLikeNumbers = false;
                }
                else
                    Console.WriteLine("You like special characters");
                
            }
            Console.WriteLine("Your favorite character is: " + userFavoriteCharacter);
            if (youLikeNumbers)
            {
                Console.WriteLine("You like numbers");
            }
            else if (youLikeNumbers == false)
            {
                Console.WriteLine("You don't like numbers");
            }
            else if (youLikeNumbers && youLikeNumbers == false)
                Console.WriteLine("You can't decide");
            Console.WriteLine();
        }
        static void WorkingWithStrings()
        {
            Console.Write("What is your name? ");
            var userName = Console.ReadLine();

            Console.Write("How old are you? ");
            var userAge = Console.ReadLine();

            Console.Write("What is your favorite letter? ");
            var userFavoriteLetter = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Thank you!");
            Console.WriteLine("Your name is: " + userName);
            Console.WriteLine("You are " + userAge + " years old");
            Console.WriteLine("Your favorite letter is: " + userFavoriteLetter);
            Console.WriteLine();
        }
    }
}
