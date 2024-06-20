using System;

namespace ShapesApp
{
    public abstract class Shape
    {
        // Property for Color
        public string Color { get; set; }

        // Constructor
        protected Shape(string color)
        {
            Color = color;
        }

        // Abstract Method for GetArea
        public abstract double GetArea();
    }
}
