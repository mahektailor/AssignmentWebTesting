using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TipCalculator
{
    public Dictionary<string, decimal> CalculateTip(Dictionary<string, decimal> mealCosts, float tipPercentage)
    {
        if (mealCosts == null)
            throw new ArgumentNullException("mealCosts");

        if (tipPercentage < 0)
            throw new ArgumentException("Tip percentage cannot be negative.");

        if (mealCosts.Count == 0)
            return new Dictionary<string, decimal>();

        var totalCost = 0m;

        foreach (var cost in mealCosts.Values)
        {
            totalCost += cost;
        }

        var tipAmount = (decimal)tipPercentage / 100 * totalCost;

        var tipPerPerson = new Dictionary<string, decimal>();

        foreach (var entry in mealCosts)
        {
            tipPerPerson[entry.Key] = (entry.Value / totalCost) * tipAmount;
        }

        return tipPerPerson;
    }
}
