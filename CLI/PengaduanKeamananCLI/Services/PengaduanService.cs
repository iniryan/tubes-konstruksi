using Microsoft.Data.Sqlite;
using PengaduanKeamananCLI.Models;
using PengaduanKeamananCLI.Database;
using System.Collections.Generic;

namespace PengaduanKeamananCLI.Services
{
    public static class PengaduanService
    {
        public static void TambahPengaduan(Pengaduan pengaduan)
        {
            using (var conn = new SqliteConnection(DatabaseHelper.ConnString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO pengaduan (nama_pengadu, rt, jenis_kejadian, isi_keluhan, lokasi_keluhan, status) VALUES (@nama, @rt, @jenis, @isi, @lokasi, @status)";
                cmd.Parameters.AddWithValue("@nama", pengaduan.NamaPengadu);
                cmd.Parameters.AddWithValue("@rt", pengaduan.RT);
                cmd.Parameters.AddWithValue("@jenis", pengaduan.JenisKejadian);
                cmd.Parameters.AddWithValue("@isi", pengaduan.IsiKeluhan);
                cmd.Parameters.AddWithValue("@lokasi", pengaduan.LokasiKeluhan);
                cmd.Parameters.AddWithValue("@status", pengaduan.Status);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<Pengaduan> GetAll()
        {
            var list = new List<Pengaduan>();
            using (var conn = new SqliteConnection(DatabaseHelper.ConnString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT id, nama_pengadu, rt, jenis_kejadian, isi_keluhan, lokasi_keluhan, status FROM pengaduan ORDER BY id";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Pengaduan
                        {
                            Id = reader.GetInt32(0),
                            NamaPengadu = reader.GetString(1),
                            RT = reader.GetString(2),
                            JenisKejadian = reader.GetString(3),
                            IsiKeluhan = reader.GetString(4),
                            LokasiKeluhan = reader.GetString(5),
                            Status = reader.GetInt32(6)
                        });
                    }
                }
            }
            return list;
        }

        public static List<Pengaduan> GetByUser(string username)
        {
            var list = new List<Pengaduan>();
            using (var conn = new SqliteConnection(DatabaseHelper.ConnString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT id, nama_pengadu, rt, jenis_kejadian, isi_keluhan, lokasi_keluhan, status FROM pengaduan WHERE nama_pengadu = @nama ORDER BY id";
                cmd.Parameters.AddWithValue("@nama", username);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Pengaduan
                        {
                            Id = reader.GetInt32(0),
                            NamaPengadu = reader.GetString(1),
                            RT = reader.GetString(2),
                            JenisKejadian = reader.GetString(3),
                            IsiKeluhan = reader.GetString(4),
                            LokasiKeluhan = reader.GetString(5),
                            Status = reader.GetInt32(6)
                        });
                    }
                }
            }
            return list;
        }

        public static List<Pengaduan> GetByStatus(int status)
        {
            var list = new List<Pengaduan>();
            using (var conn = new SqliteConnection(DatabaseHelper.ConnString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT id, nama_pengadu, rt, jenis_kejadian, isi_keluhan, lokasi_keluhan, status FROM pengaduan WHERE status = @status ORDER BY id";
                cmd.Parameters.AddWithValue("@status", status);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Pengaduan
                        {
                            Id = reader.GetInt32(0),
                            NamaPengadu = reader.GetString(1),
                            RT = reader.GetString(2),
                            JenisKejadian = reader.GetString(3),
                            IsiKeluhan = reader.GetString(4),
                            LokasiKeluhan = reader.GetString(5),
                            Status = reader.GetInt32(6)
                        });
                    }
                }
            }
            return list;
        }

        public static bool UpdateStatus(int id, int status)
        {
            using (var conn = new SqliteConnection(DatabaseHelper.ConnString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE pengaduan SET status = @status WHERE id = @id";
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool Delete(int id)
        {
            using (var conn = new SqliteConnection(DatabaseHelper.ConnString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM pengaduan WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
} 