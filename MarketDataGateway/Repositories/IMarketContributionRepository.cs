using MarketDataGateway.Data;
using MarketDataGateway.Models;

namespace MarketDataGateway.Services
{
    /// <summary>
    /// Market Contribution repository
    /// </summary>
    public interface IMarketContributionRepository
    {
        /// <summary>
        /// Adds the contribution.
        /// </summary>
        /// <param name="marketContribution">The market contribution.</param>
        void AddContribution(MarketContribution marketContribution);

        /// <summary>
        /// Gets the user contributions.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The contributions added by the user.</returns>
        IEnumerable<MarketContribution> GetUserContributions(string userId);
    }
}
