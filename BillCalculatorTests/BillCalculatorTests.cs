using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillCalculatorLibrary;

namespace BillCalculatorTests
{
    [TestClass]
    public class BillCalculatorTests
    {
        [TestMethod]
        public void SplitAmount_ShouldReturnCorrectSplitAmount_WhenValidInput()
        {
            // Arrange
            BillCalculator billCalculator = new BillCalculator();

            // Act
            decimal totalAmount = 100;
            int numberOfPeople = 5;
            decimal splitAmount = billCalculator.SplitAmount(totalAmount, numberOfPeople);

            // Assert
            Assert.AreEqual(20, splitAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SplitAmount_ShouldThrowException_WhenNumberOfPeopleIsZero()
        {
            // Arrange
            BillCalculator billCalculator = new BillCalculator();

            // Act
            decimal totalAmount = 100;
            int numberOfPeople = 0;
            decimal splitAmount = billCalculator.SplitAmount(totalAmount, numberOfPeople);

            // Assert - Expects an exception to be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SplitAmount_ShouldThrowException_WhenNumberOfPeopleIsNegative()
        {
            // Arrange
            BillCalculator billCalculator = new BillCalculator();

            // Act
            decimal totalAmount = 100;
            int numberOfPeople = -5;
            decimal splitAmount = billCalculator.SplitAmount(totalAmount, numberOfPeople);

            // Assert - Expects an exception to be thrown
        }
    }
}
