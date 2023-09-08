namespace ConfigAgent.API.Services.Abstract;

public interface ICredentialsService
{
    Task<CredentialsModel> Get();
    Task InsertOne(CredentialsModel entity);
    Task Update(CredentialsModel entity);
    Task Delete(Guid id);
}