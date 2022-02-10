namespace MarketDataGateway.Models
{
    /// <summary>
    /// The FX quote market data
    /// </summary>
    /// <seealso cref="MarketDataGateway.Models.MarketData" />
    public class FxQuote : MarketData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FxQuote"/> class.
        /// </summary>
        /// <param name="instrumentId">The instrument identifier</param>
        /// <param name="price">The price.</param>
        /// <param name="size">The size.</param>
        /// <param name="side">The side.</param>
        public FxQuote(string instrumentId, double price, double size, MarketDataSide side) : base(instrumentId, price, size, side)
        {
            InstrumentId = instrumentId;
        }

        /// <summary>
        /// Gets or sets the target FX Quote identifier as a currency pair.
        /// There is a check on currency pairs. The allowed values can be stored somewhere else.
        /// </summary>
        /// <value>
        /// The instrument identifier.
        /// </value>
        [StringRange(AllowableValues = new[] { "EUR/USD", "JPY/USD" })]
        public new string InstrumentId { get; set; }
    }
}
