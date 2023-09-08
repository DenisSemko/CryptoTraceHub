using Constants = CryptoAgent.CoinAPI.Common.Constants;

namespace CryptoAgent.CoinAPI.Agents;

public class EntityAgent<T> : IEntityAgent<T> where T : class
{
    private readonly HttpManager _httpManager;
    private readonly IRequestClient<CheckCredentialsEvent> _requestClient;

    public EntityAgent(IRequestClient<CheckCredentialsEvent> requestClient)
    {
        _httpManager = new HttpManager();
        _requestClient = requestClient ?? throw new ArgumentNullException(nameof(requestClient));
    }

    public async Task<ResponseList<T>> GetList<T>(string uri)
    {
        HttpRequestMessage request = new HttpRequestMessage();
        CredentialsTransferEvent credentials = await HandleCredentialsResponse();
        
        request.Headers.Add(Constants.Cryptocurrency.ApiKeyHeader,credentials.ApiKey);
        request.RequestUri = new Uri($"{credentials.BaseUrl}/{uri}");

        string response = await _httpManager.Get(request);
        return JsonConvert.DeserializeObject<ResponseList<T>>(response);
    }
    
    public async Task<Models.Common.Response<T>> GetDictionary<T>(string uri)
    {
        HttpRequestMessage request = new HttpRequestMessage();
        CredentialsTransferEvent credentials = await HandleCredentialsResponse();
        
        request.Headers.Add(Constants.Cryptocurrency.ApiKeyHeader,credentials.ApiKey);
        request.RequestUri = new Uri($"{credentials.BaseUrl}/{uri}");

        string response = await _httpManager.Get(request);
        return JsonConvert.DeserializeObject<Models.Common.Response<T>>(response);
    }
    
    public async Task<SingleResponse<T>> GetSingle<T>(string uri)
    {
        HttpRequestMessage request = new HttpRequestMessage();
        CredentialsTransferEvent credentials = await HandleCredentialsResponse();
        
        request.Headers.Add(Constants.Cryptocurrency.ApiKeyHeader,credentials.ApiKey);
        request.RequestUri = new Uri($"{credentials.BaseUrl}/{uri}");

        string response = await _httpManager.Get(request);
        return JsonConvert.DeserializeObject<SingleResponse<T>>(response);
    }

    public async Task<TResponse> Post<TRequest, TResponse>(TRequest body, string uri)
    {
        HttpRequestMessage request = new HttpRequestMessage();
        CredentialsTransferEvent credentials = await HandleCredentialsResponse();
        
        request.Headers.Add(Constants.Cryptocurrency.ApiKeyHeader,credentials.ApiKey);
        request.RequestUri = new Uri($"{credentials.BaseUrl}/{uri}");
        request.Content = new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8,
            @"application/json");

        string response = await _httpManager.Post(request);
        return JsonConvert.DeserializeObject<TResponse>(response);
    }

    public async Task<TResponse> Update<TRequest, TResponse>(TRequest body, string uri)
    {
        HttpRequestMessage request = new HttpRequestMessage();
        CredentialsTransferEvent credentials = await HandleCredentialsResponse();
        
        request.Headers.Add(Constants.Cryptocurrency.ApiKeyHeader,credentials.ApiKey);
        request.RequestUri = new Uri($"{credentials.BaseUrl}/{uri}");
        request.Content = new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8,
            @"application/json");

        string response = await _httpManager.Put(request);
        return JsonConvert.DeserializeObject<TResponse>(response);
    }

    public async Task<TResponse> Delete<TRequest, TResponse>(TRequest body, string uri)
    {
        HttpRequestMessage request = new HttpRequestMessage();
        CredentialsTransferEvent credentials = await HandleCredentialsResponse();
        
        request.Headers.Add(Constants.Cryptocurrency.ApiKeyHeader,credentials.ApiKey);
        request.RequestUri = new Uri($"{credentials.BaseUrl}/{uri}");
        request.Content = new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8,
            @"application/json");

        string response = await _httpManager.Delete(request);
        return JsonConvert.DeserializeObject<TResponse>(response);
    }

    private async Task<CredentialsTransferEvent> HandleCredentialsResponse()
    {
        MassTransit.Response<CredentialsTransferEvent> credentialsResponse = await _requestClient.GetResponse<CredentialsTransferEvent>(new CheckCredentialsEvent() { CoinApiType = CoinApiType.CoinMarketCap});
        return credentialsResponse.Message;
    }
}