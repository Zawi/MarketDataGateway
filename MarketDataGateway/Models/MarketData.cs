using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MarketDataGateway.Models
{
    /// <summary>
    /// Market Data Quote
    /// </summary>
    public class MarketData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarketData"/> class.
        /// </summary>
        /// <param name="instrumentId">The instrument identifier.</param>
        /// <param name="price">The price.</param>
        /// <param name="size">The size.</param>
        /// <param name="side">The side.</param>
        public MarketData(string instrumentId, double price, double size, MarketDataSide side)
        {
            InstrumentId = instrumentId;
            Price = price;
            Size = size;
            Side = side;
        }

        /// <summary>
        /// Gets or sets the target instrument identifier.
        /// </summary>
        /// <value>
        /// The instrument identifier.
        /// </value>
        [Required]
        public string InstrumentId { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        [Required]
        public double Price { get; init; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        [Required]
        public double Size { get; init; }

        /// <summary>
        /// Gets or sets the side.
        /// </summary>
        /// <value>
        /// The side.
        /// </value>
        [Required]
        public MarketDataSide Side { get; set; }

    }
}
