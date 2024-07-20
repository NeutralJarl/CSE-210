public class Meal
{
    public string Name { get; private set; }
    public double Calories { get; private set; }

    public Meal(string name, double calories)
    {
        Name = name;
        Calories = calories;
    }
}
