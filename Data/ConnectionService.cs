﻿using Npgsql;

namespace Blog23.Data;

public class ConnectionService
{
    public static string? GetConnectionString(IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionString"];
        var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
        return string.IsNullOrEmpty(databaseUrl) ? connectionString : BuildConnectionString(databaseUrl);
    }
    private static string BuildConnectionString(string databaseUrl)
    {
        var databaseUri = new Uri(databaseUrl);
        var userInfo = databaseUri.UserInfo.Split(':');

        return new NpgsqlConnectionStringBuilder()
        {
            Host = databaseUri.Host,
            Port = databaseUri.Port,
            Username = userInfo[0],
            Password = userInfo[1],
            Database = databaseUri.LocalPath.TrimStart('/'),
            SslMode = SslMode.Prefer,
            TrustServerCertificate = true
        }.ToString();
    }

}
