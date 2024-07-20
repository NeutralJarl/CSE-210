using System;

public class StrengthExercise : Exercise
{
    public int Reps { get; set; }
    public int Sets { get; set; }
    public double Weight { get; set; } // Weight lifted in kilograms

    public override double CalculateCaloriesBurned()
    {
        double MET = 6.0;  // MET value for strength training
        double durationHours = Duration.TotalHours;
        double weightInKg = 70;  // Replace with actual user weight or input
        
        return durationHours * MET * weightInKg;
    }
}
