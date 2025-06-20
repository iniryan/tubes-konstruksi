using System;
using System.IO;
using Xunit;
using App.Core.Services;
using App.Core.Models;
using System.Threading.Tasks;

namespace App.Tests.Tests
{
    public class PengaduanFasilitasServiceTests : IDisposable
    {
        private readonly string _configPath;
        private readonly string? _originalConfig;

        public PengaduanFasilitasServiceTests()
        {
            // Setup configuration file for tests
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string solutionDirectory = Path.GetFullPath(Path.Combine(exeDirectory, "..", "..", "..", ".."));
            string configDirectory = Path.Combine(solutionDirectory, "App.Core", "Database");
            _configPath = Path.Combine(configDirectory, "config.json");

            Directory.CreateDirectory(configDirectory);

            // Backup original config if exists
            if (File.Exists(_configPath))
            {
                _originalConfig = File.ReadAllText(_configPath);
            }

            // Create test config
            var testConfig = @"{
                ""AllowedTypes"": [""AC"", ""Proyektor"", ""WiFi"", ""Toilet"", ""Lampu""],
                ""MaxDescriptionLength"": 500
            }";
            File.WriteAllText(_configPath, testConfig);
        }

        public void Dispose()
        {
            // Restore original config or delete test config
            if (!string.IsNullOrEmpty(_originalConfig))
            {
                File.WriteAllText(_configPath, _originalConfig);
            }
            else if (File.Exists(_configPath))
            {
                File.Delete(_configPath);
            }
        }

        [Fact]
        public async Task Should_Add_New_Pengaduan_Fasilitas()
        {
            var service = new PengaduanFasilitasService();
            var deskripsi = "AC tidak dingin";
            var lokasi = "Ruang 101";
            var userId = 1;

            var pengaduan = await service.TambahPengaduanAsync(
                userId,
                "Sari",
                lokasi,
                deskripsi,
                Prioritas.Tinggi,
                "AC"
            );

            Assert.NotNull(pengaduan);
            Assert.Equal(deskripsi, pengaduan.Detail.Deskripsi);
            Assert.Equal(lokasi, pengaduan.Detail.Lokasi);
            Assert.Equal(userId, pengaduan.Detail.UserId);
            Assert.Equal("AC", pengaduan.Detail.JenisFasilitas);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_NamaPelapor_Is_Empty()
        {
            var service = new PengaduanFasilitasService();

            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await service.TambahPengaduanAsync(1, "", "Lokasi", "Deskripsi", Prioritas.Sedang, "AC"));

            Assert.Equal("Nama pelapor tidak boleh kosong. (Parameter 'namaPelapor')", ex.Message);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_JenisFasilitas_Is_Invalid()
        {
            var service = new PengaduanFasilitasService();

            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await service.TambahPengaduanAsync(1, "Sari", "Lokasi", "Deskripsi", Prioritas.Sedang, "InvalidType"));

            Assert.Contains("tidak valid", ex.Message);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Description_Too_Long()
        {
            var service = new PengaduanFasilitasService();
            var longDescription = new string('x', 501); // Exceeds 500 character limit

            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await service.TambahPengaduanAsync(1, "Sari", "Lokasi", longDescription, Prioritas.Sedang, "AC"));

            Assert.Contains("terlalu panjang", ex.Message);
        }

        [Fact]
        public async Task Should_Return_All_Pengaduan_Fasilitas()
        {
            var service = new PengaduanFasilitasService();
            await service.TambahPengaduanAsync(1, "Sari", "Ruang 1", "AC rusak", Prioritas.Tinggi, "AC");

            var pengaduanList = await service.AmbilSemuaPengaduanAsync();

            Assert.NotEmpty(pengaduanList);
            Assert.True(pengaduanList.Count >= 1);
        }

        [Fact]
        public async Task Should_Update_Status_To_Diproses()
        {
            var service = new PengaduanFasilitasService();
            var pengaduan = await service.TambahPengaduanAsync(1, "Sari", "Lab", "Proyektor tidak menyala", Prioritas.Sedang, "Proyektor");

            await service.UbahStatusAsync(pengaduan.Id, StatusPengaduan.Diproses);

            var updatedPengaduan = await service.AmbilPengaduanByIdAsync(pengaduan.Id);
            Assert.Equal(StatusPengaduan.Diproses, updatedPengaduan?.Status);
        }

        [Fact]
        public async Task Should_Update_Data_Pengaduan()
        {
            var service = new PengaduanFasilitasService();
            var pengaduan = await service.TambahPengaduanAsync(1, "Sari", "Ruang 1", "AC rusak", Prioritas.Tinggi, "AC");

            await service.UbahDataPengaduanAsync(pengaduan.Id, 2, "Budi", "Ruang 2", "AC mati total", Prioritas.Sedang, "AC");

            var updatedPengaduan = await service.AmbilPengaduanByIdAsync(pengaduan.Id);

            Assert.NotNull(updatedPengaduan);
            Assert.Equal(2, updatedPengaduan.Detail.UserId);
            Assert.Equal("Budi", updatedPengaduan.Detail.NamaPelapor);
            Assert.Equal("AC mati total", updatedPengaduan.Detail.Deskripsi);
            Assert.Equal("Ruang 2", updatedPengaduan.Detail.Lokasi);
            Assert.Equal(Prioritas.Sedang, updatedPengaduan.Detail.PrioritasPengaduan);
        }

        [Fact]
        public async Task Should_Delete_Pengaduan_By_Id()
        {
            var service = new PengaduanFasilitasService();
            var pengaduan = await service.TambahPengaduanAsync(1, "Sari", "Aula", "WiFi tidak connect", Prioritas.Tinggi, "WiFi");

            await service.HapusPengaduanAsync(pengaduan.Id);

            var ex = await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
                await service.UbahStatusAsync(pengaduan.Id, StatusPengaduan.Diproses));

            Assert.Contains("tidak ditemukan", ex.Message);
        }

        [Fact]
        public async Task Should_Count_Total_Pengaduan()
        {
            var service = new PengaduanFasilitasService();
            var initialCount = await service.HitungTotalPengaduanAsync();

            await service.TambahPengaduanAsync(1, "Test", "Test Area", "Test Deskripsi", Prioritas.Rendah, "Lampu");

            var newCount = await service.HitungTotalPengaduanAsync();

            Assert.True(newCount > initialCount);
        }

        [Fact]
        public async Task Should_Count_Status_Composition()
        {
            var service = new PengaduanFasilitasService();
            await service.TambahPengaduanAsync(1, "Test1", "Area 1", "Deskripsi 1", Prioritas.Tinggi, "Toilet");
            var p2 = await service.TambahPengaduanAsync(2, "Test2", "Area 2", "Deskripsi 2", Prioritas.Sedang, "Toilet");
            await service.UbahStatusAsync(p2.Id, StatusPengaduan.Diproses);

            var komposisi = await service.HitungKomposisiStatusAsync();

            Assert.True(komposisi.ContainsKey(StatusPengaduan.Dibuat));
            Assert.True(komposisi.ContainsKey(StatusPengaduan.Diproses));
        }
    }
}
