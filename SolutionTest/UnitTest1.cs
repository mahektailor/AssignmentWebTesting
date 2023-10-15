using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution;



[TestClass]
public class SplitCalculatorTests
{
    [TestMethod]
    public void SplitAmount_EqualAmountAndPeople_ReturnsOriginalAmount()
    {
        // Arrange
        SplitCalculator calculator = new SplitCalculator();
        decimal totalAmount = 100.00M;
        int numberOfPeople = 10;

        // Act
        decimal result = calculator.SplitAmount(totalAmount, numberOfPeople);

        // Assert
        Assert.AreEqual(10.00M, result);
    }

    [TestMethod]
    public void SplitAmount_ZeroAmount_ThrowsException()
    {
        // Arrange
        SplitCalculator calculator = new SplitCalculator();
        decimal totalAmount = 0;
        int numberOfPeople = 5;

        // Act and Assert
        Assert.ThrowsException<ArgumentException>(() => calculator.SplitAmount(totalAmount, numberOfPeople));
    }

    [TestMethod]
    public void SplitAmount_NegativePeople_ThrowsException()
    {
        // Arrange
        SplitCalculator calculator = new SplitCalculator();
        decimal totalAmount = 50.00M;
        int numberOfPeople = -2;

        // Act and Assert
        Assert.ThrowsException<ArgumentException>(() => calculator.SplitAmount(totalAmount, numberOfPeople));
    }
}