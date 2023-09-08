namespace ConfigAgent.API.Repositories;

public class CredentialsRepository : BaseRepository<Credentials>, ICredentialsRepository
{
    public CredentialsRepository(ApplicationContext applicationContext) : base(applicationContext)
    {
    }

    public async Task<Credentials> GetByCoinApiType(CoinApiType coinApiType) =>
        await ApplicationContext.Credentials.FirstOrDefaultAsync(credentials => credentials.CoinApiType == coinApiType);
}