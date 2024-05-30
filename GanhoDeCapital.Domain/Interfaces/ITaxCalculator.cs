using GanhoDeCapital.Domain.Entities;

namespace GanhoDeCapital.Domain.Interfaces
{
    public interface ITaxCalculator
    {
        /// <summary>
        /// Calculates the tax to be paid on an operation.
        /// </summary>
        /// <param name="operation">The operation to be calculated.</param>
        /// <param name="averagePriced">The weighted average price of the shares.</param>
        /// <param name="totalLoss">The total loss.</param>
        /// <returns>The amount of tax to be paid.</returns>
        decimal CalculateTax(OperationEntity operation, decimal averagePriced, ref decimal totalLoss);
    }
}
