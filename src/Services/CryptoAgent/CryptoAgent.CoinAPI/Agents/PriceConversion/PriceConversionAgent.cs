namespace CryptoAgent.CoinAPI.Agents.PriceConversion;

public class PriceConversionAgent : EntityAgent<PriceConversionModel>, IPriceConversionAgent
{
    public PriceConversionAgent(ICoinMarketConfiguration coinMarketConfiguration) : base(coinMarketConfiguration)
    {
    }
}