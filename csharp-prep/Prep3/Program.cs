using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Guess My Number!");
        
        // Generate a random magic number between 1 and 100
        Random random = new Random();
        int magicNumber = random.Next(1, 101);
        
        int guess = 0;
        
        // Loop until the guess matches the magic number
        while (guess != magicNumber)
        {
            // Ask for a guess
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            
            // Higher or Lower?
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}
