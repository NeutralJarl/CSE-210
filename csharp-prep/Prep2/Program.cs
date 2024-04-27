using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for their grade percentage
        Console.Write("What is your current grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter = "";

        if (percent >=90)
        {
            letter = "A";
        }

        else if (percent >= 80)
        {
            letter = "B";
        }
        
        else if (percent >70)
        {
            letter = "C";
        }

        else if (percent >=60)
        {
            letter = "D";
        }

        else if (percent >=50)
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is a(n) {letter}.");

        if (percent >=70)
        {
            Console.WriteLine("Congratulations, You've passed!");
        }

        else if (percent <=70)
        {
            Console.WriteLine("Work on improving your grade!");
        }

    }
}