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

        private static readonly Dictionary<string, Func<string, bool>> _validationRules = new()
        {
            { "NamaPelapor", value => !string.IsNullOrWhiteSpace(value) && value.Length <= 100 },
            { "Lokasi", value => !string.IsNullOrWhiteSpace(value) && value.Length <= 200 },
            { "Deskripsi", value => !string.IsNullOrWhiteSpace(value) && value.Length <= 500 },
            { "NomorIdentitas", value => !string.IsNullOrWhiteSpace(value) && value.Length >= 5 && value.Length <= 20 },
            { "Tujuan", value => !string.IsNullOrWhiteSpace(value) && value.Length <= 200 },
            { "PegawaiTujuan", value => !string.IsNullOrWhiteSpace(value) && value.Length <= 100 }
        };

        private static readonly Dictionary<string, Action<DetailTamu, string>> _fieldSetters = new()
        {
            { "NamaPelapor", (detail, value) => detail.NamaPelapor = value },
            { "Lokasi", (detail, value) => detail.Lokasi = value },
            { "Deskripsi", (detail, value) => detail.Deskripsi = value },
            { "NomorIdentitas", (detail, value) => detail.NomorIdentitas = value },
            { "Tujuan", (detail, value) => detail.Tujuan = value },
            { "PegawaiTujuan", (detail, value) => detail.PegawaiTujuan = value }
        };

        private static readonly Dictionary<string, Func<DetailTamu, string>> _fieldGetters = new()
        {
            { "NamaPelapor", detail => detail.NamaPelapor },
            { "Lokasi", detail => detail.Lokasi },
            { "Deskripsi", detail => detail.Deskripsi },
            { "NomorIdentitas", detail => detail.NomorIdentitas },
            { "Tujuan", detail => detail.Tujuan },
            { "PegawaiTujuan", detail => detail.PegawaiTujuan }
        };

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
            DateTime? waktuKeluar
        )
        {
            // table-driven
            var fieldsToValidate = new Dictionary<string, string>
            {
                { "NamaPelapor", namaPelapor },
                { "Lokasi", lokasi },
                { "Deskripsi", deskripsi },
                { "NomorIdentitas", nomorIdentitas },
                { "Tujuan", tujuan },
                { "PegawaiTujuan", pegawaiTujuan }
            };

            ValidateFields(fieldsToValidate);

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
            }
            catch (Exception e)
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
            {
                throw new KeyNotFoundException("Pengaduan dengan ID tersebut tidak ditemukan.");
            }
            pengaduan.UbahStatus(statusBaru);
            await JsonUtils.WriteDataAsync(_filePath, semuaPengaduan);
        }

        public async Task<Dictionary<StatusPengaduan, int>> HitungKomposisiStatusAsync()
        {
            var semuaPengaduan = await AmbilSemuaTamuAsync();
            return semuaPengaduan
                .GroupBy(p => p.Status)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public async Task<int> HitungTotalPengaduanAsync()
        {
            var semuaPengaduan = await AmbilSemuaTamuAsync();
            return semuaPengaduan.Count;
        }

        // UPDATE - Atur waktu keluar
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
            DateTime? waktuKeluar
        )
        {
            var semuaPengaduan = await JsonUtils.ReadDataAsync<Pengaduan<DetailTamu>>(_filePath);
            var pengaduan = semuaPengaduan.FirstOrDefault(p => p.Id == id);
            if (pengaduan == null)
                throw new KeyNotFoundException("Pengaduan dengan ID tersebut tidak ditemukan untuk diubah.");

            var fieldsToValidate = new Dictionary<string, string>
            {
                { "NamaPelapor", namaPelapor },
                { "Lokasi", lokasi },
                { "Deskripsi", deskripsi },
                { "NomorIdentitas", nomorIdentitas },
                { "Tujuan", tujuan },
                { "PegawaiTujuan", pegawaiTujuan }
            };

            ValidateFields(fieldsToValidate);

            try
            {
                // Update fields using table-driven mapping
                UpdateDetailFields(pengaduan.Detail, fieldsToValidate);
                pengaduan.Detail.WaktuKeluar = waktuKeluar;

                await JsonUtils.WriteDataAsync(_filePath, semuaPengaduan);
            }
            catch (Exception e)
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

        // Table-driven validation method
        private void ValidateFields(Dictionary<string, string> fields)
        {
            var errors = new List<string>();

            foreach (var field in fields)
            {
                if (_validationRules.TryGetValue(field.Key, out var rule))
                {
                    if (!rule(field.Value))
                    {
                        errors.Add($"Field '{field.Key}' tidak valid: '{field.Value}'");
                    }
                }
            }

            if (errors.Count > 0)
            {
                throw new ArgumentException($"Validasi gagal: {string.Join(", ", errors)}");
            }
        }

        // Table-driven field update method
        private void UpdateDetailFields(DetailTamu detail, Dictionary<string, string> fields)
        {
            foreach (var field in fields)
            {
                if (_fieldSetters.TryGetValue(field.Key, out var setter))
                {
                    setter(detail, field.Value);
                }
            }
        }

        // Table-driven field getter method
        public Dictionary<string, string> GetDetailFields(DetailTamu detail)
        {
            var result = new Dictionary<string, string>();
            foreach (var getter in _fieldGetters)
            {
                result[getter.Key] = getter.Value(detail);
            }
            return result;
        }
    }
}
