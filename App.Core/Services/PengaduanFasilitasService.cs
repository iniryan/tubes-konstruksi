using App.Core.Models;
using App.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace App.Core.Services
{
    public class PengaduanFasilitasService
    {
        private readonly string _filePath;
        private readonly Validator _validator;
        public PengaduanFasilitasService()
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string solutionDirectory = Path.GetFullPath(Path.Combine(exeDirectory, "..", "..", "..", ".."));
            _filePath = Path.Combine(solutionDirectory, "App.Core", "Database", "Fasilitas.json");
            string? directoryPath = Path.GetDirectoryName(_filePath);
            if (directoryPath != null)
            {
                Directory.CreateDirectory(directoryPath);
            }

            _validator = new Validator();
        }        // CREATE
        public async Task<Pengaduan<DetailFasilitas>> TambahPengaduanAsync(int userId, string namaPelapor, string lokasi,
            string deskripsi, Prioritas prioritas, string jenisFasilitas)
        {
            var semuaPengaduan = await JsonUtils.ReadDataAsync<Pengaduan<DetailFasilitas>>(_filePath);
            var detail = new DetailFasilitas(userId, namaPelapor, lokasi, deskripsi, prioritas, jenisFasilitas);

            // Validate the detail before adding
            _validator.Validate(detail);

            var pengaduanBaru = new Pengaduan<DetailFasilitas>(Guid.NewGuid().ToString(), detail);
            try
            {
                semuaPengaduan.Add(pengaduanBaru);
                await JsonUtils.WriteDataAsync(_filePath, semuaPengaduan);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            return pengaduanBaru;
        }

        // READ - Mengambil semua pengaduan fasilitas
        public async Task<List<Pengaduan<DetailFasilitas>>> AmbilSemuaPengaduanAsync()
        {
            return await JsonUtils.ReadDataAsync<Pengaduan<DetailFasilitas>>(_filePath);
        }

        // READ - Mengambil pengaduan berdasarkan ID
        public async Task<Pengaduan<DetailFasilitas>?> AmbilPengaduanByIdAsync(string id)
        {
            var semuaPengaduan = await AmbilSemuaPengaduanAsync();
            return semuaPengaduan.FirstOrDefault(p => p.Id == id);
        }

        // UPDATE
        public async Task UbahStatusAsync(string id, StatusPengaduan statusBaru)
        {
            var semuaPengaduan = await JsonUtils.ReadDataAsync<Pengaduan<DetailFasilitas>>(_filePath);
            var pengaduan = semuaPengaduan.FirstOrDefault(p => p.Id == id);
            if (pengaduan == null)
            {
                throw new KeyNotFoundException($"Pengaduan dengan ID {id} tidak ditemukan.");
            }
            try
            {
                pengaduan.UbahStatus(statusBaru);
                await JsonUtils.WriteDataAsync(_filePath, semuaPengaduan);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        // UPDATE - Mengubah detail data sebuah pengaduan
        public async Task UbahDataPengaduanAsync(string id, int userId, string namaPelapor, string lokasi, string deskripsi, Prioritas prioritas, string jenisFasilitas)
        {
            var semuaPengaduan = await JsonUtils.ReadDataAsync<Pengaduan<DetailFasilitas>>(_filePath);
            var pengaduan = semuaPengaduan.FirstOrDefault(p => p.Id == id);
            if (pengaduan == null)
            {
                throw new KeyNotFoundException($"Pengaduan dengan ID {id} tidak ditemukan.");
            }
            if (string.IsNullOrWhiteSpace(namaPelapor)) throw new ArgumentException("Nama pelapor tidak boleh kosong.", nameof(namaPelapor));
            if (string.IsNullOrWhiteSpace(lokasi)) throw new ArgumentException("Lokasi tidak boleh kosong.", nameof(lokasi));
            if (string.IsNullOrWhiteSpace(deskripsi)) throw new ArgumentException("Deskripsi tidak boleh kosong.", nameof(deskripsi));
            if (string.IsNullOrWhiteSpace(jenisFasilitas)) throw new ArgumentException("Jenis fasilitas tidak boleh kosong.", nameof(jenisFasilitas));

            try
            {
                pengaduan.Detail.UserId = userId;
                pengaduan.Detail.NamaPelapor = namaPelapor;
                pengaduan.Detail.Lokasi = lokasi;
                pengaduan.Detail.Deskripsi = deskripsi;
                pengaduan.Detail.PrioritasPengaduan = prioritas;
                pengaduan.Detail.JenisFasilitas = jenisFasilitas;

                // Validate the updated detail
                _validator.Validate(pengaduan.Detail);

                await JsonUtils.WriteDataAsync(_filePath, semuaPengaduan);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        // DELETE
        public async Task HapusPengaduanAsync(string id)
        {
            var semuaPengaduan = await JsonUtils.ReadDataAsync<Pengaduan<DetailFasilitas>>(_filePath);
            var pengaduan = semuaPengaduan.FirstOrDefault(p => p.Id == id);
            if (pengaduan == null)
            {
                throw new KeyNotFoundException($"Pengaduan dengan ID {id} tidak ditemukan.");
            }
            semuaPengaduan.Remove(pengaduan);
            await JsonUtils.WriteDataAsync(_filePath, semuaPengaduan);
        }

        public async Task<int> HitungTotalPengaduanAsync()
        {
            var semuaPengaduan = await AmbilSemuaPengaduanAsync();
            return semuaPengaduan.Count;
        }

        public async Task<Dictionary<StatusPengaduan, int>> HitungKomposisiStatusAsync()
        {
            var semuaPengaduan = await AmbilSemuaPengaduanAsync();
            return semuaPengaduan
                .GroupBy(p => p.Status)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}