namespace CryptoAgent.CoinAPI.Agents;

public class EntityAgent<T> : IEntityAgent<T> where T : class
{
    private readonly HttpManager _httpManager;
    private readonly ICoinMarketConfiguration _coinMarketConfiguration;

    public EntityAgent(ICoinMarketConfiguration coinMarketConfiguration)
    {
        _httpManager = new HttpManager();
        _coinMarketConfiguration = coinMarketConfiguration ?? throw new ArgumentNullException(nameof(coinMarketConfiguration));
    }

    public async Task<ResponseList<T>> GetList<T>(string uri)
    {
        HttpRequestMessage request = new HttpRequestMessage();
        request.Headers.Add(Constants.Cryptocurrency.ApiKeyHeader,_coinMarketConfiguration.ApiKey);
        request.RequestUri = new Uri($"{_coinMarketConfiguration.BaseUrl}/{uri}");

        string response = await _httpManager.Get(request);
        return JsonConvert.DeserializeObject<ResponseList<T>>(response);
    }
    
    public async Task<Response<T>> GetDictionary<T>(string uri)
    {
        HttpRequestMessage request = new HttpRequestMessage();
        request.Headers.Add(Constants.Cryptocurrency.ApiKeyHeader,_coinMarketConfiguration.ApiKey);
        request.RequestUri = new Uri($"{_coinMarketConfiguration.BaseUrl}/{uri}");

        string response = await _httpManager.Get(request);
        return JsonConvert.DeserializeObject<Response<T>>(response);
    }
    
    public async Task<SingleResponse<T>> GetSingle<T>(string uri)
    {
        HttpRequestMessage request = new HttpRequestMessage();
        request.Headers.Add(Constants.Cryptocurrency.ApiKeyHeader,_coinMarketConfiguration.ApiKey);
        request.RequestUri = new Uri($"{_coinMarketConfiguration.BaseUrl}/{uri}");

        string response = await _httpManager.Get(request);
        return JsonConvert.DeserializeObject<SingleResponse<T>>(response);
    }

    public async Task<TResponse> Post<TRequest, TResponse>(TRequest body, string uri)
    {
        HttpRequestMessage request = new HttpRequestMessage();
        request.Headers.Add(Constants.Cryptocurrency.ApiKeyHeader,_coinMarketConfiguration.ApiKey);
        request.RequestUri = new Uri($"{_coinMarketConfiguration.BaseUrl}/{uri}");
        request.Content = new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8,
            @"application/json");

        string response = await _httpManager.Post(request);
        return JsonConvert.DeserializeObject<TResponse>(response);
    }

    public async Task<TResponse> Update<TRequest, TResponse>(TRequest body, string uri)
    {
        HttpRequestMessage request = new HttpRequestMessage();
        request.Headers.Add(Constants.Cryptocurrency.ApiKeyHeader,_coinMarketConfiguration.ApiKey);
        request.RequestUri = new Uri($"{_coinMarketConfiguration.BaseUrl}/{uri}");
        request.Content = new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8,
            @"application/json");

        string response = await _httpManager.Put(request);
        return JsonConvert.DeserializeObject<TResponse>(response);
    }

    public async Task<TResponse> Delete<TRequest, TResponse>(TRequest body, string uri)
    {
        HttpRequestMessage request = new HttpRequestMessage();
        request.Headers.Add(Constants.Cryptocurrency.ApiKeyHeader,_coinMarketConfiguration.ApiKey);
        request.RequestUri = new Uri($"{_coinMarketConfiguration.BaseUrl}/{uri}");
        request.Content = new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8,
            @"application/json");

        string response = await _httpManager.Delete(request);
        return JsonConvert.DeserializeObject<TResponse>(response);
    }
}