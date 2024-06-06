using System;
using System.Threading;

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        Name = "Breathing";
        Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void Execute()
    {
        StartActivity();

        int cycleDuration = 8; // Each cycle (breathe in and out) takes 8 seconds
        int timeRemaining = Duration;

        while (timeRemaining >= cycleDuration)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(4);
            timeRemaining -= 4;

            Console.WriteLine("Breathe out...");
            ShowCountdown(4);
            timeRemaining -= 4;
        }

        EndActivity();
    }
}
