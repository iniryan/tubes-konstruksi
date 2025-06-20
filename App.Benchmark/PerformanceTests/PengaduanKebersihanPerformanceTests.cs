using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using App.Core.Models;
using App.Core.Services;

namespace App.Benchmark.PerformanceTests
{
    [MemoryDiagnoser]
    [SimpleJob(warmupCount: 2, iterationCount: 5)]
    public class PengaduanKebersihanPerformanceTests
    {
        private PengaduanKebersihanService _service = null!;
        private List<string> _ids = null!;

        [GlobalSetup]
        public async Task Setup()
        {
            _service = new PengaduanKebersihanService();
            _ids = new List<string>(1000);

            for (int i = 0; i < 1000; i++)
            {
                string pelapor = "Pelapor " + i;
                string deskripsi = "Deskripsi masalah " + i;
                string lokasi = "Lokasi " + i;
                var pengaduan = await _service.TambahPengaduanAsync(1, pelapor, lokasi, deskripsi, Prioritas.Sedang, "Sampah");
                _ids.Add(pengaduan.Id);
            }

            Console.WriteLine("Setup completed. Total Pengaduan: " + _ids.Count);
        }

        [Benchmark]
        public async Task TambahPengaduan_Massal_Performance()
        {
            for (int i = 0; i < 100; i++)  // Reduced for better benchmark performance
            {
                string pelapor = "Pelapor Benchmark " + i;
                string deskripsi = "Deskripsi benchmark " + i;
                string lokasi = "Lokasi Benchmark " + i;
                await _service.TambahPengaduanAsync(1, pelapor, lokasi, deskripsi, Prioritas.Sedang, "Sampah");
            }
        }

        [Benchmark]
        public async Task CariPengaduan_Performance()
        {
            foreach (var id in _ids.Take(100))  // Take only first 100 for better performance
            {
                var pengaduan = await _service.AmbilPengaduanByIdAsync(id);
            }
        }

        [Benchmark]
        public async Task UpdatePengaduan_Performance()
        {
            foreach (var id in _ids.Take(50))  // Take only first 50 for better performance
            {
                try
                {
                    await _service.UbahDataPengaduanAsync(id, 1, "Pelapor Update", "Lokasi Update", "Deskripsi Update", Prioritas.Tinggi, "Sampah");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating Pengaduan with ID " + id + ": " + ex.Message);
                }
            }
        }

        [Benchmark]
        public async Task UbahStatus_Performance()
        {
            foreach (var id in _ids.Take(50))
            {
                try
                {
                    await _service.UbahStatusAsync(id, StatusPengaduan.Diproses);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating status for ID " + id + ": " + ex.Message);
                }
            }
        }

        [Benchmark]
        public async Task HapusPengaduan_Performance()
        {
            // Create fresh data for deletion test
            var tempIds = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                var pengaduan = await _service.TambahPengaduanAsync(1, "Delete Test " + i, "Lokasi Delete", "Deskripsi Delete", Prioritas.Rendah, "Test");
                tempIds.Add(pengaduan.Id);
            }

            foreach (var id in tempIds)
            {
                try
                {
                    var pengaduan = await _service.AmbilPengaduanByIdAsync(id);
                    if (pengaduan != null)
                    {
                        await _service.HapusPengaduanAsync(id);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting Pengaduan with ID " + id + ": " + ex.Message);
                }
            }
        }

        [Benchmark]
        public async Task HitungStatistik_Performance()
        {
            var totalTask = _service.HitungTotalPengaduanAsync();
            var komposisiTask = _service.HitungKomposisiStatusAsync();

            await Task.WhenAll(totalTask, komposisiTask);
        }
    }
}