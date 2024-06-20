using System;
using System.Collections.Generic;

namespace ShapesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Square instance
            Square square = new Square("Red", 5.0);
            Console.WriteLine($"Square - Color: {square.Color}, Area: {square.GetArea()}");

            // Create a Rectangle instance
            Rectangle rectangle = new Rectangle("Blue", 4.0, 6.0);
            Console.WriteLine($"Rectangle - Color: {rectangle.Color}, Area: {rectangle.GetArea()}");

            // Create a Circle instance
            Circle circle = new Circle("Green", 3.0);
            Console.WriteLine($"Circle - Color: {circle.Color}, Area: {circle.GetArea()}");

            // Build a list of shapes
            List<Shape> shapes = new List<Shape> { square, rectangle, circle };

            // Look through the list of shapes
            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"Shape - Color: {shape.Color}, Area: {shape.GetArea()}");
            }
        }
    }
}
