namespace CryptoAgent.CoinAPI.Agents.PriceConversion;

public class PriceConversionAgent : EntityAgent<PriceConversionModel>, IPriceConversionAgent
{
    public PriceConversionAgent(IRequestClient<CheckCredentialsEvent> requestClient) : base(requestClient)
    {
    }
}