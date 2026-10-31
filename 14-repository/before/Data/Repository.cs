using Microsoft.EntityFrameworkCore;

namespace Before.Data;

public sealed class Repository<T>(BookingsDbContext context) : IRepository<T> where T : class
{
    public async Task AddAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await context.Set<T>().FindAsync(id);
    }

    public Task<List<T>> GetAllAsync(params string[] includes)
    {
        var query = context.Set<T>().AsQueryable();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return query.ToListAsync();
    }

    public void Update(T entity)
    {
        context.Set<T>().Update(entity);
    }

    public void Remove(T entity)
    {
        context.Set<T>().Remove(entity);
    }

    public Task SaveChangesAsync()
    {
        return context.SaveChangesAsync();
    }
}
