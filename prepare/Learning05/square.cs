using System;

namespace ShapesApp
{
    public class Square : Shape
    {
        // Private member variable for side length
        private double _side;

        // Constructor
        public Square(string color, double side) : base(color)
        {
            _side = side;
        }

        // Override the GetArea method
        public override double GetArea()
        {
            return _side * _side;
        }
    }
}
