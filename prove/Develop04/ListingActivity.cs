using System;

public class ListingActivity : MindfulnessActivity
{
    private string[] _prompts = { "List things you are grateful for.", "List your favorite activities." };

    public ListingActivity(int duration)
        : base("Listing", "This activity will help you list and acknowledge positive aspects of your life.")
    {
        _duration = duration;
    }

    public override void Execute()
    {
        StartActivity();
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        ShowSpinner(5);
        for (int i = 0; i < _duration / 5; i++)
        {
            Console.Write("- ");
            Console.ReadLine();
        }
        EndActivity();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Length)];
    }
}
