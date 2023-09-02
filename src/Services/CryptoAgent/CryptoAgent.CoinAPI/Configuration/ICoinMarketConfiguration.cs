namespace CryptoAgent.CoinAPI.Configuration;

public interface ICoinMarketConfiguration
{
    string ApiKey { get; set; }
    string BaseUrl { get; set; }
}