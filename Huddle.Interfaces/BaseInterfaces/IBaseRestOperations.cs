namespace Huddle.Interfaces.BaseInterfaces;

public interface IBaseRestOperations<T>
{
    Task<T?> GetEntityByIdAsync(int id);
    Task<IEnumerable<T>> GetEntitiesAsync();
    Task<T> AddEntityAsync(T entity);
    Task UpdateEntityAsync(T entity);
    Task DeleteEntityAsync(int id);
}