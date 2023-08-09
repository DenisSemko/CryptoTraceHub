using Newtonsoft.Json;

namespace CryptoAgent.CoinAPI.Services;

public class CoinService : ICoinService
{
    private readonly ICoinGeckoClient _client;

    public CoinService()
    {
        HttpClient httpClient = new HttpClient();
        JsonSerializerSettings serializerSettings = new JsonSerializerSettings();

        PingClient pingClient = new PingClient(httpClient, serializerSettings);
        _client = new CoinGeckoClient(httpClient, serializerSettings);
    }

    public async Task<IReadOnlyList<CoinMarkets>> GetAllSupportedCoins(string currency) =>
        await _client.CoinsClient.GetCoinMarkets(currency);

    public async Task<CoinList> GetCoinById(string id) =>
        await _client.CoinsClient.GetAllCoinDataWithId(id);

    public async Task<CoinList> GetCoinHistoryById(string id, string date) =>
        await _client.CoinsClient.GetHistoryByCoinId(id, date, "");

    public async Task<MarketChartById> GetMarketChartByCoinId(string id, string currency, string days) =>
        await _client.CoinsClient.GetMarketChartsByCoinId(id, currency, days);
}