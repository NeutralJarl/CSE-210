public class Goal
{
    public string Type { get; set; }
    public double Target { get; set; }
    public double CurrentProgress { get; set; }

    public void UpdateProgress(double progress)
    {
        CurrentProgress = progress;
    }

    public bool IsGoalAchieved()
    {
        return CurrentProgress <= Target;
    }
}
