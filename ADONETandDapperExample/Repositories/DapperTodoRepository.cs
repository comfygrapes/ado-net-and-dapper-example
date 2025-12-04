using ADONETandDapperExample.Entities;
using Dapper;
using Microsoft.Data.Sqlite;

namespace ADONETandDapperExample.Repositories
{
    public class DapperTodoRepository : ITodoRepository, ITodoRepositoryAsync
    {
        public DapperTodoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private const string _getAllSql = @"
            SELECT id, title, description, created_at, updated_at 
            FROM todos;
        ";

        private const string _getByIdSql = @"
            SELECT id, title, description, created_at, updated_at 
            FROM todos
            WHERE id = @Id;
        ";

        private const string _createSql = @"
            INSERT INTO todos (title, description, created_at)
            VALUES (@Title, @Description, @CreatedAt);
            SELECT last_insert_rowid();
        ";

        private const string _updateSql = @"
            UPDATE todos
            SET title = @Title,
                description = @Description,
                updated_at = @UpdatedAt
            WHERE id = @Id;
        ";

        private const string _deleteSql = @"
            DELETE FROM todos
            WHERE id = @Id;
        ";

        private readonly string _connectionString;

        public IEnumerable<Todo> GetAll()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            return connection.Query<Todo>(_getAllSql);
        }

        public Todo? GetById(long id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            return connection.QuerySingleOrDefault(_getByIdSql, new { Id = id });
        }

        public long Create(Todo entity)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var id = connection.ExecuteScalar<long>(_createSql, entity);
            return id;
        }

        public void Update(Todo entity)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            entity.UpdatedAt = DateTime.UtcNow;

            connection.Execute(_updateSql, entity);
        }

        public void Delete(long id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            connection.Execute(_deleteSql, new { Id = id });
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            return await connection.QueryAsync<Todo>(_getAllSql);
        }

        public async Task<Todo?> GetByIdAsync(long id)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            return await connection.QuerySingleOrDefaultAsync(_getByIdSql, new { Id = id });
        }

        public async Task<long> CreateAsync(Todo entity)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            var id = await connection.ExecuteScalarAsync<long>(_createSql, entity);
            return id;
        }

        public async Task UpdateAsync(Todo entity)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            entity.UpdatedAt = DateTime.UtcNow;

            await connection.ExecuteAsync(_updateSql, entity);
        }

        public async Task DeleteAsync(long id)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            await connection.ExecuteAsync(_deleteSql, new { Id = id });
        }
    }
}
