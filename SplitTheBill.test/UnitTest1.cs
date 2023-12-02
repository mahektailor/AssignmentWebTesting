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
            decimal amount = 100.0m;
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


    [TestClass]
    public class ExpenseManagerTests
    {
        [TestMethod]
        public void TestCalculateTipPerPerson()
        {
            // Arrange
            decimal price = 100.00m;
            int numberOfPatrons = 5;
            float tipPercentage = 15;

            // Act
            decimal result = ExpenseManager.CalculateTipPerPerson(price, numberOfPatrons, tipPercentage);

            // Assert
            Assert.AreEqual(3.00m, result);
        }

        [TestMethod]
        public void TestCalculateTipPerPersonWithZeroPatrons()
        {
            // Arrange
            decimal price = 100.00m;
            int numberOfPatrons = 0;
            float tipPercentage = 15;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => ExpenseManager.CalculateTipPerPerson(price, numberOfPatrons, tipPercentage));
        }

        [TestMethod]
        public void TestCalculateTipPerPersonWithInvalidTipPercentage()
        {
            // Arrange
            decimal price = 100.00m;
            int numberOfPatrons = 5;
            float tipPercentage = -5;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => ExpenseManager.CalculateTipPerPerson(price, numberOfPatrons, tipPercentage));
        }
    }


}
