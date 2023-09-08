namespace ConfigAgent.API.Models;

public class CredentialsModel
{
    public string ApiKey { get; set; }
    public string BaseUrl { get; set; }
    public CoinApiType CoinApiType { get; set; } = CoinApiType.CoinMarketCap;
}