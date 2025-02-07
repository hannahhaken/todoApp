using DbUp;
using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace TodoApp.Api.Data;

public static class DatabaseInitializer
{
    public static void Initialize(string connectionString)
    {
        EnsureDatabaseExists(connectionString);

        var upgrader = DeployChanges.To
            .SqliteDatabase(connectionString)
            .WithScriptsFromFileSystem("Data/Scripts")
            .LogToConsole()
            .Build();

        var result = upgrader.PerformUpgrade();

        if (!result.Successful)
        {
            throw new Exception($"Error while upgrading database: {result.Error}");
        }

        Console.WriteLine("Database initialised and migrations applied successfully!");

        using var connection = new SqliteConnection(connectionString);
        connection.Open();
    }

    private static void EnsureDatabaseExists(string connectionString)
    {
        var builder = new SqliteConnectionStringBuilder(connectionString);
        var databasePath = builder.DataSource;

        if (string.IsNullOrWhiteSpace(databasePath))
        {
            throw new ArgumentException("Invalid connection string", nameof(connectionString));
        }

        if (!File.Exists(databasePath))
        {
            Console.WriteLine($"Database file not found at {databasePath}. Creating a new database...");
            File.Create(databasePath).Dispose();
        }
    }
}