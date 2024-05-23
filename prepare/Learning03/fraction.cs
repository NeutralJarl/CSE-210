using System;

public class Fraction
{
    // Private attributes for numerator and denominator
    private int numerator;
    private int denominator;

    // Default constructor initializing to 1/1
    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

    // Constructor initializing to top/1
    public Fraction(int top)
    {
        numerator = top;
        denominator = 1;
    }

    // Constructor initializing to top/bottom
    public Fraction(int top, int bottom)
    {
        if (bottom == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        numerator = top;
        denominator = bottom;
    }

    // Getter and Setter for numerator
    public int Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }

    // Getter and Setter for denominator
    public int Denominator
    {
        get { return denominator; }
        set 
        { 
            if (value == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }
            denominator = value; 
        }
    }

    // Method to return the fraction as a string (e.g., "3/4")
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    // Method to return the decimal value of the fraction (e.g., 0.75)
    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}
