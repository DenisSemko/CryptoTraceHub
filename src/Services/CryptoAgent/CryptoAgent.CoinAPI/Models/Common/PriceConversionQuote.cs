namespace CryptoAgent.CoinAPI.Models.Common;

public class PriceConversionQuote
{
    [JsonProperty("price")]
    public double? Price { get; set; }
    [JsonProperty("last_updated")]
    public DateTime? LastUpdated { get; set; }
}