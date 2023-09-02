namespace CryptoAgent.CoinAPI.Models.Queries;

public class QueryParameters
{
    public string BindQueryParameters<T>(T queryObject)
    {
        string json = JsonConvert.SerializeObject(queryObject);
        Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        
        IEnumerable<string> queryParams = data
            .Where(kv => kv.Value is not null)
            .Select(kv => 
                $"{kv.Key}={Uri.EscapeDataString(kv.Value.ToString())}");

        return string.Join("&", queryParams);
    }
}