using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketDataGateway.Models
{
    /// <summary>
    /// Market data contribution
    /// </summary>
    public class MarketContribution
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the type of the market data.
        /// </summary>
        /// <value>
        /// The type of the market data.
        /// </value>
        public string MarketDataType { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the market data quote.
        /// </summary>
        /// <value>
        /// The market data quote.
        /// </value>
        public MarketData MarketData { get; set; }

        /// <summary>
        /// Gets or sets the regulation framework.
        /// </summary>
        /// <value>
        /// The regulation framework.
        /// </value>
        public string RegulationFramework { get; set; }
    }
}
