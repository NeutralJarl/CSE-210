using System;

class Program
{
    static void Main(string[] args)
    {
        // Create fractions using different constructors
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(5);
        Fraction fraction3 = new Fraction(3, 4);
        Fraction fraction4 = new Fraction(1, 3);

        // Display fractions and their decimal equivalents
        Console.WriteLine($"{fraction1.GetFractionString()} = {fraction1.GetDecimalValue()}");
        Console.WriteLine($"{fraction2.GetFractionString()} = {fraction2.GetDecimalValue()}");
        Console.WriteLine($"{fraction3.GetFractionString()} = {fraction3.GetDecimalValue()}");
        Console.WriteLine($"{fraction4.GetFractionString()} = {fraction4.GetDecimalValue()}");

        // Testing getters and setters
        fraction1.Numerator = 2;
        fraction1.Denominator = 5;
        Console.WriteLine($"{fraction1.GetFractionString()} = {fraction1.GetDecimalValue()}");
    }
}
