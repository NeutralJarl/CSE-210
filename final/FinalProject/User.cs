using System;
using System.Collections.Generic;

public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public List<Workout> Workouts { get; set; } = new List<Workout>();
    public List<Diet> Diets { get; set; } = new List<Diet>();
    public List<Goal> Goals { get; set; } = new List<Goal>();

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
}
