using System;
using System.Diagnostics;

namespace Week2Modul8
{
    class Chocolate
    {
        int pieces;

        
    }

    class Program
    {
        static void GreetUser()
        {
            Console.WriteLine("The chocolate contains 24 pieces");
            Console.Write("How many like to share? ");
            var peopleToShare = Convert.ToDecimal(Console.ReadLine());
        }
        static void Process(decimal peopleToShare)
        {
            if (peopleToShare == 0)
            {
                throw new ArgumentException();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("The chocolate contains 24 pieces");
            Console.Write("How many like to share? ");
            var peopleToShare = Convert.ToDecimal(Console.ReadLine());
            //GreetUser(peopleToShare);
            try
            {
                Process(peopleToShare);
                Console.WriteLine($"Everyone will get {24 / peopleToShare} pieces");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught", e);
                //throw;
            }
            
            
        }
    }
}
