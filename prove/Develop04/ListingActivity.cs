using System;
using System.Threading;

public class ListingActivity : MindfulnessActivity
{
    private static readonly string[] Prompts = new[]
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        Name = "Listing";
        Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public override void Execute()
    {
        StartActivity();

        Random random = new Random();
        string prompt = Prompts[random.Next(Prompts.Length)];
        Console.WriteLine(prompt);
        ShowCountdown(5);

        int timeRemaining = Duration - 5;
        Console.WriteLine("Start listing items:");
        int itemCount = 0;

        while (timeRemaining > 0)
        {
            Console.Write("Item: ");
            Console.ReadLine();
            itemCount++;
            timeRemaining -= 5;
        }

        Console.WriteLine($"You listed {itemCount} items.");
        EndActivity();
    }
}
