using Dapper;
using Npgsql;

namespace Ropuszka.Migration.DataFabricator.Helpers;

public static class AppDb
{
    private static readonly string _connectionString = "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=ropuszka;Pooling=true;";

    public static IEnumerable<dynamic> Query(string sql) =>
        Query(sql, null);

    public static IEnumerable<dynamic> Query(string sql, DynamicParameters? parameters)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        var results = connection.Query(sql, parameters);
        return results;
    }

    public static void Execute(string sql) =>
        Execute(sql, null);

    public static void Execute(string sql, DynamicParameters? parameters)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        connection.Execute(sql, parameters);
    }
}