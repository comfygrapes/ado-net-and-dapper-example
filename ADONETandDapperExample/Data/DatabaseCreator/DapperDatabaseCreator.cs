using Dapper;
using Microsoft.Data.Sqlite;

namespace ADONETandDapperExample.Data.DatabaseCreator
{
    public class DapperDatabaseCreator : IDatabaseCreator
    {
        private readonly string _createTodoTableSql = @"
            CREATE TABLE IF NOT EXISTS todos
            (
                id INTEGER PRIMARY KEY,
                title TEXT NOT NULL,
                description TEXT NULL,
                created_at TEXT NOT NULL,
                updated_at TEXT NULL
            );";

        public void CreateDatabase(string connectionString)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            connection.Execute(_createTodoTableSql);
        }

        public async Task CreateDatabaseAsync(string connectionString)
        {
            using var connection = new SqliteConnection(connectionString);
            await connection.OpenAsync();

            await connection.ExecuteAsync(_createTodoTableSql);
        }
    }
}
