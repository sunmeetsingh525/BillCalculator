using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillCalculatorLibrary;
using System;
using System.Collections.Generic;

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

        [TestMethod]
        public void CalculateTip_ShouldReturnCorrectTipAmounts_WhenValidInput()
        {
            // Arrange
            BillCalculator billCalculator = new BillCalculator();
            Dictionary<string, decimal> mealCosts = new Dictionary<string, decimal>
            {
                {"Person1", 50.00m},
                {"Person2", 30.00m},
                {"Person3", 20.00m}
            };
            float tipPercentage = 15;

            // Act
            Dictionary<string, decimal> tipAmounts = billCalculator.CalculateTip(mealCosts, tipPercentage);

            // Assert
            Assert.AreEqual(7.50m, tipAmounts["Person1"]);
            Assert.AreEqual(4.50m, tipAmounts["Person2"]);
            Assert.AreEqual(3.00m, tipAmounts["Person3"]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CalculateTip_ShouldThrowException_WhenMealCostsIsNull()
        {
            // Arrange
            BillCalculator billCalculator = new BillCalculator();
            Dictionary<string, decimal> mealCosts = null;
            float tipPercentage = 15;

            // Act
            Dictionary<string, decimal> tipAmounts = billCalculator.CalculateTip(mealCosts, tipPercentage);

            // Assert - Expects an exception to be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculateTip_ShouldThrowException_WhenTipPercentageIsNegative()
        {
            // Arrange
            BillCalculator billCalculator = new BillCalculator();
            Dictionary<string, decimal> mealCosts = new Dictionary<string, decimal>
            {
                {"Person1", 50.00m}
            };
            float tipPercentage = -5;

            // Act
            Dictionary<string, decimal> tipAmounts = billCalculator.CalculateTip(mealCosts, tipPercentage);

            // Assert - Expects an exception to be thrown
        }

        [TestMethod]
        public void CalculateTipPerPerson_ShouldReturnCorrectTipPerPerson_WhenValidInput()
        {
            // Arrange
            BillCalculator billCalculator = new BillCalculator();
            decimal totalPrice = 100;
            int numberOfPatrons = 5;
            float tipPercentage = 15;

            // Act
            decimal tipPerPerson = billCalculator.CalculateTipPerPerson(totalPrice, numberOfPatrons, tipPercentage);

            // Assert
            Assert.AreEqual(3, tipPerPerson);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateTipPerPerson_ShouldThrowException_WhenTotalPriceIsZero()
        {
            // Arrange
            BillCalculator billCalculator = new BillCalculator();
            decimal totalPrice = 0;
            int numberOfPatrons = 5;
            float tipPercentage = 15;

            // Act
            decimal tipPerPerson = billCalculator.CalculateTipPerPerson(totalPrice, numberOfPatrons, tipPercentage);

            // Assert - Expects an exception to be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateTipPerPerson_ShouldThrowException_WhenNumberOfPatronsIsZero()
        {
            // Arrange
            BillCalculator billCalculator = new BillCalculator();
            decimal totalPrice = 100;
            int numberOfPatrons = 0;
            float tipPercentage = 15;

            // Act
            decimal tipPerPerson = billCalculator.CalculateTipPerPerson(totalPrice, numberOfPatrons, tipPercentage);

            // Assert - Expects an exception to be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculateTipPerPerson_ShouldThrowException_WhenTipPercentageIsNegative()
        {
            // Arrange
            BillCalculator billCalculator = new BillCalculator();
            decimal totalPrice = 100;
            int numberOfPatrons = 5;
            float tipPercentage = -5;

            // Act
            decimal tipPerPerson = billCalculator.CalculateTipPerPerson(totalPrice, numberOfPatrons, tipPercentage);

            // Assert - Expects an exception to be thrown
        }
    }
}
