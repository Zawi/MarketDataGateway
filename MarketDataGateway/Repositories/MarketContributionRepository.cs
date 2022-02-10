using MarketDataGateway.Data;
using MarketDataGateway.Models;

namespace MarketDataGateway.Services
{
    public class MarketContributionRepository : IMarketContributionRepository
    {
        private readonly ApplicationDbContext _context;

        public MarketContributionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddContribution(MarketContribution marketContribution)
        {
            _context.MarketContributions.Add(new MarketContributionEntity
            {
                Date = marketContribution.Date,
                Id = marketContribution.Id,
                MarketDataType = marketContribution.MarketDataType,
                RegulationFramework = marketContribution.RegulationFramework,
                UserId = marketContribution.UserId,
                Price = marketContribution.MarketData.Price,
                Side = marketContribution.MarketData.Side,
                Size = marketContribution.MarketData.Size,
                InstrumentId = marketContribution.MarketData.InstrumentId
            });
            _context.SaveChanges();
        }

        public IEnumerable<MarketContribution> GetUserContributions(string userId)
        {
            return _context.MarketContributions.Where(x => x.UserId == userId).Select(contrib => new MarketContribution
            {
                Id = contrib.Id,
                UserId = contrib.UserId,
                MarketDataType = contrib.MarketDataType,
                Date = contrib.Date,
                RegulationFramework = contrib.RegulationFramework,
                MarketData = new MarketData(contrib.InstrumentId, contrib.Price, contrib.Size, contrib.Side)
            });
        }
    }
}