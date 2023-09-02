namespace CryptoAgent.CoinAPI.Agents.Quotes;

public class QuotesAgent : EntityAgent<QuotesModel>, IQuotesAgent
{
    public QuotesAgent(ICoinMarketConfiguration coinMarketConfiguration) : base(coinMarketConfiguration)
    {
    }
}