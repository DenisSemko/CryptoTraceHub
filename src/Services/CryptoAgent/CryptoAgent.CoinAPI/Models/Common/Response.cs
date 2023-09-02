namespace CryptoAgent.CoinAPI.Models.Common;

public class Response<T>
{
    [JsonProperty("data")]
    public Dictionary<string, T> Data { get; set; }
    [JsonProperty("status")]
    public Status Status { get; set; }
}