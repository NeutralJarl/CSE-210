using System;
using System.Collections.Generic;

public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    private List<Workout> Workouts { get; set; } = new List<Workout>();
    private List<Diet> Diets { get; set; } = new List<Diet>();
    private List<Goal> Goals { get; set; } = new List<Goal>();

    public User() { } // Parameterless constructor for serialization

    public User(string name, int age, double weight, double height) 
    {
        Name = name;
        Age = age;
        Weight = weight;
        Height = height;
    }

    public void AddWorkout(Workout workout)
    {
        Workouts.Add(workout);
    }

    public void AddDiet(Diet diet)
    {
        Diets.Add(diet);
    }

    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    // Getter methods to access private lists
    public List<Workout> GetWorkouts()
    {
        return Workouts;
    }

    public List<Diet> GetDiets()
    {
        return Diets;
    }

    public List<Goal> GetGoals()
    {
        return Goals;
    }
}
