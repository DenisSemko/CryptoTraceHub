namespace CryptoAgent.CoinAPI.Models.Queries;

public sealed class PriceConversionQuery
{
    [JsonProperty("amount")]
    public double Amount { get; set; }
    [JsonProperty("id")]
    public string? Id { get; set; }
    [JsonProperty("symbol")]
    public string? Symbol { get; set; }
    [JsonProperty("convert")]
    public string Convert { get; set; }
    [JsonProperty("convert_id")]
    public string? ConvertId { get; set; }
    [JsonProperty("time")]
    public DateTime? TimeStart { get; set; }
}