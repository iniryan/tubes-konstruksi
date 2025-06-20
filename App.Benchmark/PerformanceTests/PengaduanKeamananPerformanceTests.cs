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
    public class PengaduanKeamananPerformanceTests
    {
        private PengaduanKeamananService _service = null!;
        private List<string> _ids = null!;

        [GlobalSetup]
        public async Task Setup()
        {
            _service = new PengaduanKeamananService();
            _ids = new List<string>(500);

            for (int i = 0; i < 500; i++)
            {
                string pelapor = "Pelapor Keamanan " + i;
                string deskripsi = "Deskripsi keamanan " + i;
                string lokasi = "Lokasi Keamanan " + i;
                string jenisInsiden = (i % 3 == 0) ? "Pencurian" : (i % 3 == 1) ? "Gangguan" : "Akses Tidak Sah";
                var pengaduan = await _service.TambahPengaduanAsync(1, pelapor, lokasi, deskripsi, jenisInsiden, "Sedang");
                _ids.Add(pengaduan.Id);
            }

            Console.WriteLine("Keamanan Setup completed. Total Pengaduan: " + _ids.Count);
        }

        [Benchmark]
        public async Task TambahPengaduanKeamanan_Performance()
        {
            for (int i = 0; i < 50; i++)
            {
                string pelapor = "Pelapor Benchmark Keamanan " + i;
                string deskripsi = "Deskripsi benchmark keamanan " + i;
                string lokasi = "Lokasi Benchmark Keamanan " + i;
                string jenisInsiden = (i % 4 == 0) ? "Pencurian" : (i % 4 == 1) ? "Gangguan" : (i % 4 == 2) ? "Akses Tidak Sah" : "Vandalisme";
                await _service.TambahPengaduanAsync(1, pelapor, lokasi, deskripsi, jenisInsiden, "Rendah");
            }
        }

        [Benchmark]
        public async Task CariPengaduanKeamanan_Performance()
        {
            foreach (var id in _ids.Take(100))
            {
                var pengaduan = await _service.AmbilPengaduanByIdAsync(id);
            }
        }

        [Benchmark]
        public async Task UpdatePengaduanKeamanan_Performance()
        {
            foreach (var id in _ids.Take(30))
            {
                try
                {
                    await _service.UbahDataPengaduanAsync(id, 1, "Pelapor Update Keamanan", "Lokasi Update", "Deskripsi Update", "Pencurian", "Tinggi");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating Keamanan with ID " + id + ": " + ex.Message);
                }
            }
        }

        [Benchmark]
        public async Task UbahStatusKeamanan_Performance()
        {
            foreach (var id in _ids.Take(30))
            {
                try
                {
                    await _service.UbahStatusAsync(id, StatusPengaduan.Diproses);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating Keamanan status for ID " + id + ": " + ex.Message);
                }
            }
        }

        [Benchmark]
        public async Task HitungStatistikKeamanan_Performance()
        {
            var totalTask = _service.HitungTotalPengaduanAsync();
            var komposisiTask = _service.HitungKomposisiStatusAsync();

            await Task.WhenAll(totalTask, komposisiTask);
        }
    }
}
