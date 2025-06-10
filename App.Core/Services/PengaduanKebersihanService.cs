using App.Core.Models;
using App.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace App.Core.Services
{
    public class PengaduanKebersihanService
    {
        private readonly string _filePath;

        public PengaduanKebersihanService()
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string solutionDirectory = Path.GetFullPath(Path.Combine(exeDirectory, "..", "..", "..", ".."));

            _filePath = Path.Combine(solutionDirectory, "App.Core", "Database", "Kebersihan.json");

            string? directoryPath = Path.GetDirectoryName(_filePath);
            if (directoryPath != null)
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        // CREATE
        public async Task<Pengaduan<DetailKebersihan>> TambahPengaduanAsync(string namaPelapor, string deskripsi,
            string lokasi, Prioritas prioritas, string kategori)
        {
            var semuaPengaduan = await JsonUtils.ReadDataAsync<Pengaduan<DetailKebersihan>>(_filePath);
            var detail = new DetailKebersihan(namaPelapor, lokasi, deskripsi, prioritas, kategori);
            var pengaduanBaru = new Pengaduan<DetailKebersihan>(Guid.NewGuid().ToString(), detail);
            semuaPengaduan.Add(pengaduanBaru);
            await JsonUtils.WriteDataAsync(_filePath, semuaPengaduan);
            return pengaduanBaru;
        }

        // READ - Mengambil semua pengaduan kebersihan
        public async Task<List<Pengaduan<DetailKebersihan>>> AmbilSemuaPengaduanAsync()
        {
            return await JsonUtils.ReadDataAsync<Pengaduan<DetailKebersihan>>(_filePath);
        }

        // READ - Mengambil pengaduan berdasarkan ID
        public async Task<Pengaduan<DetailKebersihan>?> AmbilPengaduanByIdAsync(string id)
        {
            var semuaPengaduan = await AmbilSemuaPengaduanAsync();
            return semuaPengaduan.FirstOrDefault(p => p.Id == id);
        }

        // UPDATE
        public async Task UbahStatusAsync(string id, StatusPengaduan statusBaru)
        {
            var semuaPengaduan = await JsonUtils.ReadDataAsync<Pengaduan<DetailKebersihan>>(_filePath);
            var pengaduan = semuaPengaduan.FirstOrDefault(p => p.Id == id);
            if (pengaduan == null)
            {
                throw new KeyNotFoundException("Pengaduan dengan ID tersebut tidak ditemukan.");
            }
            pengaduan.UbahStatus(statusBaru);
            await JsonUtils.WriteDataAsync(_filePath, semuaPengaduan);
        }

        // UPDATE - Mengubah detail data sebuah pengaduan
        public async Task UbahDataPengaduanAsync(string id, string namaPelapor, string deskripsi, string lokasi, Prioritas prioritas, string kategori)
        {
            var semuaPengaduan = await JsonUtils.ReadDataAsync<Pengaduan<DetailKebersihan>>(_filePath);
            var pengaduan = semuaPengaduan.FirstOrDefault(p => p.Id == id);
            if (pengaduan == null)
            {
                throw new KeyNotFoundException("Pengaduan dengan ID tersebut tidak ditemukan untuk diubah.");
            }

            if (string.IsNullOrWhiteSpace(namaPelapor)) throw new ArgumentException("Nama pelapor tidak boleh kosong.", nameof(namaPelapor));
            if (string.IsNullOrWhiteSpace(lokasi)) throw new ArgumentException("Lokasi tidak boleh kosong.", nameof(lokasi));
            if (string.IsNullOrWhiteSpace(deskripsi)) throw new ArgumentException("Deskripsi tidak boleh kosong.", nameof(deskripsi));
            if (string.IsNullOrWhiteSpace(kategori)) throw new ArgumentException("Kategori tidak boleh kosong.", nameof(kategori));

            pengaduan.Detail.NamaPelapor = namaPelapor;
            pengaduan.Detail.Lokasi = lokasi;
            pengaduan.Detail.Deskripsi = deskripsi;
            pengaduan.Detail.PrioritasPengaduan = prioritas;
            pengaduan.Detail.Kategori = kategori;

            await JsonUtils.WriteDataAsync(_filePath, semuaPengaduan);
        }

        // DELETE
        public async Task HapusPengaduanAsync(string id)
        {
            var semuaPengaduan = await JsonUtils.ReadDataAsync<Pengaduan<DetailKebersihan>>(_filePath);
            var pengaduan = semuaPengaduan.FirstOrDefault(p => p.Id == id);
            if (pengaduan == null)
            {
                throw new KeyNotFoundException("Pengaduan tidak ditemukan untuk dihapus.");
            }
            semuaPengaduan.Remove(pengaduan);
            await JsonUtils.WriteDataAsync(_filePath, semuaPengaduan);
        }
    }
}
