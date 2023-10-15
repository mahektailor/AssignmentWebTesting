using System;

namespace Solution;

public class SplitCalculator
{
    public decimal SplitAmount(decimal totalAmount, int numberOfPeople)
    {
        if (numberOfPeople <= 0)
            throw new ArgumentException("Number of people must be greater than zero.");

        if (totalAmount < 0)
            throw new ArgumentException("Total amount cannot be negative.");

        return totalAmount / numberOfPeople;
    }
}
