using System;

namespace SplitTheBill
{
    public class BillSplitter
    {
        public static decimal SplitAmount(decimal amount, int numberOfPeople)
        {
            if (numberOfPeople <= 0)
            {
                throw new ArgumentException("Number of people must be greater than 0.");
            }

            return decimal.Round(amount / numberOfPeople, 2);
        }
    }

    public class TipCalculator
    {
        public static Dictionary<string, decimal> CalculateTipShares(Dictionary<string, decimal>? mealCosts, float tipPercentage)
        {
            if (mealCosts == null)
            {
                throw new ArgumentNullException(nameof(mealCosts), "Meal costs dictionary cannot be null.");
            }

            if (tipPercentage < 0 || tipPercentage > 100)
            {
                throw new ArgumentException("Tip percentage must be between 0 and 100.", nameof(tipPercentage));
            }

            Dictionary<string, decimal> tipShares = new Dictionary<string, decimal>();

            decimal totalMealCost = 0;

            foreach (var kvp in mealCosts!)
            {
                totalMealCost += kvp.Value;
            }

            foreach (var kvp in mealCosts!)
            {
                decimal individualTipShare = kvp.Value / totalMealCost * (decimal)tipPercentage / 100;
                tipShares.Add(kvp.Key, individualTipShare);
            }

            return tipShares;
        }
    }

    public class SplitTheBillCalculator
    {
        public static decimal CalculateTipPerPerson(decimal price, int numberOfPatrons, float tipPercentage)
        {
            if (numberOfPatrons <= 0)
            {
                throw new ArgumentException("Number of patrons must be greater than 0.", nameof(numberOfPatrons));
            }

            if (tipPercentage < 0 || tipPercentage > 100)
            {
                throw new ArgumentException("Tip percentage must be between 0 and 100.", nameof(tipPercentage));
            }

            decimal totalTip = price * (decimal)tipPercentage / 100;
            decimal tipPerPerson = totalTip / numberOfPatrons;

            return tipPerPerson;
        }
    }
    public class ExpenseManager
    {
        public static decimal CalculateTipPerPerson(decimal price, int numberOfPatrons, float tipPercentage)
        {
            if (numberOfPatrons <= 0)
            {
                throw new ArgumentException("Number of patrons must be greater than 0.", nameof(numberOfPatrons));
            }

            if (tipPercentage < 0 || tipPercentage > 100)
            {
                throw new ArgumentException("Tip percentage must be between 0 and 100.", nameof(tipPercentage));
            }

            decimal totalTip = price * (decimal)tipPercentage / 100;
            decimal tipPerPerson = totalTip / numberOfPatrons;

            return tipPerPerson;
        }
    }

}