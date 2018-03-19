using System;
using System.Diagnostics;
using System.Text;

namespace Modul5
{
    class Program
    {
        static void Main(string[] args)
        {
            string repeatMe = "Tennis anyone? ";
            //int cycles = 100;
            Stopwatch stopWatch = new Stopwatch();
            Console.WriteLine("Cycles \t Time \t Length ");

            for (int i = 5; i <= 50000; i = i * 10)
            {
                stopWatch.Start();
                int cycles = i;
                var result = GenerateString(repeatMe, cycles);
                stopWatch.Stop();
                var time = stopWatch.Elapsed.TotalMilliseconds;
                Console.WriteLine($"{cycles} \t {time} \t {result.Length}");
            }
            //var result = GenerateString(repeatMe, cycles);
            //var builder = new StringBuilder();
            Console.WriteLine("\nCycles \t Time \t Length");
            Stopwatch stopWatch2 = new Stopwatch();
            for (int i = 5; i <= 50000; i = i * 10)
            {
                stopWatch2.Start();
                int cycles = i;
                var builder = GenerateString_StringBuilder(repeatMe, cycles);
                stopWatch2.Stop();
                var time = stopWatch2.Elapsed.TotalMilliseconds;
                Console.WriteLine($"{cycles} \t {time} \t {builder.Length}");
            }


        }

        static string GenerateString_StringBuilder(string repeatMe, int cycles)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < cycles; i++)
            {
                builder = builder.Append(repeatMe);
            }
            return builder.ToString();
        }

        static string GenerateString(string repeatMe, int cycles)
        {
            string result = "";
            for (int i = 0; i < cycles; i++)
            {
                result = result + repeatMe;
                //Console.Write(repeatMe);
            }
            return result;
        }

    }

}
