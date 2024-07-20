using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static List<User> users = new List<User>();
    static User currentUser;
    static ProgressTracker progressTracker = new ProgressTracker();
    static string dataFilePath = "userData.json";

    static void Main()
    {
        LoadUsers();
        Console.WriteLine("Welcome to the Fitness Tracker!");

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create New User");
            Console.WriteLine("2. Select User");
            Console.WriteLine("3. Add Workout");
            Console.WriteLine("4. Add Diet");
            Console.WriteLine("5. View Progress");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewUser();
                    break;
                case "2":
                    SelectUser();
                    break;
                case "3":
                    AddWorkout();
                    break;
                case "4":
                    AddDiet();
                    break;
                case "5":
                    ViewProgress();
                    break;
                case "6":
                    SaveUsers();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateNewUser()
    {
        Console.Write("Enter user name: ");
        string name = Console.ReadLine();
        Console.Write("Enter user age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Enter user weight (kg): ");
        double weight = double.Parse(Console.ReadLine());
        Console.Write("Enter user height (cm): ");
        double height = double.Parse(Console.ReadLine());

        currentUser = new User
        {
            Name = name,
            Age = age,
            Weight = weight,
            Height = height
        };

        // Add an initial goal for calorie burn (arbitrary target, e.g., 2000 calories)
        currentUser.AddGoal(new Goal("Calorie Burn", 2000)); 

        users.Add(currentUser);
        Console.WriteLine("New user created and selected successfully.");
    }

    static void SelectUser()
    {
        if (users.Count == 0)
        {
            Console.WriteLine("No users available. Please create a new user first.");
            return;
        }

        Console.WriteLine("Select a user:");
        for (int i = 0; i < users.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {users[i].Name}");
        }

        Console.Write("Enter the number of the user: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < users.Count)
        {
            currentUser = users[index];
            Console.WriteLine($"User selected: {currentUser.Name}");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    static void AddWorkout()
    {
        if (currentUser == null)
        {
            Console.WriteLine("No user selected. Please create or select a user first.");
            return;
        }

        Console.Write("Enter workout type (Cardio/Strength): ");
        string type = Console.ReadLine();
        Console.Write("Enter duration (minutes): ");
        int durationMinutes = int.Parse(Console.ReadLine());
        TimeSpan duration = TimeSpan.FromMinutes(durationMinutes);

        Workout workout = new Workout(DateTime.Now, duration, type);

        if (type.ToLower() == "cardio")
        {
            Console.Write("Enter exercise name: ");
            string name = Console.ReadLine();
            Console.Write("Enter distance (km): ");
            double distance = double.Parse(Console.ReadLine());
            Console.Write("Enter speed (km/h): ");
            double speed = double.Parse(Console.ReadLine());

            CardioExercise cardioExercise = new CardioExercise
            {
                Name = name,
                Duration = duration,
                Distance = distance,
                Speed = speed
            };

            workout.AddExercise(cardioExercise);
        }
        else if (type.ToLower() == "strength")
        {
            Console.Write("Enter exercise name: ");
            string name = Console.ReadLine();
            Console.Write("Enter reps: ");
            int reps = int.Parse(Console.ReadLine());
            Console.Write("Enter sets: ");
            int sets = int.Parse(Console.ReadLine());
            Console.Write("Enter weight (kg): ");
            double weight = double.Parse(Console.ReadLine());

            StrengthExercise strengthExercise = new StrengthExercise
            {
                Name = name,
                Duration = duration,
                Reps = reps,
                Sets = sets,
                Weight = weight
            };

            workout.AddExercise(strengthExercise);
        }
        else
        {
            Console.WriteLine("Invalid workout type.");
            return;
        }

        currentUser.AddWorkout(workout);
        Console.WriteLine("Workout added successfully.");
        UpdateProgress();
    }

    static void AddDiet()
    {
        if (currentUser == null)
        {
            Console.WriteLine("No user selected. Please create or select a user first.");
            return;
        }

        Diet diet = new Diet
        {
            Date = DateTime.Now
        };

        Console.Write("Enter meal name: ");
        string mealName = Console.ReadLine();
        Console.Write("Enter calories: ");
        double calories = double.Parse(Console.ReadLine());

        Meal meal = new Meal(mealName, calories);
        diet.AddMeal(meal);

        currentUser.AddDiet(diet);
        Console.WriteLine("Diet added successfully.");
        UpdateProgress();
    }

    static void ViewProgress()
    {
        if (currentUser == null)
        {
            Console.WriteLine("No user selected. Please create or select a user first.");
            return;
        }

        // Update goals based on the latest data
        progressTracker.UpdateGoalsBasedOnWorkouts(currentUser);
        progressTracker.UpdateGoalsBasedOnDiets(currentUser);

        Console.WriteLine("\nUser Progress:");
        foreach (var goal in currentUser.GetGoals())
        {
            Console.WriteLine($"Goal: {goal.Type}, Target: {goal.Target}, Current Progress: {goal.Progress}, Achieved: {goal.IsGoalAchieved()}");
        }
    }

    static void UpdateProgress()
    {
        if (currentUser != null)
        {
            progressTracker.UpdateGoalsBasedOnWorkouts(currentUser);
            progressTracker.UpdateGoalsBasedOnDiets(currentUser);
        }
    }

    static void SaveUsers()
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(dataFilePath, jsonString);
            Console.WriteLine("User data saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving user data: {ex.Message}");
        }
    }

    static void LoadUsers()
    {
        if (!File.Exists(dataFilePath))
        {
            Console.WriteLine("No user data found.");
            return;
        }

        try
        {
            string jsonString = File.ReadAllText(dataFilePath);
            users = JsonSerializer.Deserialize<List<User>>(jsonString) ?? new List<User>();
            if (users.Count > 0)
            {
                currentUser = users[0]; // Default to the first user if available
                Console.WriteLine("User data loaded successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading user data: {ex.Message}");
        }
    }
}
