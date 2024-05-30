using GanhoDeCapital.Domain.Entities;
using GanhoDeCapital.Domain.Interfaces;

namespace GanhoDeCapital.Domain.Rules
{
    public class TaxCalculator : ITaxCalculator
    {
        /// <inheritdoc/>
        public decimal CalculateTax(OperationEntity operation, decimal averagePriced, ref decimal totalLoss)
        {
            if (operation.Operation == "buy")
                return 0;

            var isUnitCostLessThanAveragePriced = operation.UnitCost < averagePriced;

            var totalCost = operation.UnitCost * operation.Quantity;

            var initialTotalCost = totalCost;

            decimal profit = isUnitCostLessThanAveragePriced ? totalCost - (averagePriced * operation.Quantity) : totalCost - (averagePriced * operation.Quantity);

            if (isUnitCostLessThanAveragePriced)
            {
                totalLoss += profit;
                return 0;
            }

            if (initialTotalCost < 20000)
                return 0;

            totalCost += Math.Abs(totalLoss) == profit ? totalLoss : totalLoss + profit;

            totalLoss += profit;

            if (totalCost <= 20000)
                return 0;

            if (totalLoss > 0)
            {
                profit = totalLoss;
                totalLoss = 0;
            }

            return Math.Round(profit * 0.20m, 2);
        }
    }
}
