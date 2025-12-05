using ADONETandDapperExample.Entities;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Globalization;
using static Dapper.SqlMapper;

namespace ADONETandDapperExample.Repositories
{
    public class AdoTodoRepository : ITodoRepository, ITodoRepositoryAsync
    {
        public AdoTodoRepository(string connectionString)
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
            var list = new List<Todo>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = _getAllSql;

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(ReadTodoFromReader(reader));
            }

            return list;
        }

        public Todo? GetById(long id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = _getByIdSql;

            var idParameter = command.CreateParameter();
            idParameter.ParameterName = "@Id";
            idParameter.Value = id;
            command.Parameters.Add(idParameter);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return ReadTodoFromReader(reader);
            }

            return null;
        }

        public long Create(Todo entity)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = _createSql;

            AddTodoParameters(command, entity);

            command.ExecuteNonQuery();

            using var lastIdCommand = connection.CreateCommand();
            lastIdCommand.CommandText = "SELECT last_insert_rowid();";

            var result = lastIdCommand.ExecuteScalar();

            if (result is long id) return id;
            return 0;
        }

        public void Update(Todo entity)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = _updateSql;

            var idParameter = command.CreateParameter();
            idParameter.ParameterName = "@Id";
            idParameter.Value = entity.Id;
            command.Parameters.Add(idParameter);

            entity.UpdatedAt = DateTime.UtcNow;

            AddTodoParameters(command, entity);

            command.ExecuteNonQuery();
        }

        public void Delete(long id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = _deleteSql;

            var idParameter = command.CreateParameter();
            idParameter.ParameterName = "@Id";
            idParameter.Value = id;
            command.Parameters.Add(idParameter);

            command.ExecuteNonQuery();
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            var list = new List<Todo>();

            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();


            using var command = connection.CreateCommand();
            command.CommandText = _getAllSql;

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(ReadTodoFromReader(reader));
            }

            return list;
        }

        public async Task<Todo?> GetByIdAsync(long id)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = _getByIdSql;

            var idParameter = command.CreateParameter();
            idParameter.ParameterName = "@Id";
            idParameter.Value = id;
            command.Parameters.Add(idParameter);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return ReadTodoFromReader(reader);
            }

            return null;
        }

        public async Task<long> CreateAsync(Todo entity)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = _createSql;

            AddTodoParameters(command, entity);

            await command.ExecuteNonQueryAsync();

            using var lastIdCommand = connection.CreateCommand();
            lastIdCommand.CommandText = "SELECT last_insert_rowid();";

            var result = await lastIdCommand.ExecuteScalarAsync();

            if (result is long id) return id;
            return 0;
        }

        public async Task UpdateAsync(Todo entity)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = _updateSql;

            var idParameter = command.CreateParameter();
            idParameter.ParameterName = "@Id";
            idParameter.Value = entity.Id;
            command.Parameters.Add(idParameter);

            entity.UpdatedAt = DateTime.UtcNow;

            AddTodoParameters(command, entity);

            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(long id)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = _deleteSql;

            var idParameter = command.CreateParameter();
            idParameter.ParameterName = "@Id";
            idParameter.Value = id;
            command.Parameters.Add(idParameter);

            await command.ExecuteNonQueryAsync();
        }

        // -- Helper Methods --

        private static Todo ReadTodoFromReader(IDataReader reader)
        {
            var todo = new Todo
            {
                Id = reader.GetInt64(reader.GetOrdinal("id")),
                Title = reader.GetString(reader.GetOrdinal("title")),
                Description = reader.IsDBNull(reader.GetOrdinal("description"))
                                ? null
                                : reader.GetString(reader.GetOrdinal("description")),
                CreatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("created_at")), CultureInfo.InvariantCulture),
                UpdatedAt = reader.IsDBNull(reader.GetOrdinal("updated_at"))
                                ? (DateTime?)null
                                : DateTime.Parse(reader.GetString(reader.GetOrdinal("updated_at")), CultureInfo.InvariantCulture)
            };
            return todo;
        }

        private static void AddTodoParameters(IDbCommand command, Todo entity)
        {
            var titleParameter = command.CreateParameter();
            titleParameter.ParameterName = "@Title";
            titleParameter.Value = entity.Title;
            command.Parameters.Add(titleParameter);

            var descriptionParameter = command.CreateParameter();
            descriptionParameter.ParameterName = "@Description";
            descriptionParameter.Value = (object?)entity.Description ?? DBNull.Value;
            command.Parameters.Add(descriptionParameter);

            var createdAtParameter = command.CreateParameter();
            createdAtParameter.ParameterName = "@CreatedAt";
            createdAtParameter.Value = entity.CreatedAt.ToString("o");
            command.Parameters.Add(createdAtParameter);

            var updatedAtParameter = command.CreateParameter();
            updatedAtParameter.ParameterName = "@UpdatedAt";
            updatedAtParameter.Value = entity.UpdatedAt.HasValue
                                ? entity.UpdatedAt.Value.ToString("o")
                                : DBNull.Value;
            command.Parameters.Add(updatedAtParameter);
        }
    }
}
