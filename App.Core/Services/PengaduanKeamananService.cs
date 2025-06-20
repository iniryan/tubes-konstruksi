using App.Core.Models;
using App.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace App.Core.Services
{
    public class PengaduanKeamananService
    {
        private readonly string _filePath;

        private static readonly Dictionary<string, Func<string, bool>> _validationRules = new()
        {
            { "NamaPelapor", value => !string.IsNullOrWhiteSpace(value) && value.Length <= 100 },
            { "Lokasi", value => !string.IsNullOrWhiteSpace(value) && value.Length <= 200 },
            { "Deskripsi", value => !string.IsNullOrWhiteSpace(value) && value.Length <= 500 },
            { "JenisKejadian", value => !string.IsNullOrWhiteSpace(value) && value.Length <= 100 },
            { "TingkatUrgensitas", value => !string.IsNullOrWhiteSpace(value) && value.Length <= 50 }
        };

        private static readonly Dictionary<string, Action<DetailKeamanan, string>> _fieldSetters = new()
        {
            { "NamaPelapor", (detail, value) => detail.NamaPelapor = value },
            { "Lokasi", (detail, value) => detail.Lokasi = value },
            { "Deskripsi", (detail, value) => detail.Deskripsi = value },
            { "JenisKejadian", (detail, value) => detail.JenisKejadian = value },
            { "TingkatUrgensitas", (detail, value) => detail.TingkatUrgensitas = value }
        };

        private static readonly Dictionary<string, Func<DetailKeamanan, string>> _fieldGetters = new()
        {
            { "NamaPelapor", detail => detail.NamaPelapor },
            { "Lokasi", detail => detail.Lokasi },
            { "Deskripsi", detail => detail.Deskripsi },
            { "JenisKejadian", detail => detail.JenisKejadian },
            { "TingkatUrgensitas", detail => detail.TingkatUrgensitas }
        };

        public PengaduanKeamananService()
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string solutionDirectory = Path.GetFullPath(Path.Combine(exeDirectory, "..", "..", "..", ".."));
            _filePath = Path.Combine(solutionDirectory, "App.Core", "Database", "Keamanan.json");

            string? directoryPath = Path.GetDirectoryName(_filePath);
            if (directoryPath != null)
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        public async Task<List<Pengaduan<DetailKeamanan>>> AmbilSemuaPengaduanAsync()
        {
            return await JsonUtils.ReadDataAsync<Pengaduan<DetailKeamanan>>(_filePath);
        }

        public async Task<Pengaduan<DetailKeamanan>?> AmbilPengaduanByIdAsync(string id)
        {
            var semuaPengaduan = await AmbilSemuaPengaduanAsync();
            return semuaPengaduan.FirstOrDefault(p => p.Id == id);
        }

        public async Task UbahStatusAsync(string id, StatusPengaduan statusBaru)
        {
            var semuaPengaduan = await JsonUtils.ReadDataAsync<Pengaduan<DetailKeamanan>>(_filePath);
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
            var semuaPengaduan = await AmbilSemuaPengaduanAsync();
            return semuaPengaduan
                .GroupBy(p => p.Status)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public async Task<int> HitungTotalPengaduanAsync()
        {
            var semuaPengaduan = await AmbilSemuaPengaduanAsync();
            return semuaPengaduan.Count;
        }

        // CREATE - Add new security complaint with table-driven validation
        public async Task<Pengaduan<DetailKeamanan>> TambahPengaduanAsync(
            int userId,
            string namaPelapor,
            string lokasi,
            string deskripsi,
            string jenisKejadian,
            string tingkatUrgensitas)
        {
            // table-driven
            var fieldsToValidate = new Dictionary<string, string>
            {
                { "NamaPelapor", namaPelapor },
                { "Lokasi", lokasi },
                { "Deskripsi", deskripsi },
                { "JenisKejadian", jenisKejadian },
                { "TingkatUrgensitas", tingkatUrgensitas }
            };

            ValidateFields(fieldsToValidate);

            var semuaPengaduan = await JsonUtils.ReadDataAsync<Pengaduan<DetailKeamanan>>(_filePath);
            var detail = new DetailKeamanan(userId, namaPelapor, lokasi, deskripsi, jenisKejadian, tingkatUrgensitas);
            var pengaduanBaru = new Pengaduan<DetailKeamanan>(Guid.NewGuid().ToString(), detail);

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

        // UPDATE - Update security complaint data using table-driven approach
        public async Task UbahDataPengaduanAsync(
            string id,
            int userId,
            string namaPelapor,
            string lokasi,
            string deskripsi,
            string jenisKejadian,
            string tingkatUrgensitas)
        {
            var semuaPengaduan = await JsonUtils.ReadDataAsync<Pengaduan<DetailKeamanan>>(_filePath);
            var pengaduan = semuaPengaduan.FirstOrDefault(p => p.Id == id);
            if (pengaduan == null)
            {
                throw new KeyNotFoundException($"Pengaduan dengan ID {id} tidak ditemukan.");
            }

            var fieldsToValidate = new Dictionary<string, string>
            {
                { "NamaPelapor", namaPelapor },
                { "Lokasi", lokasi },
                { "Deskripsi", deskripsi },
                { "JenisKejadian", jenisKejadian },
                { "TingkatUrgensitas", tingkatUrgensitas }
            };

            ValidateFields(fieldsToValidate);

            try
            {
                // Update fields using table-driven mapping
                pengaduan.Detail.UserId = userId;
                UpdateDetailFields(pengaduan.Detail, fieldsToValidate);
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
            var semuaPengaduan = await JsonUtils.ReadDataAsync<Pengaduan<DetailKeamanan>>(_filePath);
            var pengaduan = semuaPengaduan.FirstOrDefault(p => p.Id == id);
            if (pengaduan == null)
            {
                throw new KeyNotFoundException($"Pengaduan dengan ID {id} tidak ditemukan.");
            }
            semuaPengaduan.Remove(pengaduan);
            await JsonUtils.WriteDataAsync(_filePath, semuaPengaduan);
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
        private void UpdateDetailFields(DetailKeamanan detail, Dictionary<string, string> fields)
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
        public Dictionary<string, string> GetDetailFields(DetailKeamanan detail)
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
