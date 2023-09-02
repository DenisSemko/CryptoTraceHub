namespace CryptoAgent.CoinAPI.Models.Common;

public class SingleResponse<T>
{
    [JsonProperty("data")]
    public T Data { get; set; }
    [JsonProperty("status")]
    public Status Status { get; set; }
}