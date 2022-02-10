using MarketDataGateway.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketDataGateway.Data
{
    /// <summary>
    /// Market contribution entity matching the database table.
    /// To make it simple, all the data are stored in a flat structure.
    /// </summary>
    public class MarketContributionEntity
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
        /// Gets or sets the instrument identifier.
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

        /// <summary>
        /// Gets or sets the regulation framework.
        /// </summary>
        /// <value>
        /// The regulation framework.
        /// </value>
        public string RegulationFramework { get; set; }
    }
}
