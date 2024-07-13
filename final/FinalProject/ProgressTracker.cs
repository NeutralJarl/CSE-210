public class ProgressTracker
{
    public void TrackWorkoutProgress(User user)
    {
        foreach (var workout in user.Workouts)
        {
            // Logic to track workout progress
            // For example, update goals based on workouts
            foreach (var goal in user.Goals)
            {
                if (goal.Type == "Weight Loss")
                {
                    goal.UpdateProgress(user.Weight - workout.GetTotalCaloriesBurned() / 7700); // Roughly 7700 calories per kg
                }
            }
        }
    }

    public void TrackDietProgress(User user)
    {
        foreach (var diet in user.Diets)
        {
            // Logic to track diet progress
            // For example, update goals based on diet
            foreach (var goal in user.Goals)
            {
                if (goal.Type == "Weight Loss")
                {
                    goal.UpdateProgress(user.Weight - diet.GetTotalCalories() / 7700); // Roughly 7700 calories per kg
                }
            }
        }
    }
}
