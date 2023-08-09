namespace CryptoAgent.CoinAPI.Services;

public interface ICoinService
{
    Task<IReadOnlyList<CoinMarkets>> GetAllSupportedCoins(string currency);
    Task<CoinList> GetCoinById(string id);
    Task<CoinList> GetCoinHistoryById(string id, string date);
    Task<MarketChartById> GetMarketChartByCoinId(string id, string currency, string days);
}