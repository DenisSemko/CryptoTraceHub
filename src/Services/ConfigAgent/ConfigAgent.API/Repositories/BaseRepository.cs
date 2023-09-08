namespace ConfigAgent.API.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly ApplicationContext ApplicationContext;

    public BaseRepository(ApplicationContext applicationContext)
    {
        ApplicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
    }

    public async Task<IReadOnlyList<T>> GetAllAsync() =>
        await ApplicationContext.Set<T>().ToListAsync();

    public async Task<T?> GetByIdAsync(Guid id) =>
        await ApplicationContext.Set<T>().FindAsync(id);

    public async Task<bool> AnyAsync()
    {
        int count = await ApplicationContext.Set<T>().CountAsync();
        return count > 0;
    }

    public async Task InsertOneAsync(T entity)
    {
        await ApplicationContext.Set<T>().AddAsync(entity);
        await ApplicationContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        ApplicationContext.Set<T>().Update(entity);
        await ApplicationContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        T entity = await ApplicationContext.Set<T>().FindAsync(id);
        ApplicationContext.Set<T>().Remove(entity);
        await ApplicationContext.SaveChangesAsync();
    }
}