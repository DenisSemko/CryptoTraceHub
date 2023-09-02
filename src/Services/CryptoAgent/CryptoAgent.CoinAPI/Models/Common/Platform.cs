namespace CryptoAgent.CoinAPI.Models.Common;

public class Platform
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("slug")]
    public string Slug { get; set; }

    [JsonProperty("token_address")]
    public string TokenAddress { get; set; }
}