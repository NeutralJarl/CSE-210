using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a new user
        User user = new User
        {
            Name = "John Doe",
            Age = 30,
            Weight = 75.0,
            Height = 1.8
        };

        // Create a workout and add exercises
        Workout workout = new Workout
        {
            Date = DateTime.Now,
            Duration = TimeSpan.FromHours(1),
            Type = "Cardio"
        };

        CardioExercise run = new CardioExercise
        {
            Name = "Running",
            Duration = TimeSpan.FromMinutes(30),
            Distance = 5.0,
            Speed = 10.0
        };

        StrengthExercise pushUps = new StrengthExercise
        {
            Name = "Push-Ups",
            Duration = TimeSpan.FromMinutes(10),
            Reps = 15,
            Sets = 3,
            Weight = 0
        };

        workout.AddExercise(run);
        workout.AddExercise(pushUps);

        user.AddWorkout(workout);

        // Create a diet and add meals
        Diet diet = new Diet
        {
            Date = DateTime.Now
        };

        Meal breakfast = new Meal
        {
            Name = "Breakfast",
            Calories = 350
        };

        diet.AddMeal(breakfast);

        user.AddDiet(diet);

        // Create a goal
        Goal weightLossGoal = new Goal
        {
            Type = "Weight Loss",
            Target = 70.0,
            CurrentProgress = 75.0
        };

        user.AddGoal(weightLossGoal);

        // Track progress
        ProgressTracker progressTracker = new ProgressTracker();
        progressTracker.TrackWorkoutProgress(user);
        progressTracker.TrackDietProgress(user);

        Console.WriteLine("Fitness Tracker initialized successfully.");
    }
}
