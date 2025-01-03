using Microsoft.EntityFrameworkCore;

namespace GameGuide.Data.Common;

public class Repository : IRepository
{
    private readonly ApplicationDbContext _context;
    
    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    private DbSet<T> DbSet<T>() where T : class
    {
        return _context.Set<T>();
    }
    
    public IQueryable<T> All<T>() where T : class
    {
        return DbSet<T>();
    }

    public IQueryable<T> AllReadOnly<T>() where T : class
    {
        return DbSet<T>().AsNoTracking();
    }

    public async Task<T?> GetByIdAsync<T>(object id) where T : class
    {
        return await DbSet<T>().FindAsync(id);
    }

    public async Task<int> SaveChangesAsync<T>() where T : class
    {
        return await _context.SaveChangesAsync();
    }

    public async Task AddAsync<T>(T entity) where T : class
    {
        await DbSet<T>().AddAsync(entity);
    }

    public async Task DeleteAsync<T>(T? entity) where T : class
    {
        if (entity != null)
        {
            DbSet<T>().Remove(entity);
        }
    }
}