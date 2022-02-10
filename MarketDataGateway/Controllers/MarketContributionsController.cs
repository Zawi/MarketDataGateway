using MarketDataGateway.Models;
using MarketDataGateway.Services;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MarketDataGateway.Controllers
{
    /// <summary>
    /// Controller for market data contributions
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MarketContributionsController : Controller
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<MarketContributionsController> _logger;

        /// <summary>
        /// The user manager
        /// </summary>
        private UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// The market contribution service
        /// </summary>
        private IMarketContributionService _marketContributionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarketContributionsController"/> class.
        /// </summary>
        /// <param name="marketContributionService">The market contribution service.</param>
        /// <param name="clientRequestParametersProvider">The client request parameters provider.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="userManager">The user manager.</param>
        public MarketContributionsController(
            IMarketContributionService marketContributionService,
            IClientRequestParametersProvider clientRequestParametersProvider,
            ILogger<MarketContributionsController> logger, UserManager<ApplicationUser> userManager)
        {
            ClientRequestParametersProvider = clientRequestParametersProvider;
            _logger = logger;
            _userManager = userManager;
            _marketContributionService = marketContributionService;
        }

        /// <summary>
        /// Gets the client request parameters provider.
        /// </summary>
        /// <value>
        /// The client request parameters provider.
        /// </value>
        public IClientRequestParametersProvider ClientRequestParametersProvider { get; }

        /// <summary>
        /// Posts the contrib.
        /// </summary>
        /// <param name="marketData">The market data.</param>
        /// <returns>Ok response if the contribution was added, Bad Request response otherwise</returns>
        [HttpPost("fxquotes")]
        public async Task<ActionResult<IList<MarketContribution>>> PostContrib([FromBody] FxQuote marketData)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            _logger.LogInformation("Post FX quote contribution {} from {}", marketData, user.Email);
            // Use email as ID
            var validationResult = _marketContributionService.AddContribution(user.Email, "FxQuote", marketData);
            if (validationResult)
                return Ok();
            else
                return BadRequest("Market contribution could not be validated.");
        }

        /// <summary>
        /// Gets the contributions posted by the current logged user
        /// </summary>
        /// <returns>The contributions</returns>
        [HttpGet]
        public async Task<ActionResult<IList<MarketContribution>>> GetContribs()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            _logger.LogInformation("Get all contributions for {}", user.Email);
            return Ok(_marketContributionService.GetUserContributions(user.Email));
        }

    }
}
