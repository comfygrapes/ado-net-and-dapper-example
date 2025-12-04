namespace ADONETandDapperExample.Data
{
    public static class DatabaseConfig
    {
        public static string GetConnectionString()
        {
            var databaseFileName = "test.db";
            var databaseFilePath = Path.Combine(Directory.GetCurrentDirectory(), databaseFileName);

            return $"Data Source={databaseFilePath};";
        }
    }
}
