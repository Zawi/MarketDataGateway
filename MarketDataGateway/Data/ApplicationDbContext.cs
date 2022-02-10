using Duende.IdentityServer.EntityFramework.Options;
using MarketDataGateway.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MarketDataGateway.Data
{
    /// <summary>
    /// Database context
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.ApiAuthorization.IdentityServer.ApiAuthorizationDbContext&lt;MarketDataGateway.Models.ApplicationUser&gt;" />
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {

        /// <summary>Gets or sets the market contributions.</summary>
        /// <value>The market contributions.</value>
        public DbSet<MarketContributionEntity> MarketContributions { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" />.</param>
        /// <param name="operationalStoreOptions">The <see cref="T:Microsoft.Extensions.Options.IOptions`1" />.</param>
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }
    }
}