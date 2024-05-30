using GanhoDeCapital.Domain.Entities;

namespace GanhoDeCapital.Application.Interfaces
{
    public interface ITaxCalculatorService
    {
        /// <summary>
        /// Calculates the taxes to be paid on a list of operations.
        /// </summary>
        /// <param name="operations">The list of operations.</param>
        /// <returns>A list with the taxes to be paid for each operation.</returns>
        string CalculateTaxes(List<OperationEntity> operations);
    }
}
