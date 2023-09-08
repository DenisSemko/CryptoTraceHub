namespace ConfigAgent.API.Repositories.Abstract;

public interface ICredentialsRepository : IBaseRepository<Credentials>
{
    Task<Credentials> GetByCoinApiType(CoinApiType coinApiType);
}