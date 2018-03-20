using System;

namespace Week2Modul6
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Cube mycube = new Cube(2, 3, 4);
            Cube supercube = new Cube(100, 200, 300);

            mycube.WriteVolume();
            supercube.WriteVolume();

            /*
            Circle bob = new Circle("Bob", 8);
            Circle lisa = new Circle("Lisa", 30);

            bob.SayHello();
            lisa.SayHello();

            Console.WriteLine();

            bob.WriteArea();
            lisa.WriteArea();
            */
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

    class Cube
    {
        int _height;
        int _width;
        int _depth;

        public Cube (int height, int width, int depth)
        {
            _height = height;
            _width = width;
            _depth = depth;
        }
        public void WriteVolume()
        {
            double cubeVolume = _height * _width * _depth;
            Console.WriteLine($"The volume of the cube is {cubeVolume}");
        }
    }
}
