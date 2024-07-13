using System;

public class StrengthExercise : Exercise
{
    public int Reps { get; set; }
    public int Sets { get; set; }
    public double Weight { get; set; }

    public override double CalculateCaloriesBurned()
    {
        // Example calculation (this is just an illustrative formula)
        return Reps * Sets * Weight * 0.1;
    }
}
