using Dapper;
using Microsoft.Data.Sqlite;

namespace TodoApp.Api.Data;

public static class DatabaseInitializer
{
    public static void Initialize(string connectionString)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        const string createUserTable = @"
            CREATE TABLE IF NOT EXISTS Users (
                Id TEXT PRIMARY KEY,
                FirstName TEXT NOT NULL,
                LastName TEXT NOT NULL,
                Email TEXT NOT NULL UNIQUE,
                Password TEXT NOT NULL,
                CreatedAt TEXT NOT NULL,
                UpdatedAt TEXT NOT NULL,
                LastLoggedInAt TEXT
            );
        ";

        const string createTodoTable = @"
            CREATE TABLE IF NOT EXISTS TodoItems (
                Id TEXT PRIMARY KEY,
                Title TEXT NOT NULL,
                Description TEXT,
                Status INTEGER NOT NULL,
                CreatedAt TEXT NOT NULL,
                UpdatedAt TEXT NOT NULL,
                DueAt TEXT,
                CompletedAt TEXT,
                DeletedAt TEXT,
                UserId TEXT NOT NULL,
                FOREIGN KEY (UserId) REFERENCES Users(Id)
            );
        ";

        connection.Execute(createUserTable);
        connection.Execute(createTodoTable);
    }
}