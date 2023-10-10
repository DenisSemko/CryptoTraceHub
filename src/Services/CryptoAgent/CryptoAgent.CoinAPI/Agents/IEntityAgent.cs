namespace CryptoAgent.CoinAPI.Agents;

public interface IEntityAgent<T> where T : class
{
    Task<ResponseList<T>> GetList<T>(string uri);
    Task<Models.Common.Response<T>> GetDictionary<T>(string uri);
    Task<SingleResponse<T>> GetSingle<T>(string uri);
}