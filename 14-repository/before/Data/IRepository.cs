namespace Before.Data;

// Add / Get / Update / Remove / List for any T: it says nothing about rooms.
public interface IRepository<T> where T : class
{
    Task AddAsync(T entity);

    Task<T?> GetByIdAsync(Guid id);

    // Every entity needs a different Include, so the generic signature starts to grow.
    Task<List<T>> GetAllAsync(params string[] includes);

    void Update(T entity);

    void Remove(T entity);

    Task SaveChangesAsync();
}
