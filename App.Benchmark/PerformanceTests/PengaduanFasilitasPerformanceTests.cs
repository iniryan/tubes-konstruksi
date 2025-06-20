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
    public class PengaduanFasilitasPerformanceTests
    {
        private PengaduanFasilitasService _service = null!;
        private List<string> _ids = null!;

        [GlobalSetup]
        public async Task Setup()
        {
            _service = new PengaduanFasilitasService();
            _ids = new List<string>(500);

            for (int i = 0; i < 500; i++)
            {
                string pelapor = "Pelapor Fasilitas " + i;
                string deskripsi = "Deskripsi fasilitas " + i;
                string lokasi = "Lokasi Fasilitas " + i;
                string jenisFasilitas = (i % 2 == 0) ? "AC" : "Proyektor";
                var pengaduan = await _service.TambahPengaduanAsync(1, pelapor, lokasi, deskripsi, Prioritas.Sedang, jenisFasilitas);
                _ids.Add(pengaduan.Id);
            }

            Console.WriteLine("Fasilitas Setup completed. Total Pengaduan: " + _ids.Count);
        }

        [Benchmark]
        public async Task TambahPengaduanFasilitas_Performance()
        {
            for (int i = 0; i < 50; i++)
            {
                string pelapor = "Pelapor Benchmark Fasilitas " + i;
                string deskripsi = "Deskripsi benchmark fasilitas " + i;
                string lokasi = "Lokasi Benchmark Fasilitas " + i;
                string jenisFasilitas = (i % 3 == 0) ? "AC" : (i % 3 == 1) ? "Proyektor" : "Lift";
                await _service.TambahPengaduanAsync(1, pelapor, lokasi, deskripsi, Prioritas.Rendah, jenisFasilitas);
            }
        }

        [Benchmark]
        public async Task CariPengaduanFasilitas_Performance()
        {
            foreach (var id in _ids.Take(100))
            {
                var pengaduan = await _service.AmbilPengaduanByIdAsync(id);
            }
        }

        [Benchmark]
        public async Task UpdatePengaduanFasilitas_Performance()
        {
            foreach (var id in _ids.Take(30))
            {
                try
                {
                    await _service.UbahDataPengaduanAsync(id, 1, "Pelapor Update Fasilitas", "Lokasi Update", "Deskripsi Update", Prioritas.Tinggi, "AC");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating Fasilitas with ID " + id + ": " + ex.Message);
                }
            }
        }

        [Benchmark]
        public async Task UbahStatusFasilitas_Performance()
        {
            foreach (var id in _ids.Take(30))
            {
                try
                {
                    await _service.UbahStatusAsync(id, StatusPengaduan.Diproses);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating Fasilitas status for ID " + id + ": " + ex.Message);
                }
            }
        }

        [Benchmark]
        public async Task HitungStatistikFasilitas_Performance()
        {
            var totalTask = _service.HitungTotalPengaduanAsync();
            var komposisiTask = _service.HitungKomposisiStatusAsync();

            await Task.WhenAll(totalTask, komposisiTask);
        }
    }
}
