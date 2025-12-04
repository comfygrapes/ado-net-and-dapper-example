using ADONETandDapperExample.Entities;

namespace ADONETandDapperExample.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetAll();
        Todo? GetById(long id);
        long Create(Todo entity);
        void Update(Todo entity);
        void Delete(long id);
    }
}
