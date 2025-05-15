using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace PengaduanKeamananCLI.Database
{
    public static class DatabaseHelper
    {
        public static string DbPath = "pengaduan.db";
        public static string ConnString = $"Data Source={DbPath}";

        public static void InitDatabase()
        {
            // File database akan otomatis dibuat oleh SQLite jika belum ada
            using (var conn = new SqliteConnection(ConnString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                // Tabel users
                cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS users (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    username TEXT NOT NULL UNIQUE,
                    password TEXT NOT NULL,
                    role TEXT NOT NULL
                );";
                cmd.ExecuteNonQuery();
                // Tabel pengaduan
                cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS pengaduan (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    nama_pengadu TEXT NOT NULL,
                    rt TEXT NOT NULL,
                    jenis_kejadian TEXT NOT NULL,
                    isi_keluhan TEXT NOT NULL,
                    lokasi_keluhan TEXT NOT NULL,
                    status INTEGER NOT NULL DEFAULT 1
                );";
                cmd.ExecuteNonQuery();
                // Insert user & admin default jika belum ada
                cmd.CommandText = @"
                INSERT OR IGNORE INTO users (username, password, role) VALUES
                    ('admin', 'admin123', 'admin'),
                    ('user', 'user123', 'user');";
                cmd.ExecuteNonQuery();
            }
        }
    }
} 