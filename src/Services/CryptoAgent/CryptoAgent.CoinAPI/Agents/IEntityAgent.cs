namespace CryptoAgent.CoinAPI.Agents;

public interface IEntityAgent<T> where T : class
{
    Task<ResponseList<T>> GetList<T>(string uri);
    Task<Response<T>> GetDictionary<T>(string uri);
    Task<SingleResponse<T>> GetSingle<T>(string uri);
    Task<TResponse> Post<TRequest, TResponse>(TRequest body, string uri);
    Task<TResponse> Update<TRequest, TResponse>(TRequest body, string uri);
    Task<TResponse> Delete<TRequest, TResponse>(TRequest body, string uri);
}