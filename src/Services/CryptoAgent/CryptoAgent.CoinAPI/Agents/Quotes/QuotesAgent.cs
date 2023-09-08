namespace CryptoAgent.CoinAPI.Agents.Quotes;

public class QuotesAgent : EntityAgent<QuotesModel>, IQuotesAgent
{
    public QuotesAgent(IRequestClient<CheckCredentialsEvent> requestClient) : base(requestClient)
    {
    }
}