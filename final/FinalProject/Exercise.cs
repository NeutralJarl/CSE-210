using System;

public abstract class Exercise
{
    public string Name { get; set; }
    public TimeSpan Duration { get; set; }
    public double CaloriesBurned { get; set; }

    public abstract double CalculateCaloriesBurned();
}
