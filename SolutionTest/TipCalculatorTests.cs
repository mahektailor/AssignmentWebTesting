using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class TipCalculatorTests
{
    [TestMethod]
    public void CalculateTip_EqualMealCostsAndTipPercentage_ReturnsEqualTip()
    {
        // Arrange
        var calculator = new TipCalculator();
        var mealCosts = new Dictionary<string, decimal>
        {
            { "Alice", 50.00M },
            { "Bob", 50.00M },
            { "Charlie", 50.00M }
        };
        float tipPercentage = 10.0f;

        // Act
        var tipPerPerson = calculator.CalculateTip(mealCosts, tipPercentage);

        // Assert
        foreach (var tip in tipPerPerson.Values)
        {
            Assert.AreEqual(5.00M, tip);
        }
    }

    [TestMethod]
    public void CalculateTip_NullMealCosts_ThrowsArgumentNullException()
    {
        // Arrange
        var calculator = new TipCalculator();
        Dictionary<string, decimal> mealCosts = null;
        float tipPercentage = 15.0f;

        // Act and Assert
        Assert.ThrowsException<ArgumentNullException>(() => calculator.CalculateTip(mealCosts, tipPercentage));
    }

    [TestMethod]
    public void CalculateTip_NegativeTipPercentage_ThrowsArgumentException()
    {
        // Arrange
        var calculator = new TipCalculator();
        var mealCosts = new Dictionary<string, decimal>
        {
            { "Mahek", 60.00M }
        };
        float tipPercentage = -5.0f;

        // Act and Assert
        Assert.ThrowsException<ArgumentException>(() => calculator.CalculateTip(mealCosts, tipPercentage));
    }
}
