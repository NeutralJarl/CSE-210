using System;
using System.Threading;

public class ReflectionActivity : MindfulnessActivity
{
    private static readonly string[] Prompts = new[]
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions = new[]
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
    {
        Name = "Reflection";
        Description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public override void Execute()
    {
        StartActivity();

        Random random = new Random();
        string prompt = Prompts[random.Next(Prompts.Length)];
        Console.WriteLine(prompt);
        ShowCountdown(5);

        int timeRemaining = Duration - 5;
        while (timeRemaining > 0)
        {
            string question = Questions[random.Next(Questions.Length)];
            Console.WriteLine(question);
            ShowCountdown(5);
            timeRemaining -= 5;
        }

        EndActivity();
    }
}
