using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            //ColorText();
            var text = ReadFile();
            WriteToFile(text);

        }

        public static string ReadFile()
        {
            var text = "";
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Project\AcceleratedLearning\Logger\textdokument.txt"))
                {
                    text = sr.ReadToEnd();
                    Console.WriteLine(text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return text;
        }

        public static void ColorText()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void WriteToFile(string text)
        {
            string path = @"C:\Project\AcceleratedLearning\Logger\\MyTest";

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(text);
                }
            }
        }

    }
}
