using System;

public class CardioExercise : Exercise
{
    public double Distance { get; set; }  // Distance in kilometers
    public double Speed { get; set; }  // Speed in kilometers per hour

    public override double CalculateCaloriesBurned()
    {
        double MET = 10.0;  // MET value for running; adjust based on actual exercise
        double durationHours = Duration.TotalHours;
        double weightInKg = 70;  // Replace with actual user weight or input
        
        return durationHours * MET * weightInKg;
    }
}
