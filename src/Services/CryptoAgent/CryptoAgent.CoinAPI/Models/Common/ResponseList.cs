namespace CryptoAgent.CoinAPI.Models.Common;

public class ResponseList<T>
{
    [JsonProperty("data")]
    public List<T> Data { get; set; }
    [JsonProperty("status")]
    public Status Status { get; set; }
}