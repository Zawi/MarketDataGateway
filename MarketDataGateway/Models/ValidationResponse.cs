namespace MarketDataGateway.Models
{
    /// <summary>
    /// Validation Response
    /// </summary>
    public class ValidationResponse
    {
        /// <summary>
        /// Enumeration of possible validation statuses
        /// </summary>
        public enum ValidationResponseStatus {
            SUCCESS,
            ERROR
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public ValidationResponseStatus Status { get; set; }
    }
}
