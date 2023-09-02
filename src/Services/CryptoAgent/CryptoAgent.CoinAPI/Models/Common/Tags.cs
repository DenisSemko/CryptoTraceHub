namespace CryptoAgent.CoinAPI.Models.Common;

public class Tags
{
    [JsonProperty("slug")]
    public string Slug { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("category")]
    public string Category { get; set; }
}