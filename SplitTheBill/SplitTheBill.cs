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
}
