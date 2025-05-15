using Microsoft.Data.Sqlite;
using PengaduanKeamananCLI.Models;
using PengaduanKeamananCLI.Database;
using System;

namespace PengaduanKeamananCLI.Services
{
    public static class AuthService
    {
        public static User? Login(string username, string password)
        {
            using (var conn = new SqliteConnection(DatabaseHelper.ConnString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT id, username, password, role FROM users WHERE username = @u AND password = @p";
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            Id = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Password = reader.GetString(2),
                            Role = reader.GetString(3)
                        };
                    }
                }
            }
            return null;
        }

        public static bool Register(string username, string password)
        {
            using (var conn = new SqliteConnection(DatabaseHelper.ConnString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM users WHERE username = @u";
                cmd.Parameters.AddWithValue("@u", username);
                object? result = cmd.ExecuteScalar();
                long count = (result is not null) ? (long)result : 0;
                if (count > 0)
                {
                    return false; // Username sudah ada
                }
                cmd.CommandText = "INSERT INTO users (username, password, role) VALUES (@u, @p, 'user')";
                cmd.Parameters.AddWithValue("@p", password);
                cmd.ExecuteNonQuery();
                return true;
            }
        }
    }
} 