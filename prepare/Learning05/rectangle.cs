using System;

namespace ShapesApp
{
    public class Rectangle : Shape
    {
        // Private member variables for width and height
        private double _width;
        private double _height;

        // Constructor
        public Rectangle(string color, double width, double height) : base(color)
        {
            _width = width;
            _height = height;
        }

        // Override the GetArea method
        public override double GetArea()
        {
            return _width * _height;
        }
    }
}
