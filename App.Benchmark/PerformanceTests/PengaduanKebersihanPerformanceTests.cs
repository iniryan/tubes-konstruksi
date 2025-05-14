using System;
using System.Collections.Generic;
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
        public void Setup()
        {
            _service = new PengaduanKebersihanService();
            _ids = new List<string>(20);

            for (int i = 0; i < 20; i++)
            {
                string pelapor = String.Format("Pelapor {0}", i);
                string masalah = String.Format("Masalah {0}", i);
                string lokasi = String.Format("Lokasi {0}", i);
                var pengaduan = _service.TambahPengaduan(pelapor, masalah, lokasi, Prioritas.Sedang, "Kebersihan");
                _ids.Add(pengaduan.Id);
            }

            Console.WriteLine("Setup completed. Total Pengaduan: " + _ids.Count);
        }

        [Benchmark]
        public void TambahPengaduan_Massal_Performance()
        {
            for (int i = 0; i < 20; i++)
            {
                string pelapor = String.Format("Pelapor {0}", i);
                string masalah = String.Format("Masalah {0}", i);
                string lokasi = String.Format("Lokasi {0}", i);
                _service.TambahPengaduan(pelapor, masalah, lokasi, Prioritas.Sedang, "Kebersihan");
            }
        }

        [Benchmark]
        public void CariPengaduan_Performance()
        {
            foreach (var id in _ids)
            {
                var pengaduan = _service.AmbilPengaduanById(id);
            }
        }

        [Benchmark]
        public void UpdatePengaduan_Performance()
        {
            foreach (var id in _ids)
            {
                try
                {
                    _service.UbahDataPengaduan(id, "Pelapor Update", "Masalah Update", "Lokasi Update", Prioritas.Tinggi, "Kebersihan");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(String.Format("Error updating Pengaduan with ID {0}: {1}", id, ex.Message));
                }
            }
        }

        [Benchmark]
        public void HapusPengaduan_Performance()
        {
            foreach (var id in _ids)
            {
                try
                {
                    var pengaduan = _service.AmbilPengaduanById(id);
                    if (pengaduan != null)
                    {
                        _service.HapusPengaduan(id);
                    }
                    else
                    {
                        Console.WriteLine(string.Format("Pengaduan dengan ID {0} tidak ditemukan selama penghapusan.", id));
                    }
                }
                catch (KeyNotFoundException ex)
                {
                    Console.WriteLine(string.Format("Error: {0}", ex.Message));
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(string.Format("Error deleting Pengaduan with ID {0}: {1}", id, ex.Message));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Unexpected error for Pengaduan with ID {0}: {1}", id, ex.Message));
                }
            }
        }

    }
}
