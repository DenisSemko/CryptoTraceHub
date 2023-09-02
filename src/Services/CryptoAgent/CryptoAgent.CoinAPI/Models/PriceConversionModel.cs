namespace CryptoAgent.CoinAPI.Models;

public class PriceConversionModel
{
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("symbol")]
    public string Symbol { get; set; }
    [JsonProperty("amount")]
    public double Amount { get; set; }
    [JsonProperty("last_updated")]
    public DateTime? LastUpdated { get; set; }
    [JsonProperty("quote")]
    public Dictionary<string, PriceConversionQuote> Quote { get; set; }
}