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
    public class GuestRepositoryPerformanceTests
    {
        private GuestRepository _repository = null!;
        private List<string> _ids = null!;

        [GlobalSetup]
        public async Task Setup()
        {
            _repository = new GuestRepository();
            _ids = new List<string>(500);

            for (int i = 0; i < 500; i++)
            {
                string pelapor = "Pelapor Tamu " + i;
                string deskripsi = "Deskripsi tamu " + i;
                string lokasi = "Lokasi Tamu " + i;
                string nomorIdentitas = "ID" + (1000000000 + i);
                string tujuan = "Tujuan " + i;
                string pegawaiTujuan = "Pegawai " + i;
                DateTime? waktuKeluar = (i % 3 == 0) ? DateTime.Now.AddHours(2) : null;

                var tamu = await _repository.TambahTamuAsync(1, pelapor, lokasi, deskripsi, nomorIdentitas, tujuan, pegawaiTujuan, waktuKeluar);
                _ids.Add(tamu.Id);
            }

            Console.WriteLine("Guest Repository Setup completed. Total Tamu: " + _ids.Count);
        }

        [Benchmark]
        public async Task TambahTamu_Performance()
        {
            for (int i = 0; i < 50; i++)
            {
                string pelapor = "Pelapor Benchmark Tamu " + i;
                string deskripsi = "Deskripsi benchmark tamu " + i;
                string lokasi = "Lokasi Benchmark Tamu " + i;
                string nomorIdentitas = "BENCH" + (2000000000 + i);
                string tujuan = "Tujuan Benchmark " + i;
                string pegawaiTujuan = "Pegawai Benchmark " + i;

                await _repository.TambahTamuAsync(1, pelapor, lokasi, deskripsi, nomorIdentitas, tujuan, pegawaiTujuan, null);
            }
        }

        [Benchmark]
        public async Task CariTamu_Performance()
        {
            foreach (var id in _ids.Take(100))
            {
                var tamu = await _repository.AmbilTamuByIdAsync(id);
            }
        }

        [Benchmark]
        public async Task UpdateTamu_Performance()
        {
            foreach (var id in _ids.Take(30))
            {
                try
                {
                    await _repository.UbahDetailTamuAsync(id, "Pelapor Update Tamu", "Lokasi Update", "Deskripsi Update", "ID9999999999", "Tujuan Update", "Pegawai Update", DateTime.Now);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating Tamu with ID " + id + ": " + ex.Message);
                }
            }
        }

        [Benchmark]
        public async Task UbahStatusTamu_Performance()
        {
            foreach (var id in _ids.Take(30))
            {
                try
                {
                    await _repository.UbahStatusAsync(id, StatusPengaduan.Diproses);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating Tamu status for ID " + id + ": " + ex.Message);
                }
            }
        }

        [Benchmark]
        public async Task AturWaktuKeluar_Performance()
        {
            foreach (var id in _ids.Take(20))
            {
                try
                {
                    await _repository.AturWaktuKeluarAsync(id, DateTime.Now);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error setting waktu keluar for ID " + id + ": " + ex.Message);
                }
            }
        }

        [Benchmark]
        public async Task HitungStatistikTamu_Performance()
        {
            var totalTask = _repository.HitungTotalPengaduanAsync();
            var komposisiTask = _repository.HitungKomposisiStatusAsync();
            var statistikTask = _repository.HitungStatistikTamuAsync("Pelapor Tamu 1");

            await Task.WhenAll(totalTask, komposisiTask, statistikTask);
        }

        [Benchmark]
        public async Task TableDrivenOperations_Performance()
        {
            // Test table-driven field operations
            var firstId = _ids.FirstOrDefault();
            if (firstId != null)
            {
                var tamu = await _repository.AmbilTamuByIdAsync(firstId);
                if (tamu != null)
                {
                    // Test table-driven field getters
                    var fields = _repository.GetDetailFields(tamu.Detail);

                    // Simulate field validation and updates
                    await _repository.UbahDetailTamuAsync(firstId,
                        fields["NamaPelapor"] + " Updated",
                        fields["Lokasi"] + " Updated",
                        fields["Deskripsi"] + " Updated",
                        fields["NomorIdentitas"],
                        fields["Tujuan"] + " Updated",
                        fields["PegawaiTujuan"] + " Updated",
                        DateTime.Now);
                }
            }
        }
    }
}
