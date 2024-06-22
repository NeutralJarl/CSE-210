using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class GoalTracker
    {
        private List<Goal> _goals;
        private int _totalScore;
        private readonly string _filePath = "goals.txt";

        public GoalTracker()
        {
            _goals = new List<Goal>();
            _totalScore = 0;
        }

        public void AddGoal()
        {
            Console.WriteLine("\nAdd New Goal");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Choose goal type: ");
            string choice = Console.ReadLine();

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter points: ");
            int points = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name, points));
                    break;
                case "2":
                    _goals.Add(new EternalGoal(name, points));
                    break;
                case "3":
                    Console.Write("Enter target count: ");
                    int targetCount = int.Parse(Console.ReadLine());
                    Console.Write("Enter bonus points: ");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    _goals.Add(new ChecklistGoal(name, points, targetCount, bonusPoints));
                    break;
                default:
                    Console.WriteLine("Invalid choice. Goal not added.");
                    break;
            }
        }

        public void RecordAchievement()
        {
            Console.WriteLine("\nRecord Goal Achievement");
            DisplayGoals();

            Console.Write("Enter goal number to record: ");
            int goalNumber = int.Parse(Console.ReadLine()) - 1;

            if (goalNumber >= 0 && goalNumber < _goals.Count)
            {
                Goal goal = _goals[goalNumber];
                goal.Record();

                int pointsAwarded = goal.Points;
                if (goal is ChecklistGoal checklistGoal && checklistGoal.IsCompleted())
                {
                    pointsAwarded += checklistGoal.BonusPoints;
                }

                _totalScore += pointsAwarded;
                Console.WriteLine($"Recorded! You earned {pointsAwarded} points. Total score: {_totalScore}");
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }

        public void DisplayGoals()
        {
            Console.WriteLine("\nGoals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                _goals[i].Display();
            }
        }

        public void DisplayScore()
        {
            Console.WriteLine($"\nTotal Score: {_totalScore}");
        }

        public void SaveData()
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                writer.WriteLine(_totalScore);
                foreach (var goal in _goals)
                {
                    string goalType = goal.GetType().Name;
                    writer.WriteLine($"{goalType};{goal.Name};{goal.Points}");
                    if (goal is EternalGoal eternalGoal)
                    {
                        writer.WriteLine(eternalGoal.TimesRecorded);
                    }
                    else if (goal is ChecklistGoal checklistGoal)
                    {
                        writer.WriteLine($"{checklistGoal.CurrentCount};{checklistGoal.TargetCount};{checklistGoal.BonusPoints}");
                    }
                    else if (goal is SimpleGoal simpleGoal)
                    {
                        writer.WriteLine(simpleGoal.Completed);
                    }
                }
            }
            Console.WriteLine("Data saved.");
        }

        public void LoadData()
        {
            if (File.Exists(_filePath))
            {
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    _totalScore = int.Parse(reader.ReadLine());
                    while (!reader.EndOfStream)
                    {
                        string[] goalData = reader.ReadLine().Split(';');
                        string goalType = goalData[0];
                        string name = goalData[1];
                        int points = int.Parse(goalData[2]);

                        switch (goalType)
                        {
                            case "SimpleGoal":
                                SimpleGoal simpleGoal = new SimpleGoal(name, points);
                                simpleGoal.Completed = bool.Parse(reader.ReadLine());
                                _goals.Add(simpleGoal);
                                break;
                            case "EternalGoal":
                                EternalGoal eternalGoal = new EternalGoal(name, points);
                                eternalGoal.TimesRecorded = int.Parse(reader.ReadLine());
                                _goals.Add(eternalGoal);
                                break;
                            case "ChecklistGoal":
                                string[] checklistData = reader.ReadLine().Split(';');
                                int currentCount = int.Parse(checklistData[0]);
                                int targetCount = int.Parse(checklistData[1]);
                                int bonusPoints = int.Parse(checklistData[2]);
                                ChecklistGoal checklistGoal = new ChecklistGoal(name, points, targetCount, bonusPoints);
                                checklistGoal.CurrentCount = currentCount;
                                _goals.Add(checklistGoal);
                                break;
                        }
                    }
                }
                Console.WriteLine("Data loaded.");
            }
            else
            {
                Console.WriteLine("No saved data found.");
            }
        }
    }
}
