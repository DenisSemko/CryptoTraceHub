namespace CryptoAgent.CoinAPI.Controllers;

/// <summary>
/// Controller for Catalog Items operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CryptoController : ControllerBase
{
    #region PrivateFields

    private readonly IListingsAgent _listingsAgent;
    private readonly IQuotesAgent _quotesAgent;
    private readonly IPriceConversionAgent _priceConversionAgent;
    private readonly QueryParameters _queryParameters;
    private readonly ILogger<CryptoController> _logger;

    #endregion

    #region ctor

    public CryptoController(IListingsAgent listingsAgent, IQuotesAgent quotesAgent, IPriceConversionAgent priceConversionAgent, ILogger<CryptoController> logger)
    {
        _listingsAgent = listingsAgent ?? throw new ArgumentNullException(nameof(listingsAgent));
        _quotesAgent = quotesAgent ?? throw new ArgumentNullException(nameof(quotesAgent));
        _priceConversionAgent = priceConversionAgent ?? throw new ArgumentNullException(nameof(priceConversionAgent));
        _queryParameters = new QueryParameters();
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    #endregion

    #region ControllerMethods
    
    /// <summary>
    /// Gets All Coins.
    /// </summary>
    /// <param name="listingsQuery">
    /// The Listings Query.
    /// </param>
    /// <returns>
    /// Returns a List of Coins.
    /// </returns>
    [HttpGet("listings")]
    [ProducesResponseType(typeof(IReadOnlyList<ListingsModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IReadOnlyList<ListingsModel>>> GetListings([FromQuery] ListingsQuery listingsQuery)
    {
        _logger.Log(LogLevel.Information, "Executing Listings Get");
        
        if (!string.IsNullOrWhiteSpace(listingsQuery.Convert) && !string.IsNullOrWhiteSpace(listingsQuery.ConvertId))
        {
            throw new AgentException("Properties 'convert' and 'convert_id' cannot be used together.", 400);
        }

        ResponseList<ListingsModel> response = await _listingsAgent.GetList<ListingsModel>(Constants.Cryptocurrency.Listing.Latest + $"?{_queryParameters.BindQueryParameters(listingsQuery)}");
        IReadOnlyList<ListingsModel> coinMarkets = response.Data;

        return Ok(coinMarkets);
    }
    
    /// <summary>
    /// Gets Quotes.
    /// </summary>
    /// <param name="quotesQuery">
    /// The Quotes Query.
    /// </param>
    /// <returns>
    /// Returns a Coin Latest Data.
    /// </returns>
    [HttpGet("quote")]
    [ProducesResponseType(typeof(List<QuotesModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<List<QuotesModel>>> GetQuotes([FromQuery] QuotesQuery quotesQuery)
    {
        _logger.Log(LogLevel.Information, "Executing Quotes Get");
        
        if (string.IsNullOrWhiteSpace(quotesQuery.Id) && string.IsNullOrWhiteSpace(quotesQuery.Symbol) && string.IsNullOrWhiteSpace(quotesQuery.Slug))
        {
            throw new AgentException("'id', 'symbol' or 'slug' must be used.", 400);
        }
        if (!string.IsNullOrWhiteSpace(quotesQuery.Convert) && !string.IsNullOrWhiteSpace(quotesQuery.ConvertId))
        {
            throw new AgentException("Properties 'convert' and 'convert_id' cannot be used together.", 400);
        }

        Response<QuotesModel> response = await _quotesAgent.GetDictionary<QuotesModel>(Constants.Cryptocurrency.Quotes.Latest + $"?{_queryParameters.BindQueryParameters(quotesQuery)}");
        List<QuotesModel> quotes = response?.Data?.Values?.ToList();

        return Ok(quotes);
    }
    
    /// <summary>
    /// Converts currency price.
    /// </summary>
    /// <param name="priceQuery">
    /// The Price Conversion Query.
    /// </param>
    /// <returns>
    /// Returns Converted values.
    /// </returns>
    [HttpGet("price-conversion")]
    [ProducesResponseType(typeof(PriceConversionModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<PriceConversionModel>> GetPriceConversion([FromQuery] PriceConversionQuery priceQuery)
    {
        _logger.Log(LogLevel.Information, "Executing Price Conversion Get");
        
        if (!string.IsNullOrWhiteSpace(priceQuery.Convert) && !string.IsNullOrWhiteSpace(priceQuery.ConvertId))
        {
            throw new AgentException("Properties 'convert' and 'convert_id' cannot be used together.", 400);
        }

        SingleResponse<PriceConversionModel> response = await _priceConversionAgent.GetSingle<PriceConversionModel>(Constants.Tools.PriceConversion.Url + $"?{_queryParameters.BindQueryParameters(priceQuery)}");
        PriceConversionModel priceConversion = response?.Data;

        return Ok(priceConversion);
    }
    #endregion
}