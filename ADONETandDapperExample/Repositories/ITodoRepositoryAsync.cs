using ADONETandDapperExample.Entities;

namespace ADONETandDapperExample.Repositories
{
    public interface ITodoRepositoryAsync
    {
        Task<IEnumerable<Todo>> GetAllAsync();
        Task<Todo?> GetByIdAsync(long id);
        Task<long> CreateAsync(Todo entity);
        Task UpdateAsync(Todo entity);
        Task DeleteAsync(long id);
    }
}
