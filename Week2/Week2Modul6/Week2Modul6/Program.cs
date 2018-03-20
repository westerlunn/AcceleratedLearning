using System;

namespace Week2Modul6
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Circle bob = new Circle("Bob", 8);
            Circle lisa = new Circle("Lisa", 30);

            bob.SayHello();
            lisa.SayHello();

            Console.WriteLine();

            bob.WriteArea();
            lisa.WriteArea();
        }
    }


    class Circle
    {
        string _name;
        int _radius;

        public Circle(string name, int radius)
        {
            _name = name;
            _radius = radius;
        }

        public void SayHello()
        {
            Console.WriteLine($"I'm a circle with the name {_name} and the radius {_radius}");
        }

        public void WriteArea()
        {
            double circleArea = Math.Pow(_radius, 2) * Math.PI;
            Console.WriteLine($"{circleArea:f2}");
        }
    }
}
