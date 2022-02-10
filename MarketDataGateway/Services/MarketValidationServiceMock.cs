using MarketDataGateway.Models;

namespace MarketDataGateway.Services
{
    /// <summary>
    /// Market Contribution Validation service Mock
    /// </summary>
    /// <seealso cref="MarketDataGateway.Services.IMarketValidationService" />
    public class MarketValidationServiceMock : IMarketValidationService
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
            var status = marketContribution.MarketData.Price > 0 ? ValidationResponse.ValidationResponseStatus.SUCCESS : ValidationResponse.ValidationResponseStatus.ERROR;
            return new ValidationResponse { Id = "ID1", Status = status };
        }
    }
}
