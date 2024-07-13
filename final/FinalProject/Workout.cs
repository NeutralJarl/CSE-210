using System;
using System.Collections.Generic;

public class Workout
{
    public DateTime Date { get; set; }
    public TimeSpan Duration { get; set; }
    public string Type { get; set; }
    public List<Exercise> Exercises { get; set; } = new List<Exercise>();

    public void AddExercise(Exercise exercise)
    {
        Exercises.Add(exercise);
    }

    public double GetTotalCaloriesBurned()
    {
        double totalCalories = 0;
        foreach (var exercise in Exercises)
        {
            totalCalories += exercise.CalculateCaloriesBurned();
        }
        return totalCalories;
    }
}
