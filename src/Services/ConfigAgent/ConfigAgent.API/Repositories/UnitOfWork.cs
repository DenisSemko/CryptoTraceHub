namespace ConfigAgent.API.Repositories;

public class UnitOfWork : IUnitOfWork
{
    #region Private fields
    
    private readonly ApplicationContext _applicationContext;
    
    #endregion

    #region ctor
    
    public UnitOfWork(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    
    #endregion

    #region Repositories
    
    private ICredentialsRepository _credentialsRepository;
    public ICredentialsRepository Credentials => _credentialsRepository ?? new CredentialsRepository(_applicationContext);
    
    #endregion

    public async Task<bool> Complete() => 
        await _applicationContext.SaveChangesAsync() > 0;

    public bool HasChanges()
    {
        _applicationContext.ChangeTracker.DetectChanges();
        bool changes = _applicationContext.ChangeTracker.HasChanges();

        return changes;
    }
}