using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using PengaduanKeamananCLI.Models;
using PengaduanKeamananCLI.Services;

namespace App.Benchmark
{
    [MemoryDiagnoser]
    public class PerformanceTesting
    {
        private readonly string testUsername = "benchmark_user";
        private readonly string testPassword = "pass123";

        [GlobalSetup]
        public void Setup()
        {
            // Pastikan user terdaftar sebelum benchmarking login
            AuthService.Register(testUsername, testPassword);

            // Tambahkan beberapa pengaduan dummy untuk pengujian baca dan filter
            for (int i = 0; i < 50; i++)
            {
                PengaduanService.TambahPengaduan(new Pengaduan
                {
                    NamaPengadu = testUsername,
                    RT = $"0{i % 10}",
                    JenisKejadian = "Kejadian Tes",
                    IsiKeluhan = $"Keluhan ke-{i}",
                    LokasiKeluhan = "RT 01 / RW 03",
                    Status = (i % 3) + 1
                });
            }
        }

        [Benchmark]
        public void BenchmarkLogin()
        {
            var user = AuthService.Login(testUsername, testPassword);
        }

        [Benchmark]
        public void BenchmarkRegister()
        {
            var username = "user_" + Guid.NewGuid().ToString("N").Substring(0, 8);
            AuthService.Register(username, testPassword);
        }

        [Benchmark]
        public void BenchmarkTambahPengaduan()
        {
            PengaduanService.TambahPengaduan(new Pengaduan
            {
                NamaPengadu = testUsername,
                RT = "01",
                JenisKejadian = "Uji Coba",
                IsiKeluhan = "Keluhan performa",
                LokasiKeluhan = "Lokasi uji",
                Status = 1
            });
        }

        [Benchmark]
        public void BenchmarkGetAllPengaduan()
        {
            var list = PengaduanService.GetAll();
        }

        [Benchmark]
        public void BenchmarkFilterPengaduanStatus1()
        {
            var list = PengaduanService.GetByStatus(1);
        }
    }
}
