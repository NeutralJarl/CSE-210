using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalTracker tracker = new GoalTracker();
            tracker.LoadData();

            while (true)
            {
                Console.WriteLine("\nEternal Quest - Goal Tracker");
                Console.WriteLine("1. View Goals");
                Console.WriteLine("2. Add New Goal");
                Console.WriteLine("3. Record Goal Achievement");
                Console.WriteLine("4. View Score");
                Console.WriteLine("5. Save and Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        tracker.DisplayGoals();
                        break;
                    case "2":
                        tracker.AddGoal();
                        break;
                    case "3":
                        tracker.RecordAchievement();
                        break;
                    case "4":
                        tracker.DisplayScore();
                        break;
                    case "5":
                        tracker.SaveData();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}
