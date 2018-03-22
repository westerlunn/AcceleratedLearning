using System;
using System.IO;

namespace Modul8._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a file name: ");
            var fileName = Console.ReadLine();
            try
            {
                File.Create(fileName);
            }
            catch (Exception)
            {
                Console.WriteLine("error");
                //throw;
            }
            
        }
    }
}
