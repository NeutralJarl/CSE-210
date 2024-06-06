using System;
using System.Threading;

public abstract class MindfulnessActivity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }

    public void StartActivity()
    {
        Console.WriteLine($"Starting {Name} activity.");
        Console.WriteLine(Description);
        Console.Write("Enter the duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowCountdown(3);
    }

    public void EndActivity()
    {
        Console.WriteLine("Good job! You have completed the activity.");
        Console.WriteLine($"Activity: {Name}, Duration: {Duration} seconds.");
        ShowCountdown(3);
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }
    }

    public abstract void Execute();
}
