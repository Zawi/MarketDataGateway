using MarketDataGateway.Models;

namespace MarketDataGateway.Services
{
    /// <summary>
    /// Market Validation Service
    /// </summary>
    public interface IMarketValidationService
    {
        /// <summary>
        /// Validates the contribution.
        /// </summary>
        /// <param name="marketContribution">The market contribution.</param>
        /// <returns>
        /// A valid response if the contribution is valid.
        /// </returns>
        public ValidationResponse ValidateContribution(MarketContribution marketContribution);
    }
}
