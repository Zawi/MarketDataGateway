using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MarketDataGateway.Models
{
    /// <summary>
    /// Enumeration of Market data side as Bid or Ask
    /// </summary>
    public enum MarketDataSide
    {
        /// <summary>
        /// The ask side
        /// </summary>
        Ask,
        /// <summary>
        /// The bid side
        /// </summary>
        Bid
    }
}
