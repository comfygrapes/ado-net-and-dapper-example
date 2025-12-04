namespace ADONETandDapperExample.Data.DatabaseCreator
{
    public interface IDatabaseCreator
    {
        void CreateDatabase(string connectionString);
        Task CreateDatabaseAsync(string connectionString);
    }
}
