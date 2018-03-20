using System;

namespace Modul6._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Circle myCircle = new Circle(5, 6, 7);
            Rectangle myRectangle = new Rectangle(10, 20, 30, 40);
            Triangle myTriangle = new Triangle(15, 25, 35, 45);
            Console.WriteLine(myCircle.ToString()); //Same shit, but ToString not needed.
            Console.WriteLine(myRectangle);
            Console.WriteLine(myTriangle);
        }
    }

    class Circle
    {
        int _x;
        int _y;
        int _radius;

        public Circle(int x, int y, int radius)
        {
            _x = x;
            _y = y;
            _radius = radius;
        }

        public void SayHello()
        {
            Console.WriteLine($"I'm a circle with the name x = {_x}, y = {_y} and radius = {_radius}");

        }
        public override string ToString()
        {
            return $"I'm a circle with the x = {_x}, y = {_y} and radius = {_radius}.";
        }

    }
    class Rectangle
    {
        int _x;
        int _y;
        int _height;
        int _width;

        public Rectangle (int x, int y, int width, int height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }
        public override string ToString()
        {
            return $"I'm a rectangle with x = {_x}, y = {_y}, height = {_height} and width = {_width}. ";
        }

    }

    class Triangle
    {
        int _x;
        int _y;
        int _baseLenght;
        int _height;

        public Triangle (int x, int y, int baseLength, int height)
        {
            _x = x;
            _y = y;
            _baseLenght = baseLength;
            _height = height;
        }
        public override string ToString()
        {
            return $"I'm a triangle with x = {_x}, y = {_y}, baselength = {_baseLenght} and height = {_height}.";
        }

    }
}
