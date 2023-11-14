using Constants = CryptoTraceHub.UnitTests.ConfigAgent.Common.Constants;

namespace CryptoTraceHub.UnitTests.ConfigAgent;

public class ConfigAgentTests
{
    #region fields
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<ICipherService> _mockCipherService;
    private readonly Mock<ICredentialsRepository> _mockCredentialsRepository;
    private readonly IMapper _mapper;
    private readonly ICredentialsService _credentialsService;
    #endregion
    
    #region ctor
    public ConfigAgentTests()
    {
        IConfigAgentTestConfiguration testConfiguration = new ConfigAgentTestConfiguration();
        Mock<IServiceProvider> mockServiceProvider = new Mock<IServiceProvider>();

        _mockUnitOfWork = testConfiguration.MockUnitOfWork();
        _mockCipherService = testConfiguration.MockCipherService();
        _mockCredentialsRepository = testConfiguration.MockCredentialsRepository();
        _mapper = testConfiguration.DefineMapper();
        
        mockServiceProvider.Setup(p => p.GetService(typeof(ICipherService))).Returns(_mockCipherService.Object);
        CipherLocator.Initialize(mockServiceProvider.Object);
        
        _credentialsService = new CredentialsService(_mockUnitOfWork.Object, _mapper);
    }
    #endregion

    #region cipher service

    [Fact]
    public void Encrypt_PlainText_ReturnsArgumentNullException()
    {
        _mockCipherService.Setup(c => c.Encrypt("")).Throws<ArgumentNullException>();
        
        ArgumentNullException exception = Should.Throw<ArgumentNullException>
        (
             () =>
            {
                _mockCipherService.Object.Encrypt("");
            }
        );
        exception.ShouldNotBeNull();
    }
    
    [Fact]
    public void Encrypt_Credentials_ReturnsEncryptedString()
    {
        string credentialsToEncrypt = $"{Constants.ApiKey};{Constants.Url}";

        string encryptedResult = _mockCipherService.Object.Encrypt(credentialsToEncrypt);

        encryptedResult.ShouldBeOfType<string>();
        encryptedResult.ShouldBeEquivalentTo(Constants.EncryptedCredentials);
    }
    
    [Fact]
    public void Decrypt_PlainText_ReturnsArgumentNullException()
    {
        _mockCipherService.Setup(c => c.Decrypt("")).Throws<ArgumentNullException>();
        
        ArgumentNullException exception = Should.Throw<ArgumentNullException>
        (
            () =>
            {
                _mockCipherService.Object.Decrypt("");
            }
        );
        exception.ShouldNotBeNull();
    }
    
    [Fact]
    public void Decrypt_Credentials_ReturnsDecryptedString()
    {
        string encryptedCredentials = Constants.EncryptedCredentials;
        string credentials = $"{Constants.ApiKey};{Constants.Url}";

        string decryptedResult = _mockCipherService.Object.Decrypt(encryptedCredentials);

        decryptedResult.ShouldBeOfType<string>();
        decryptedResult.ShouldBeEquivalentTo(credentials);
    }

    #endregion
    
    #region credentials service
    [Fact]
    public async Task Get_Credentials_ReturnsKeyNotFoundException()
    {
        List<Credentials> dummyCredentials = new List<Credentials>();
        
        _mockCredentialsRepository
            .Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(dummyCredentials);
        _mockUnitOfWork.Setup(uow => uow.Credentials).Returns(_mockCredentialsRepository.Object);
        
        ICredentialsService credentialsService = new CredentialsService(_mockUnitOfWork.Object, _mapper);
        
        KeyNotFoundException exception = await Should.ThrowAsync<KeyNotFoundException>
        (
            async () =>
            {
                await credentialsService.Get();
            }
        );
        exception.ShouldNotBeNull();
    }
    
