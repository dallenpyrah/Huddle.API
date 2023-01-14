namespace Huddle.Interfaces.BaseInterfaces;

public interface IBaseRestOperations<T>
{
    Task<T?> GetEntityByIdAsync(int id);
    Task<IEnumerable<T>> GetEntitiesAsync();
    Task<T> AddEntityAsync(T entity);
    Task<T> UpdateEntityAsync(T entity);
    Task<T> DeleteEntityAsync(int id);
}