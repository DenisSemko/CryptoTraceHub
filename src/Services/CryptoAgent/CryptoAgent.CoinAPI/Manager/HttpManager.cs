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
}