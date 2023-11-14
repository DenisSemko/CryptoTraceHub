namespace CryptoTraceHub.UnitTests.ConfigAgent.Common;

public class BaseTestConfiguration : IBaseTestConfiguration
{
    private readonly IMapper _mapper;

    public BaseTestConfiguration()
    {
        MapperConfiguration mapperConfig = new (configuration =>
        {
            configuration.AddProfile<CredentialsProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    public IMapper DefineMapper() => _mapper;
}