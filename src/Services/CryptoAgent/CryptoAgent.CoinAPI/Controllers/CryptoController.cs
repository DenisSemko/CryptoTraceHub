namespace CryptoAgent.CoinAPI.Controllers;

/// <summary>
/// Controller for Catalog Items operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CryptoController : ControllerBase
{
    #region PrivateFields

    private readonly ICoinService _coinService;
    private readonly ILogger<CryptoController> _logger;

    #endregion

    #region ctor

    public CryptoController(ICoinService coinService, ILogger<CryptoController> logger)
    {
        _coinService = coinService ?? throw new ArgumentNullException(nameof(coinService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    #endregion

    #region ControllerMethods
    
    /// <summary>
    /// Gets All Supported Coins.
    /// </summary>
    /// <param name="currency">
    /// Currency.
    /// </param>
    /// <returns>
    /// Returns a List of Coins.
    /// </returns>
    [HttpGet("currency:{currency}")]
    [ProducesResponseType(typeof(IReadOnlyList<CoinMarkets>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IReadOnlyList<CoinMarkets>>> Get(string currency)
    {
        _logger.Log(LogLevel.Information, "Executing CoinMarkets Get");
        
        IReadOnlyList<CoinMarkets> coinMarkets = await _coinService.GetAllSupportedCoins(currency);

        return Ok(coinMarkets);
    }
    
    /// <summary>
    /// Gets Coin By Id.
    /// </summary>
    /// <param name="id">
    /// Coin's Id.
    /// </param>
    /// <returns>
    /// Returns a Coin data.
    /// </returns>
    [HttpGet("id:{id}")]
    [ProducesResponseType(typeof(CoinList), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CoinList>> GetCoinById(string id)
    {
        _logger.Log(LogLevel.Information, "Executing Coin Get By Id");
        
        CoinList coin = await _coinService.GetCoinById(id);

        return Ok(coin);
    }
    
    /// <summary>
    /// Gets Coin's History By Id.
    /// </summary>
    /// <param name="id">
    /// Coin's Id.
    /// </param>
    /// <param name="date">
    /// The date of data snapshot, format: dd-mm-yyyy
    /// </param>
    /// <returns>
    /// Returns a Coin's history.
    /// </returns>
    [HttpGet("{id}/{date}")]
    [ProducesResponseType(typeof(CoinList), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CoinList>> GetCoinHistoryById(string id, string date)
    {
        _logger.Log(LogLevel.Information, "Executing CoinHistory Get By Id and Date");
        
        CoinList coin = await _coinService.GetCoinHistoryById(id, date);

        return Ok(coin);
    }
    
    /// <summary>
    /// Gets Coin's History By Id.
    /// </summary>
    /// <param name="id">
    /// Coin's Id.
    /// </param>
    /// <param name="currency">
    /// Currency.
    /// </param>
    /// <param name="days">
    /// Data up to number of days ago (eg. 1,14,30,max).
    /// </param>
    /// <returns>
    /// Returns a MarketChart.
    /// </returns>
    [HttpGet("{id}/{date}/{days}")]
    [ProducesResponseType(typeof(CoinList), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CoinList>> GetMarketChartByCoinId(string id, string currency, string days)
    {
        _logger.Log(LogLevel.Information, "Executing MarketChart Get By Id");
        
        MarketChartById marketChart = await _coinService.GetMarketChartByCoinId(id, currency, days);

        return Ok(marketChart);
    }
    #endregion
}