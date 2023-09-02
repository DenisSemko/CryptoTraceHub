namespace CryptoAgent.CoinAPI.Configuration;

public class CoinMarketConfiguration : ICoinMarketConfiguration
{
    public string ApiKey { get; set; }
    public string BaseUrl { get; set; }
}