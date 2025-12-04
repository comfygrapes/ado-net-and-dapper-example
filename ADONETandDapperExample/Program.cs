using ADONETandDapperExample.Data;
using ADONETandDapperExample.Data.DatabaseCreator;

namespace ADONETandDapperExample
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            IDatabaseCreator databaseCreator = new AdoDatabaseCreator();
            databaseCreator.CreateDatabase(DatabaseConfig.GetConnectionString());

            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            Application.Run(new TodoManagementForm());
        }
    }
}