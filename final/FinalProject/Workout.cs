public class Workout
{
    public DateTime Date { get; private set; }
    public TimeSpan Duration { get; private set; }
    public string Type { get; private set; }
    public List<Exercise> Exercises { get; private set; } = new List<Exercise>();

    public Workout(DateTime date, TimeSpan duration, string type)
    {
        Date = date;
        Duration = duration;
        Type = type;
    }

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
