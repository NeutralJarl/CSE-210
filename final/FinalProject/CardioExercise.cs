using System;

public class CardioExercise : Exercise
{
    public double Distance { get; set; }
    public double Speed { get; set; }

    public override double CalculateCaloriesBurned()
    {
        // Example calculation (this is just an illustrative formula)
        return Duration.TotalHours * Speed * 0.5;
    }
}
