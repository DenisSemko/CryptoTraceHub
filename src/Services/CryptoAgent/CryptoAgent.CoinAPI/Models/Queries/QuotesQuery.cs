namespace CryptoAgent.CoinAPI.Models.Queries;

public sealed class QuotesQuery
{
    [JsonProperty("id")]
    public string? Id { get; set; }
    [JsonProperty("symbol")]
    public string? Symbol { get; set; }
    [JsonProperty("slug")]
    public string? Slug { get; set; }
    [JsonProperty("convert")]
    public string? Convert { get; set; }
    [JsonProperty("convert_id")]
    public string? ConvertId { get; set; }
    [JsonProperty("aux")]
    public string? Aux { get; set; }
    [JsonProperty("skip_invalid")] 
    public bool SkipInvalid { get; set; } = true;
}