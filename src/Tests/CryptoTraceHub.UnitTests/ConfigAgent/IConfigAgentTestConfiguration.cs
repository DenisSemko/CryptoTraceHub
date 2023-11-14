namespace CryptoTraceHub.UnitTests.ConfigAgent;

public interface IConfigAgentTestConfiguration : IBaseTestConfiguration
{
    Mock<IUnitOfWork> MockUnitOfWork();
    Mock<ICredentialsRepository> MockCredentialsRepository();
    Mock<ICipherService> MockCipherService();
}