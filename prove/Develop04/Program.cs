using System;

public class Program
{
    public static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Select an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Exit");
            string choice = Console.ReadLine();

            if (choice == "4")
            {
                running = false;
                break;
            }

            Console.WriteLine("Enter the duration in seconds:");
            int duration = int.Parse(Console.ReadLine());

            MindfulnessActivity activity = choice switch
            {
                "1" => new BreathingActivity(duration),
                "2" => new ReflectionActivity(duration),
                "3" => new ListingActivity(duration),
                _ => null
            };

            activity?.Execute();

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
