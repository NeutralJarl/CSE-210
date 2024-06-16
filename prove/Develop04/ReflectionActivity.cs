using System;

public class ReflectionActivity : MindfulnessActivity
{
    private string[] _prompts = { "Think of a time when you felt truly happy.", "Reflect on a moment of personal growth." };
    private string[] _questions = { "Why was this moment meaningful?", "How can you bring more of such moments into your life?" };

    public ReflectionActivity(int duration)
        : base("Reflection", "This activity will help you reflect on moments of significance in your life.")
    {
        _duration = duration;
    }

    public override void Execute()
    {
        StartActivity();
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        ShowSpinner(5);
        foreach (var question in _questions)
        {
            Console.WriteLine(question);
            ShowSpinner(10);
        }
        EndActivity();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Length)];
    }

    private string GetRandomQuestion()
    {
        Random random = new Random();
        return _questions[random.Next(_questions.Length)];
    }
}
