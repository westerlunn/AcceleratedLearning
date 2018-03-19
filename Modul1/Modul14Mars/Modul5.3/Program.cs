using System;
using System.Drawing;

namespace Modul5._3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Point p1 = new Point(3, 4);
            Console.WriteLine("Before" + $"Punkt = {p1.ToString()}");
            ChangePoint(p1);
            Console.WriteLine("After" + $"Punkt = {p1.ToString()}");

            /*
            Point p1 = new Point();
            p1.X = 3;
            p1.Y = 4;

            Console.WriteLine($"Before: \t Point = ({p1.X}, {p1.Y})");
            */
        }
        class Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
            public int X { get; set; }
            public int Y { get; set; }

            public override string ToString()
            {
                return $"({X},{Y})";
            }
            static void ChangePoint(Point p1)
            {
                p1.X = 999;
                p1.Y = 888;
            }
        }
        
        
    }
    /*
    public struct Point_Struct
    {
        public Point_Struct(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }

    static void ChangePoint(Point p1)
    {
        p1.X = 999;
        p1.Y = 888;
    }
}
*/
}
