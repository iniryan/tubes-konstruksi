using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using App.Core.Models;
using App.Core.Services;

namespace App.Benchmark.PerformanceTests
{
    [MemoryDiagnoser]
    [SimpleJob(warmupCount: 1, iterationCount: 5)] // Reduces overhead
    public class PengaduanKebersihanPerformanceTests
    {
        private PengaduanKebersihanService _service = null!;
        private List<string> _ids = null!;

        [GlobalSetup]
        public void Setup()
        {
            _service = new PengaduanKebersihanService();
            _ids = new List<string>(20); // Specify initial capacity to reduce allocations

            for (int i = 0; i < 20; i++)
            {
                var pengaduan = _service.TambahPengaduan($"Pelapor {i}", $"Masalah {i}", $"Lokasi {i}", Prioritas.Sedang, "Kebersihan");
                _ids.Add(pengaduan.Id);
            }
        }

        [Benchmark]
        public void TambahPengaduan_Massal_Performance()
        {
            for (int i = 0; i < 20; i++)
            {
                _service.TambahPengaduan($"Pelapor {i}", $"Masalah {i}", $"Lokasi {i}", Prioritas.Sedang, "Kebersihan");
            }
        }

        [Benchmark]
        public void UbahStatus_Massal_Performance()
        {
            foreach (var id in _ids)
            {
                _service.UbahStatus(id, StatusPengaduan.Diproses);
            }
        }

        [Benchmark]
        public void AmbilSemuaPengaduan_Performance()
        {
            var pengaduanList = _service.AmbilSemuaPengaduan();
        }

        [Benchmark]
        public void AmbilPengaduanById_Performance()
        {
            var result = _service.AmbilPengaduanById(_ids[0]);
        }
    }
}
