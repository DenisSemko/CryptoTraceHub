namespace CryptoAgent.CoinAPI.Manager;

internal sealed class HttpManager
{
    private readonly HttpClient _httpClient = new ();

    public async Task<string> Get(HttpRequestMessage request)
    {
        request.Method = HttpMethod.Get;

        HttpResponseMessage response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            throw new AgentException(response.Content.ReadAsStringAsync().Result, (int)response.StatusCode);
        }
        return response.Content.ReadAsStringAsync().Result;
    }
    
    public async Task<string> Post(HttpRequestMessage request)
    {
        request.Method = HttpMethod.Post;

        HttpResponseMessage response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            throw new AgentException(response.Content.ReadAsStringAsync().Result, (int)response.StatusCode);
        }
        return response.Content.ReadAsStringAsync().Result;
    }

    public async Task<string> Put(HttpRequestMessage request)
    {
        request.Method = HttpMethod.Put;

        HttpResponseMessage response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            throw new AgentException(response.Content.ReadAsStringAsync().Result, (int)response.StatusCode);
        }
        return response.Content.ReadAsStringAsync().Result;
    }

    public async Task<string> Delete(HttpRequestMessage request)
    {
        request.Method = HttpMethod.Delete;

        HttpResponseMessage response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            throw new AgentException(response.Content.ReadAsStringAsync().Result, (int)response.StatusCode);
        }
        return response.Content.ReadAsStringAsync().Result;
    }
}