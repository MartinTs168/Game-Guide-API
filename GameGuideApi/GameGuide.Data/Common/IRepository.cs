namespace GameGuide.Data.Common;

public interface IRepository
{
    IQueryable<T> All<T>() where T : class;

    IQueryable<T> AllReadOnly<T>() where T : class;
    
    Task<T?> GetGetByIdAsync<T> (object id) where T : class;
    
    Task<int> SaveChangesAsync<T> () where T : class;
    
    Task AddAsync<T>(T entity) where T : class;
    
    Task DeleteAsync<T> (object id) where T : class;
}