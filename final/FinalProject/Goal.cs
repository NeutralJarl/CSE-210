public class Goal
{
    public string Type { get; set; }
    public double Target { get; set; }  // Target here will be the total calories to burn
    public double Progress { get; set; }  // Progress here will be the total calories burned

    public Goal(string type, double target)
    {
        Type = type;
        Target = target;
        Progress = 0;
    }

    public bool IsGoalAchieved()
    {
        return Progress >= Target;
    }
}
