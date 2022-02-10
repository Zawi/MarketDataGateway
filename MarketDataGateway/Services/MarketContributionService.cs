using MarketDataGateway.Models;

namespace MarketDataGateway.Services
{
    /// <summary>
    /// Market Contribution service
    /// </summary>
    /// <seealso cref="MarketDataGateway.Services.IMarketContributionService" />
    public class MarketContributionService : IMarketContributionService
    {
        /// <summary>
        /// The market validation service
        /// </summary>
        private readonly IMarketValidationService _marketValidationService;

        /// <summary>
        /// The market contribution repository
        /// </summary>
        private readonly IMarketContributionRepository _marketContributionRepository;

        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarketContributionService"/> class.
        /// </summary>
        /// <param name="marketValidationService">The market validation service.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="marketContributionRepository">The market contribution repository.</param>
        public MarketContributionService(
            IMarketValidationService marketValidationService, 
            IConfiguration configuration, 
            IMarketContributionRepository marketContributionRepository)
        {
            _marketValidationService = marketValidationService;
            _configuration = configuration;
            _marketContributionRepository = marketContributionRepository;
        }

        /// <summary>
        /// Adds the contribution.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="marketDataType">Type of the market data.</param>
        /// <param name="marketDataQuote">The market data quote.</param>
        /// <returns>
        /// Returns true if the contribution was added, false otherwise
        /// </returns>
        public bool AddContribution(string userId, string marketDataType, MarketData marketDataQuote)
        {
            var contrib = new MarketContribution
            {
                Date = DateTime.Now,
                UserId = userId,
                MarketDataType = marketDataType,
                MarketData = marketDataQuote,
                RegulationFramework = _configuration[$"RegulatoryFrameworks:{marketDataType}"]
            };

            var validated = _marketValidationService.ValidateContribution(contrib).Status == ValidationResponse.ValidationResponseStatus.SUCCESS;
            
            if (validated)
                _marketContributionRepository.AddContribution(contrib);

            return validated;
        }

        /// <summary>
        /// Gets the user contributions.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// Returns the list of contributions created by the user
        /// </returns>
        public IList<MarketContribution> GetUserContributions(string userId)
        {
            return _marketContributionRepository.GetUserContributions(userId).ToList();
        }
    }
}
