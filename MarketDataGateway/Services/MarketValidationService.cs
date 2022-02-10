using MarketDataGateway.Models;

namespace MarketDataGateway.Services
{
    /// <summary>
    /// Market Contribution Validation service
    /// </summary>
    /// <seealso cref="MarketDataGateway.Services.IMarketValidationService" />
    public class MarketValidationService : IMarketValidationService
    {
        /// <summary>
        /// Validates the contribution.
        /// </summary>
        /// <param name="marketContribution">The market contribution.</param>
        /// <returns>
        /// A valid response if the contribution is vzlid.
        /// </returns>
        public ValidationResponse ValidateContribution(MarketContribution marketContribution)
        {
            // check data, call webservices...
            return new ValidationResponse { Id = "ID1", Status = ValidationResponse.ValidationResponseStatus.SUCCESS };
        }
    }
}
