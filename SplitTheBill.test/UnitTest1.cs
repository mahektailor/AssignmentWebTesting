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
}