    [Fact]
    public async Task Get_Credentials_ReturnsDatabaseCredentials()
    {
        CredentialsModel credentials = await _credentialsService.Get();

        credentials.ShouldBeOfType<CredentialsModel>();
        credentials.ApiKey.ShouldBeEquivalentTo(Constants.ApiKey);
        credentials.BaseUrl.ShouldBeEquivalentTo(Constants.Url);
        credentials.CoinApiType.ShouldBeEquivalentTo(CoinApiType.CoinMarketCap);
    }
    
    [Fact]
    public async Task Post_ExistedCredentials_ReturnsAgentsException()
    {
        CredentialsModel credentials = new CredentialsModel()
        {
            ApiKey = Constants.ApiKey,
            BaseUrl = Constants.Url,
            CoinApiType = CoinApiType.CoinMarketCap
        };
        Mock<ConfigController> mockController = new Mock<ConfigController>(_credentialsService);
        
        AgentException exception = await Should.ThrowAsync<AgentException>
        (
            async () =>
            {
                await mockController.Object.Post(credentials);
            }
        );
        exception.ShouldNotBeNull();
    }
    
    [Fact]
    public async Task Post_Credentials_ReturnsDatabaseCredentials()
    {
        CredentialsModel credentialsModel = new CredentialsModel()
        {
            ApiKey = "test",
            BaseUrl = Constants.Url,
            CoinApiType = CoinApiType.CoinMarketCap
        };

        await _credentialsService.InsertOne(credentialsModel);
        IReadOnlyList<Credentials> credentials = await _mockUnitOfWork.Object.Credentials.GetAllAsync();

        credentials.Count.ShouldBe(2);
    }
    
    [Fact]
    public async Task Put_NotValidCredentials_ReturnsKeyNotFoundException()
    {
        CredentialsModel credentialsModel = new CredentialsModel()
        {
            ApiKey = "test",
            BaseUrl = Constants.Url,
            CoinApiType = CoinApiType.CoinApi
        };
        
        KeyNotFoundException exception = await Should.ThrowAsync<KeyNotFoundException>
        (
            async () =>
            {
                await _credentialsService.Update(credentialsModel);
            }
        );
        exception.ShouldNotBeNull();
    }
    
    [Fact]
    public async Task Put_Credentials_ReturnsUpdatedCredentials()
    {
        //Arrange
        const string twitterUrl = "https://twitter.com";
        
        _mockCipherService.Setup(c => c.Decrypt(It.IsAny<string>())).Returns(Constants.ApiKey + ";" + twitterUrl);
        ICredentialsService credentialsService = new CredentialsService(_mockUnitOfWork.Object, _mapper);
        
        CredentialsModel credentials = await credentialsService.Get();
        credentials.BaseUrl = twitterUrl;
        
        //Act
        await credentialsService.Update(credentials);
        CredentialsModel updatedCredentials = await credentialsService.Get();
        
        //Assert
        credentials.ShouldBeOfType<CredentialsModel>();
        updatedCredentials.ApiKey.ShouldBeEquivalentTo(Constants.ApiKey);
        updatedCredentials.BaseUrl.ShouldBeEquivalentTo(credentials.BaseUrl);
        credentials.CoinApiType.ShouldBeEquivalentTo(CoinApiType.CoinMarketCap);
    }
    
    [Fact]
    public async Task Delete_NotValidCredentials_ReturnsKeyNotFoundException()
    {
        Guid credentialsId = Guid.NewGuid();
        
        KeyNotFoundException exception = await Should.ThrowAsync<KeyNotFoundException>
        (
            async () =>
            {
                await _credentialsService.Delete(credentialsId);
            }
        );
        exception.ShouldNotBeNull();
    }
    
    [Fact]
    public async Task Delete_Credentials_ReturnsEmptyList()
    {
        IReadOnlyList<Credentials> credentials = await _mockUnitOfWork.Object.Credentials.GetAllAsync();
        
        await _credentialsService.Delete(credentials[0].Id);
        IReadOnlyList<Credentials> updatedCredentials = await _mockUnitOfWork.Object.Credentials.GetAllAsync();
        
        updatedCredentials.ShouldBeEmpty();
    }
    
    #endregion
}