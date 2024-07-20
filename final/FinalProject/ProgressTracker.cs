public class ProgressTracker
{
    public void UpdateGoalsBasedOnWorkouts(User user)
    {
        double totalCaloriesBurned = 0;

        foreach (var workout in user.GetWorkouts())
        {
            totalCaloriesBurned += workout.GetTotalCaloriesBurned();
        }

        foreach (var goal in user.GetGoals())
        {
            if (goal.Type == "Calorie Burn")
            {
                goal.Progress = totalCaloriesBurned;
            }
        }
    }

    public void UpdateGoalsBasedOnDiets(User user)
    {
        double totalCaloriesIntake = 0;

        foreach (var diet in user.GetDiets())
        {
            totalCaloriesIntake += diet.GetTotalCalories();
        }

        foreach (var goal in user.GetGoals())
        {
            if (goal.Type == "Calorie Burn")
            {
                double caloriesLeftToBurn = totalCaloriesIntake - goal.Progress;
                goal.Target = caloriesLeftToBurn;
            }
        }
    }
}
