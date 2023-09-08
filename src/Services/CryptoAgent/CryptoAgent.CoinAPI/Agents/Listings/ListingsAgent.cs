namespace CryptoAgent.CoinAPI.Agents.Listings;

public class ListingsAgent : EntityAgent<ListingsModel>, IListingsAgent
{
    public ListingsAgent(IRequestClient<CheckCredentialsEvent> requestClient) : base(requestClient)
    {
    }
}