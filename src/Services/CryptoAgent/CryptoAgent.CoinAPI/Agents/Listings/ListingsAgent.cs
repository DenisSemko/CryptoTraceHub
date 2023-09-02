namespace CryptoAgent.CoinAPI.Agents.Listings;

public class ListingsAgent : EntityAgent<ListingsModel>, IListingsAgent
{
    public ListingsAgent(ICoinMarketConfiguration coinMarketConfiguration) : base(coinMarketConfiguration)
    {
    }
}