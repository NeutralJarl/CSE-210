using System;
using System.Threading;

public abstract class MindfulnessActivity
{
    private string _name;
    private string _description;
    protected int _duration;

    protected MindfulnessActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Starting {_name} activity...");
        Console.WriteLine(_description);
        Console.WriteLine($"This activity will last for {_duration} seconds.");
        ShowCountdown(3);
    }

    public void EndActivity()
    {
        Console.WriteLine($"Ending {_name} activity...");
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
            Console.Write("\b\b");
        }
        Console.WriteLine();
    }

    protected void ShowSpinner(int duration)
    {
        int spinnerDelay = 100;
        string[] spinner = { "/", "-", "\\", "|" };
        for (int i = 0; i < duration * 10; i++)
        {
            Console.Write(spinner[i % 4]);
            Thread.Sleep(spinnerDelay);
            Console.Write("\b");
        }
    }

    public abstract void Execute();
}
