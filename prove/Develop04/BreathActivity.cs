using System;

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int duration) 
        : base("Breathing", "This activity will help you relax by guiding you through slow breathing exercises.")
    {
        _duration = duration;
    }

    public override void Execute()
    {
        StartActivity();
        for (int i = 0; i < _duration / 6; i++)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(2);
            Console.WriteLine("Hold...");
            ShowCountdown(2);
            Console.WriteLine("Breathe out...");
            ShowCountdown(2);
        }
        EndActivity();
    }
}
