using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Models;
using App.Core.Utils;

namespace App.Core.Services
{
    public class GuestRepository
    {
        private readonly string _filePath;

        public GuestRepository()
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string solutionDirectory = Path.GetFullPath(Path.Combine(exeDirectory, "..", "..", "..", ".."));
            _filePath = Path.Combine(solutionDirectory, "App.Core", "Database", "Tamu.json");

            string? directoryPath = Path.GetDirectoryName(_filePath);
            if (directoryPath != null)
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        // CREATE
        public async Task<Pengaduan<DetailTamu>> TambahTamuAsync(
            int userId,
            string namaPelapor,
            string lokasi,
            string deskripsi,
            string nomorIdentitas,
            string tujuan,
            string pegawaiTujuan,
            DateTime? waktuKeluar // Tambahan parameter waktu keluar
        )
        {
            var semuaPengaduan = await JsonUtils.ReadDataAsync<Pengaduan<DetailTamu>>(_filePath);

            var detail = new DetailTamu(userId, namaPelapor, lokasi, deskripsi, nomorIdentitas, tujuan, pegawaiTujuan)
            {
                WaktuKeluar = waktuKeluar
            };

            var pengaduanBaru = new Pengaduan<DetailTamu>(Guid.NewGuid().ToString(), detail);
            try
            {
                semuaPengaduan.Add(pengaduanBaru);
                await JsonUtils.WriteDataAsync(_filePath, semuaPengaduan);
            } catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            return pengaduanBaru;
                
        }

        // READ - Get all
        public async Task<List<Pengaduan<DetailTamu>>> AmbilSemuaTamuAsync()
        {
            return await JsonUtils.ReadDataAsync<Pengaduan<DetailTamu>>(_filePath);
        }

        // READ - Get by ID
        public async Task<Pengaduan<DetailTamu>?> AmbilTamuByIdAsync(string id)
        {
            var semuaPengaduan = await AmbilSemuaTamuAsync();
            return semuaPengaduan.FirstOrDefault(p => p.Id == id);
        }

        // UPDATE - Status
        public async Task UbahStatusAsync(string id, StatusPengaduan statusBaru)
        {
            var semuaPengaduan = await JsonUtils.ReadDataAsync<Pengaduan<DetailTamu>>(_filePath);
            var pengaduan = semuaPengaduan.FirstOrDefault(p => p.Id == id);
            if (pengaduan == null)
                throw new KeyNotFoundException("Pengaduan dengan ID tersebut tidak ditemukan.");
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

        // --- TAMBAHAN: Metode untuk mencatat waktu keluar secara manual (misal update dari UI) ---
        public async Task AturWaktuKeluarAsync(string id, DateTime? waktuKeluar = null)
        {
            var semuaPengaduan = await JsonUtils.ReadDataAsync<Pengaduan<DetailTamu>>(_filePath);
            var pengaduan = semuaPengaduan.FirstOrDefault(p => p.Id == id);
            if (pengaduan == null)
                throw new KeyNotFoundException("Tamu dengan ID tersebut tidak ditemukan.");

            pengaduan.Detail.WaktuKeluar = waktuKeluar ?? DateTime.Now;
            await JsonUtils.WriteDataAsync(_filePath, semuaPengaduan);
        }

        // UPDATE - Data
        public async Task UbahDetailTamuAsync(
            string id,
            string namaPelapor,
            string lokasi,
            string deskripsi,
            string nomorIdentitas,
            string tujuan,
            string pegawaiTujuan,
            DateTime? waktuKeluar // Tambahan parameter waktu keluar
        )
        {
            var semuaPengaduan = await JsonUtils.ReadDataAsync<Pengaduan<DetailTamu>>(_filePath);
            var pengaduan = semuaPengaduan.FirstOrDefault(p => p.Id == id);
            if (pengaduan == null)
                throw new KeyNotFoundException("Pengaduan dengan ID tersebut tidak ditemukan untuk diubah.");

            // Validasi input
            if (string.IsNullOrWhiteSpace(namaPelapor)) throw new ArgumentException("Nama pelapor tidak boleh kosong.", nameof(namaPelapor));
            if (string.IsNullOrWhiteSpace(lokasi)) throw new ArgumentException("Lokasi tidak boleh kosong.", nameof(lokasi));
            if (string.IsNullOrWhiteSpace(deskripsi)) throw new ArgumentException("Deskripsi tidak boleh kosong.", nameof(deskripsi));
            if (string.IsNullOrWhiteSpace(nomorIdentitas)) throw new ArgumentException("Nomor identitas tidak boleh kosong.", nameof(nomorIdentitas));
            if (string.IsNullOrWhiteSpace(tujuan)) throw new ArgumentException("Tujuan tidak boleh kosong.", nameof(tujuan));
            if (string.IsNullOrWhiteSpace(pegawaiTujuan)) throw new ArgumentException("Pegawai tujuan tidak boleh kosong.", nameof(pegawaiTujuan));

            try
            {
                pengaduan.Detail.NamaPelapor = namaPelapor;
                pengaduan.Detail.Lokasi = lokasi;
                pengaduan.Detail.Deskripsi = deskripsi;
                pengaduan.Detail.NomorIdentitas = nomorIdentitas;
                pengaduan.Detail.Tujuan = tujuan;
                pengaduan.Detail.PegawaiTujuan = pegawaiTujuan;
                pengaduan.Detail.WaktuKeluar = waktuKeluar; // Update waktu keluar

                await JsonUtils.WriteDataAsync(_filePath, semuaPengaduan);
            } catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        // DELETE
        public async Task HapusTamuAsync(string id)
        {
            var semuaPengaduan = await JsonUtils.ReadDataAsync<Pengaduan<DetailTamu>>(_filePath);
            var pengaduan = semuaPengaduan.FirstOrDefault(p => p.Id == id);
            if (pengaduan == null)
                throw new KeyNotFoundException("Pengaduan tidak ditemukan untuk dihapus.");

            semuaPengaduan.Remove(pengaduan);
            await JsonUtils.WriteDataAsync(_filePath, semuaPengaduan);
        }

        // Statistik & dasbor
        public async Task<(int total, int diproses, int selesai)> HitungStatistikTamuAsync(string namaPelapor)
        {
            if (string.IsNullOrWhiteSpace(namaPelapor)) return (0, 0, 0);

            var semuaPengaduan = await AmbilSemuaTamuAsync();
            var pengaduanPelapor = semuaPengaduan.Where(p => p.Detail.NamaPelapor.Equals(namaPelapor, StringComparison.OrdinalIgnoreCase)).ToList();

            int total = pengaduanPelapor.Count;
            int diproses = pengaduanPelapor.Count(p => p.Status == StatusPengaduan.Diproses);
            int selesai = pengaduanPelapor.Count(p => p.Status == StatusPengaduan.Selesai);

            return (total, diproses, selesai);
        }

        public async Task<int> HitungTotalTamuAsync()
        {
            var semuaPengaduan = await AmbilSemuaTamuAsync();
            return semuaPengaduan.Count;
        }
    }
}
