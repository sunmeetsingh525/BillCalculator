using System;
using System.Collections.Generic;

namespace BillCalculatorLibrary
{
    public class BillCalculator
    {
        // Method for splitting total amount among people
        public decimal SplitAmount(decimal totalAmount, int numberOfPeople)
        {
            if (numberOfPeople <= 0)
            {
                throw new ArgumentException("Number of people must be greater than zero.");
            }

            decimal splitAmount = totalAmount / numberOfPeople;
            return splitAmount;
        }

        // Method for calculating tip amounts based on meal costs and tip percentage
        public Dictionary<string, decimal> CalculateTip(Dictionary<string, decimal> mealCosts, float tipPercentage)
        {
            if (mealCosts == null)
            {
                throw new ArgumentNullException(nameof(mealCosts), "Meal costs dictionary cannot be null.");
            }

            if (tipPercentage < 0 || tipPercentage > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(tipPercentage), "Tip percentage must be between 0 and 100.");
            }

            Dictionary<string, decimal> tipAmounts = new Dictionary<string, decimal>();

            foreach (var entry in mealCosts)
            {
                decimal tip = entry.Value * (decimal)(tipPercentage / 100);
                tipAmounts.Add(entry.Key, tip);
            }

            return tipAmounts;
        }

        // Method for calculating tip per person based on total price, number of patrons, and tip percentage
        public decimal CalculateTipPerPerson(decimal totalPrice, int numberOfPatrons, float tipPercentage)
        {
            if (totalPrice <= 0)
            {
                throw new ArgumentException("Total price must be greater than zero.");
            }

            if (numberOfPatrons <= 0)
            {
                throw new ArgumentException("Number of patrons must be greater than zero.");
            }

            if (tipPercentage < 0 || tipPercentage > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(tipPercentage), "Tip percentage must be between 0 and 100.");
            }

            decimal totalTip = totalPrice * (decimal)(tipPercentage / 100);
            decimal tipPerPerson = totalTip / numberOfPatrons;
            return tipPerPerson;
        }
    }
}
