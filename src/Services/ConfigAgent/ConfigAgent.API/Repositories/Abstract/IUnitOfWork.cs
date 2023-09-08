namespace ConfigAgent.API.Repositories.Abstract;

public interface IUnitOfWork
{
    ICredentialsRepository Credentials { get; }
    Task<bool> Complete();
    bool HasChanges();
}