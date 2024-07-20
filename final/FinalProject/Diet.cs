using System;
using System.Collections.Generic;

public class Diet
{
    public DateTime Date { get; set; }
    public List<Meal> Meals { get; set; } = new List<Meal>();

    public void AddMeal(Meal meal)
    {
        Meals.Add(meal);
    }

    public double GetTotalCalories()
    {
        double totalCalories = 0;
        foreach (var meal in Meals)
        {
            totalCalories += meal.Calories;
        }
        return totalCalories;
    }
}