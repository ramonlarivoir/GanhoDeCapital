using GanhoDeCapital.Domain.Entities;
using GanhoDeCapital.Domain.Rules;

namespace GanhoDeCapital.Domain.Tests
{
    public class TaxCalculatorTests
    {
        [Fact]
        public void CalculateTax_BuyOperation_ReturnsZero()
        {
            // Arrange
            var operation = new OperationEntity { Operation = "buy", UnitCost = 20.00m, Quantity = 5000 };
            var averagePriced = 15.00m;
            decimal totalLoss = 0;

            // Act
            var tax = new TaxCalculator().CalculateTax(operation, averagePriced, ref totalLoss);

            // Assert
            Assert.Equal(0, tax);
        }

        [Fact]
        public void CalculateTax_SellOperationWithTotalLessThan20000_ReturnsZero()
        {
            // Arrange
            var operation = new OperationEntity { Operation = "sell", UnitCost = 2.00m, Quantity = 5000 };
            var averagePriced = 10.00m;
            decimal totalLoss = 0;

            // Act
            var tax = new TaxCalculator().CalculateTax(operation, averagePriced, ref totalLoss);

            // Assert
            Assert.Equal(0, tax);
        }

        [Fact]
        public void CalculateTax_SellOperationWithProfit_ReturnsCorrectTax()
        {
            // Arrange
            var operation = new OperationEntity { Operation = "sell", UnitCost = 20.00m, Quantity = 5000 };
            var averagePriced = 15.00m;
            decimal totalLoss = 0;

            // Act
            var tax = new TaxCalculator().CalculateTax(operation, averagePriced, ref totalLoss);

            // Assert
            Assert.Equal(5000.00m, tax);
        }

        [Fact]
        public void CalculateTax_SellOperationWithLoss_ReturnsZero()
        {
            // Arrange
            var operation = new OperationEntity { Operation = "sell", UnitCost = 5.00m, Quantity = 5000 };
            var averagePriced = 10.00m;
            decimal totalLoss = 0;

            // Act
            var tax = new TaxCalculator().CalculateTax(operation, averagePriced, ref totalLoss);

            // Assert
            Assert.Equal(0, tax);
        }
    }
}