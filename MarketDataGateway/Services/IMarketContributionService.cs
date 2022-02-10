using MarketDataGateway.Models;

namespace MarketDataGateway.Services
{

    /// <summary>
    /// Service to manage market data contributions
    /// </summary>
    public interface IMarketContributionService
    {
        /// <summary>
        /// Adds the contribution.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="marketDataType">Type of the market data.</param>
        /// <param name="marketDataQuote">The market data quote.</param>
        /// <returns>Returns true if the contribution was added, false otherwise</returns>
        public bool AddContribution(string userId, string marketDataType, MarketData marketDataQuote);

        /// <summary>
        /// Gets the user contributions.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Returns the list of contributions created by the user</returns>
        public IList<MarketContribution> GetUserContributions(string userId);
    }
}
