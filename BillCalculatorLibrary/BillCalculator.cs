namespace BillCalculatorLibrary
{
    public class BillCalculator
    {
        public decimal SplitAmount(decimal totalAmount, int numberOfPeople)
        {
            if (numberOfPeople <= 0)
            {
                throw new ArgumentException("Number of people must be greater than zero.");
            }

            decimal splitAmount = totalAmount / numberOfPeople;
            return splitAmount;
        }
    }
}
