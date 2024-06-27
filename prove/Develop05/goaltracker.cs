using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class GoalTracker
    {
        private List<Goal> _goals;
        private int _totalScore;
        private int _prestigeCount;
        private Dictionary<string, int> _rankCounts;
        private readonly string _filePath = "goals.txt";

        // Define ranks based on last 4 digits of total score
        private string[] _ranks = {
            "Novice", "Apprentice", "Journeyman", "Expert", "Master",
            "Grandmaster", "Legend", "Hero", "Champion", "Immortal"
        };

        public GoalTracker()
        {
            _goals = new List<Goal>();
            _totalScore = 0;
            _prestigeCount = 0;
            _rankCounts = new Dictionary<string, int>();

            // Initialize rank counts
            foreach (string rank in _ranks)
            {
                _rankCounts.Add(rank, 0);
            }
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
            int goalNumber;
            if (!int.TryParse(Console.ReadLine(), out goalNumber) || goalNumber < 1 || goalNumber > _goals.Count)
            {
                Console.WriteLine("Invalid goal number.");
                return;
            }

            goalNumber--; // Adjust for 0-based index
            Goal goal = _goals[goalNumber];
            goal.Record();

            int pointsAwarded = goal.Points;
            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsCompleted())
            {
                pointsAwarded += checklistGoal.BonusPoints;
            }

            _totalScore += pointsAwarded;
            Console.WriteLine($"Recorded! You earned {pointsAwarded} points. Total score: {_totalScore}");

            // Check for rank up or prestige
            CheckForRankUpOrPrestige();
        }

        private void CheckForRankUpOrPrestige()
        {
            // Calculate last 4 digits of total score
            int lastFourDigits = _totalScore % 10000;

            // Determine rank based on last 4 digits
            int rankIndex = lastFourDigits / 1000;
            if (rankIndex >= _ranks.Length)
            {
                rankIndex = _ranks.Length - 1; // Cap at highest rank
            }
            string currentRank = _ranks[rankIndex];

            // Update rank count
            _rankCounts[currentRank]++;

            // Check if score has increased by 10,000 points
            if (_totalScore >= (_prestigeCount + 1) * 10000)
            {
                ApplyPrestige();
            }
        }

        private void ApplyPrestige()
        {
            // Increment prestige count
            _prestigeCount++;

            // Display prestige achieved
            Console.WriteLine($"Prestige! You have reset to {_ranks[0]} with {_prestigeCount} prestige(s).");

            // Reset rank counts for each rank
            foreach (var rank in _rankCounts.Keys)
            {
                _rankCounts[rank] = 0;
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

            // Calculate last 4 digits of total score
            int lastFourDigits = _totalScore % 10000;

            // Determine rank based on last 4 digits
            int rankIndex = lastFourDigits / 1000;
            if (rankIndex >= _ranks.Length)
            {
                rankIndex = _ranks.Length - 1; // Cap at highest rank
            }
            string currentRank = _ranks[rankIndex];

            // Display current rank with stars for prestige
            int stars = _prestigeCount;
            string rankDisplay = currentRank + new string('*', stars);
            Console.WriteLine($"Current Rank: {rankDisplay}");
        }

        public void SaveData()
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                writer.WriteLine(_totalScore);
                writer.WriteLine(_prestigeCount);
                writer.WriteLine(_rankCounts.Count);
                foreach (var kvp in _rankCounts)
                {
                    writer.WriteLine($"{kvp.Key};{kvp.Value}");
                }

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
                    _prestigeCount = int.Parse(reader.ReadLine());

                    _rankCounts.Clear();
                    int rankCount = int.Parse(reader.ReadLine());
                    for (int i = 0; i < rankCount; i++)
                    {
                        string[] rankData = reader.ReadLine().Split(';');
                        string rankName = rankData[0];
                        int count = int.Parse(rankData[1]);
                        _rankCounts.Add(rankName, count);
                    }

                    _goals.Clear();
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
