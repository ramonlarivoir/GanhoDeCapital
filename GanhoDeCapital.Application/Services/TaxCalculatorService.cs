using GanhoDeCapital.Application.Interfaces;
using GanhoDeCapital.Domain.Entities;
using GanhoDeCapital.Domain.Interfaces;
using Newtonsoft.Json;

namespace GanhoDeCapital.Application.Services
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private readonly ITaxCalculator _taxCalculator;

        public TaxCalculatorService(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        public string CalculateTaxes(List<OperationEntity> operations)
        {
            var taxes = new List<TaxOutputEntity>();
            decimal averagePriced = 0;
            int totalQuantity = 0;
            decimal totalLoss = 0;

            foreach (var operation in operations)
            {
                if (operation.Operation == "buy")
                {
                    averagePriced = CalculateAveragePriced(operation, averagePriced, totalQuantity);
                    taxes.Add(new TaxOutputEntity { Tax = 0 });
                    totalQuantity += operation.Quantity;
                }
                else
                {
                    var tax = _taxCalculator.CalculateTax(operation, averagePriced, ref totalLoss);
                    taxes.Add(new TaxOutputEntity { Tax = tax });

                    totalQuantity -= operation.Quantity;

                    totalLoss = totalQuantity == 0 ? 0 : totalLoss;
                }
            }

            return JsonConvert.SerializeObject(taxes);
        }

        private decimal CalculateAveragePriced(OperationEntity operation, decimal averagePriced, int totalQuantity)
        {
            return Math.Round(((totalQuantity * averagePriced) + (operation.Quantity * operation.UnitCost)) / (totalQuantity + operation.Quantity), 2);
        }
    }
}
