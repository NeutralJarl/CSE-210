using System;
using System.Collections.Generic;

class Program
{
    static User user = new User();
    static ProgressTracker progressTracker = new ProgressTracker();

    static void Main()
    {
        Console.WriteLine("Welcome to the Fitness Tracker!");

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Workout");
            Console.WriteLine("2. Add Diet");
            Console.WriteLine("3. Add Goal");
            Console.WriteLine("4. View Progress");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddWorkout();
                    break;
                case "2":
                    AddDiet();
                    break;
                case "3":
                    AddGoal();
                    break;
                case "4":
                    ViewProgress();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddWorkout()
    {
        Console.Write("Enter workout type (Cardio/Strength): ");
        string type = Console.ReadLine();
        Console.Write("Enter duration (minutes): ");
        int durationMinutes = int.Parse(Console.ReadLine());
        TimeSpan duration = TimeSpan.FromMinutes(durationMinutes);

        Workout workout = new Workout
        {
            Date = DateTime.Now,
            Duration = duration,
            Type = type
        };

        if (type.ToLower() == "cardio")
        {
            CardioExercise cardioExercise = new CardioExercise();
            Console.Write("Enter exercise name: ");
            cardioExercise.Name = Console.ReadLine();
            cardioExercise.Duration = duration;
            Console.Write("Enter distance (km): ");
            cardioExercise.Distance = double.Parse(Console.ReadLine());
            Console.Write("Enter speed (km/h): ");
            cardioExercise.Speed = double.Parse(Console.ReadLine());

            workout.AddExercise(cardioExercise);
        }
        else if (type.ToLower() == "strength")
        {
            StrengthExercise strengthExercise = new StrengthExercise();
            Console.Write("Enter exercise name: ");
            strengthExercise.Name = Console.ReadLine();
            strengthExercise.Duration = duration;
            Console.Write("Enter reps: ");
            strengthExercise.Reps = int.Parse(Console.ReadLine());
            Console.Write("Enter sets: ");
            strengthExercise.Sets = int.Parse(Console.ReadLine());
            Console.Write("Enter weight (kg): ");
            strengthExercise.Weight = double.Parse(Console.ReadLine());

            workout.AddExercise(strengthExercise);
        }
        else
        {
            Console.WriteLine("Invalid workout type.");
            return;
        }

        user.AddWorkout(workout);
        Console.WriteLine("Workout added successfully.");
    }

    static void AddDiet()
    {
        Diet diet = new Diet
        {
            Date = DateTime.Now
        };

        Console.Write("Enter meal name: ");
        string mealName = Console.ReadLine();
        Console.Write("Enter calories: ");
        double calories = double.Parse(Console.ReadLine());

        Meal meal = new Meal
        {
            Name = mealName,
            Calories = calories
        };

        diet.AddMeal(meal);
        user.AddDiet(diet);
        Console.WriteLine("Diet added successfully.");
    }

    static void AddGoal()
    {
        Console.Write("Enter goal type: ");
        string type = Console.ReadLine();
        Console.Write("Enter target value: ");
        double target = double.Parse(Console.ReadLine());
        Console.Write("Enter current progress: ");
        double currentProgress = double.Parse(Console.ReadLine());

        Goal goal = new Goal
        {
            Type = type,
            Target = target,
            CurrentProgress = currentProgress
        };

        user.AddGoal(goal);
        Console.WriteLine("Goal added successfully.");
    }

    static void ViewProgress()
    {
        progressTracker.TrackWorkoutProgress(user);
        progressTracker.TrackDietProgress(user);

        Console.WriteLine("\nUser Progress:");
        foreach (var goal in user.Goals)
        {
            Console.WriteLine($"Goal: {goal.Type}, Target: {goal.Target}, Current Progress: {goal.CurrentProgress}, Achieved: {goal.IsGoalAchieved()}");
        }
    }
}
