using Microsoft.VisualStudio.TestTools.UnitTesting;
using SplitTheBill;

namespace splitthebill.test
{
    [TestClass]
    public class BillSplitterTests
    {
        [TestMethod]
        public void TestSplitAmount()
        {
            // Arrange
            decimal amount = 10.0m;
            int numberOfPeople = 5;

            // Act
            decimal result = BillSplitter.SplitAmount(amount, numberOfPeople);

            // Assert
            Assert.AreEqual(20.00m, result);
        }

        [TestMethod]
        public void TestSplitAmountWithZeroPeople()
        {
            // Arrange
            decimal amount = 100.00m;
            int numberOfPeople = 0;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => BillSplitter.SplitAmount(amount, numberOfPeople));
        }

        [TestMethod]
        public void TestSplitAmountWithNegativePeople()
        {
            // Arrange
            decimal amount = 100.00m;
            int numberOfPeople = -2;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => BillSplitter.SplitAmount(amount, numberOfPeople));
        }
    }

    [TestClass]
    public class TipCalculatorTests
    {
        [TestMethod]
        public void TestCalculateTipShares()
        {
            // Arrange
            Dictionary<string, decimal> mealCosts = new Dictionary<string, decimal>
            {
                {"Mahek", 20.00m},
                {"Akshar", 30.00m},
                {"Krupa", 25.00m}
            };

            float tipPercentage = 15;

            // Act
            Dictionary<string, decimal> result = TipCalculator.CalculateTipShares(mealCosts, tipPercentage);

            // Assert
            Assert.AreEqual(3.00m, result["Mahek"]);
            Assert.AreEqual(4.50m, result["Akshar"]);
            Assert.AreEqual(3.75m, result["Krupa"]);
        }

        [TestMethod]
        public void TestCalculateTipSharesWithNullMealCosts()
        {
            // Arrange
            Dictionary<string, decimal> mealCosts = null;
            float tipPercentage = 15;

            // Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() => TipCalculator.CalculateTipShares(mealCosts, tipPercentage));
        }

        [TestMethod]
        public void TestCalculateTipSharesWithInvalidTipPercentage()
        {
            // Arrange
            Dictionary<string, decimal> mealCosts = new Dictionary<string, decimal>
            {
                {"Mahek", 20.00m},
                {"Akshar", 30.00m},
                {"Krupa", 25.00m}
            };
            float tipPercentage = -5;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => TipCalculator.CalculateTipShares(mealCosts, tipPercentage));
        }
    }





}
