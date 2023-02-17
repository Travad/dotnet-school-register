using System.Data;
using Microsoft.Data.Sqlite;

namespace SchoolRegister.Api.Data.Contexts;

public interface IDBConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync();
}

public class SqlLiteConnectionFactory : IDBConnectionFactory
{
    private readonly string? _connectionString;

    public SqlLiteConnectionFactory(string? connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IDbConnection> CreateConnectionAsync()
    {
        var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync();
        return connection;
    }
}