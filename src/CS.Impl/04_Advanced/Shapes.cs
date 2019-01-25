using System;

namespace CS.Impl._04_Advanced
{
    public abstract class Shape
    {
        protected double area;
        protected double perimeter;

        public double GetArea()
        {
            return area;
        }

        public double GetPerimeter()
        {
            return perimeter;
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }

    public class Circle : Shape
    {
        public Circle(double radius)
        {
            area = Math.Round(Math.PI * Math.Pow(radius, 2));
            perimeter = Math.Round(2 * Math.PI * radius);
        }

    }

    public class Rectangle : Shape
    {
        public Rectangle(double length, double width)
        {
            area = length * width;
            perimeter = 2*(length + width);
        }

    }

    public class Square : Shape
    {
        public Square(double sideLength)
        {
            area = sideLength * sideLength;
            perimeter = 2 * (sideLength + sideLength);
        }

    }
}