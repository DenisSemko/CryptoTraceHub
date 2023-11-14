using Constants = CryptoTraceHub.UnitTests.ConfigAgent.Common.Constants;

namespace CryptoTraceHub.UnitTests.ConfigAgent;

public class ConfigAgentTestConfiguration : BaseTestConfiguration, IConfigAgentTestConfiguration
{
    public Mock<IUnitOfWork> MockUnitOfWork()
    {
        Mock<IUnitOfWork> mockUnitOfWork = new ();
        mockUnitOfWork.Setup(uow => uow.Credentials).Returns(MockCredentialsRepository().Object);

        return mockUnitOfWork;
    }

    public Mock<ICredentialsRepository> MockCredentialsRepository()
    {
        List<Credentials> dummyCredentials = new List<Credentials>
        {
            new Credentials()
            {
                Id = new Guid("fc7d4a06-8bc7-45bc-aa41-48aa57b8dd59"),
                EncryptedCredentials = Constants.EncryptedCredentials,
                CoinApiType = CoinApiType.CoinMarketCap
            }
        };
        
        Mock<ICredentialsRepository> mockCredentialsRepository = new ();
        
        mockCredentialsRepository
            .Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(dummyCredentials);
        
        mockCredentialsRepository
            .Setup(repo => repo.GetByIdAsync(dummyCredentials[0].Id))
            .ReturnsAsync(dummyCredentials[0]);

        mockCredentialsRepository
            .Setup(repo => repo.GetByCoinApiType(dummyCredentials[0].CoinApiType))
            .ReturnsAsync(dummyCredentials[0]);

        mockCredentialsRepository.Setup(repo => repo.InsertOneAsync(It.IsAny<Credentials>()))
            .Returns((Credentials credentials) =>
            {
                dummyCredentials.Add(credentials);
                return Task.CompletedTask;
            });
        
        mockCredentialsRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Credentials>()))
            .Returns(Task.CompletedTask);
        
        mockCredentialsRepository
            .Setup(repo => repo.DeleteAsync(dummyCredentials[0].Id))
            .Returns((Guid id) =>
            {
                if (dummyCredentials[0].Id == id)
                {
                    dummyCredentials.Remove(dummyCredentials[0]);
                }
                return Task.CompletedTask;
            });
        
        return mockCredentialsRepository;
    }

    public Mock<ICipherService> MockCipherService()
    {
        Mock<ICipherService> mockCipherService = new Mock<ICipherService>();
        mockCipherService.Setup(c => c.Encrypt(It.IsAny<string>())).Returns(Constants.EncryptedCredentials);
        mockCipherService.Setup(c => c.Decrypt(It.IsAny<string>())).Returns(Constants.ApiKey + ";" + Constants.Url);

        return mockCipherService;
    }
}