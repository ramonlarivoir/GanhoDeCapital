using GanhoDeCapital.Application.Services;
using GanhoDeCapital.Domain.Entities;
using GanhoDeCapital.Domain.Rules;
using Newtonsoft.Json;

namespace GanhoDeCapital.Application.Tests
{
    public class TaxCalculatorServiceTests
    {
        [Fact]
        public void CalculateTaxes_ReturnsCorrectTaxes()
        {
            // Arrange
            var operations = new List<OperationEntity>
            {
                new OperationEntity { Operation = "buy", UnitCost = 10.00m, Quantity = 10000 },
                new OperationEntity { Operation = "sell", UnitCost = 20.00m, Quantity = 5000 },
                new OperationEntity { Operation = "sell", UnitCost = 5.00m, Quantity = 5000 }
            };

            // Act
            var taxes = JsonConvert.DeserializeObject<List<TaxOutputEntity>>(new TaxCalculatorService(new TaxCalculator()).CalculateTaxes(operations));

            // Assert
            Assert.Equal(10000.00m, taxes[1].Tax);
            Assert.Equal(0, taxes[2].Tax);
        }

        [Fact]
        public void CalculateTaxes_HandlesMultipleBuyAndSellOperations()
        {
            // Arrange
            var operations = new List<OperationEntity>
            {
                new OperationEntity { Operation = "buy", UnitCost = 10.00m, Quantity = 10000 },
                new OperationEntity { Operation = "sell", UnitCost = 20.00m, Quantity = 5000 },
                new OperationEntity { Operation = "buy", UnitCost = 15.00m, Quantity = 5000 },
                new OperationEntity { Operation = "sell", UnitCost = 25.00m, Quantity = 10000 }
            };

            // Act
            var taxes = JsonConvert.DeserializeObject<List<TaxOutputEntity>>(new TaxCalculatorService(new TaxCalculator()).CalculateTaxes(operations));

            // Assert
            Assert.Equal(25000.00m, taxes[3].Tax);
        }

        [Fact]
        public void CalculateTaxes_HandlesLossesAndProfits()
        {
            // Arrange
            var operations = new List<OperationEntity>
            {
                new OperationEntity { Operation = "buy", UnitCost = 10.00m, Quantity = 10000 },
                new OperationEntity { Operation = "sell", UnitCost = 20.00m, Quantity = 5000 },
                new OperationEntity { Operation = "sell", UnitCost = 5.00m, Quantity = 5000 }
            };

            // Act
            var taxes = JsonConvert.DeserializeObject<List<TaxOutputEntity>>(new TaxCalculatorService(new TaxCalculator()).CalculateTaxes(operations));

            // Assert
            Assert.Equal(10000.00m, taxes[1].Tax);
            Assert.Equal(0, taxes[2].Tax);
        }
    }
}