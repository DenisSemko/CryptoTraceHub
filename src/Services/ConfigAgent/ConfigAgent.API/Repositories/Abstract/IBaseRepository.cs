namespace ConfigAgent.API.Repositories.Abstract;

public interface IBaseRepository<T> where T : class
{
    #region Methods

    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task<bool> AnyAsync();
    Task InsertOneAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);

    #endregion
}