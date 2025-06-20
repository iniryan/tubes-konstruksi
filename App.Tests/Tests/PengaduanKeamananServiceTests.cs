using System;
using Xunit;
using App.Core.Services;
using App.Core.Models;
using System.Threading.Tasks;

namespace App.Tests.Tests
{
    public class PengaduanKeamananServiceTests
    {
        [Fact]
        public async Task Should_Add_New_Pengaduan_Keamanan()
        {
            var service = new PengaduanKeamananService();
            var deskripsi = "Pencurian sepeda motor";
            var lokasi = "Jl. Merdeka No. 5";
            var userId = 1;

            var pengaduan = await service.TambahPengaduanAsync(
                userId,
                "Budi",
                lokasi,
                deskripsi,
                "001",
                "Pencurian"
            );

            Assert.NotNull(pengaduan);
            Assert.Equal(deskripsi, pengaduan.Detail.Deskripsi);
            Assert.Equal(lokasi, pengaduan.Detail.Lokasi);
            Assert.Equal(userId, pengaduan.Detail.UserId);
            Assert.Equal("Pencurian", pengaduan.Detail.JenisKejadian);
            Assert.Equal("001", pengaduan.Detail.RT);
        }
        [Fact]
        public async Task Should_Throw_Exception_When_NamaPelapor_Is_Empty()
        {
            var service = new PengaduanKeamananService();

            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await service.TambahPengaduanAsync(1, "", "Lokasi", "Deskripsi", "001", "Pencurian"));

            Assert.Contains("NamaPelapor", ex.Message);
        }
        [Fact]
        public async Task Should_Throw_Exception_When_JenisKejadian_Is_Empty()
        {
            var service = new PengaduanKeamananService();

            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await service.TambahPengaduanAsync(1, "Budi", "Lokasi", "Deskripsi", "001", ""));

            Assert.Contains("JenisKejadian", ex.Message);
        }
        [Fact]
        public async Task Should_Throw_Exception_When_RT_Is_Empty()
        {
            var service = new PengaduanKeamananService();

            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await service.TambahPengaduanAsync(1, "Budi", "Lokasi", "Deskripsi", "", "Pencurian"));

            Assert.Contains("RT", ex.Message);
        }
        [Fact]
        public async Task Should_Throw_Exception_When_NamaPelapor_Too_Long()
        {
            var service = new PengaduanKeamananService();
            var longName = new string('x', 101); // Exceeds 100 character limit

            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await service.TambahPengaduanAsync(1, longName, "Lokasi", "Deskripsi", "001", "Pencurian"));

            Assert.Contains("NamaPelapor", ex.Message);
        }
        [Fact]
        public async Task Should_Throw_Exception_When_Deskripsi_Too_Long()
        {
            var service = new PengaduanKeamananService();
            var longDescription = new string('x', 501); // Exceeds 500 character limit

            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await service.TambahPengaduanAsync(1, "Budi", "Lokasi", longDescription, "001", "Pencurian"));

            Assert.Contains("Deskripsi", ex.Message);
        }
        [Fact]
        public async Task Should_Return_All_Pengaduan_Keamanan()
        {
            var service = new PengaduanKeamananService();
            await service.TambahPengaduanAsync(1, "Budi", "Jl. Sudirman", "Perampokan", "002", "Perampokan");

            var pengaduanList = await service.AmbilSemuaPengaduanAsync();

            Assert.NotEmpty(pengaduanList);
            Assert.True(pengaduanList.Count >= 1);
        }
        [Fact]
        public async Task Should_Get_Pengaduan_By_Id()
        {
            var service = new PengaduanKeamananService();
            var pengaduan = await service.TambahPengaduanAsync(1, "Sari", "Pasar", "Copet", "003", "Copet");

            var result = await service.AmbilPengaduanByIdAsync(pengaduan.Id);

            Assert.NotNull(result);
            Assert.Equal(pengaduan.Id, result.Id);
            Assert.Equal("Copet", result.Detail.JenisKejadian);
        }
        [Fact]
        public async Task Should_Update_Status_To_Diproses()
        {
            var service = new PengaduanKeamananService();
            var pengaduan = await service.TambahPengaduanAsync(1, "Toni", "Mall", "Kejahatan jalanan", "004", "Kejahatan");

            await service.UbahStatusAsync(pengaduan.Id, StatusPengaduan.Diproses);

            var updatedPengaduan = await service.AmbilPengaduanByIdAsync(pengaduan.Id);
            Assert.Equal(StatusPengaduan.Diproses, updatedPengaduan?.Status);
        }

        [Fact]
        public async Task Should_Throw_Exception_If_Pengaduan_Not_Found_For_Status_Update()
        {
            var service = new PengaduanKeamananService();
            var invalidId = "nonexistent-id";

            var ex = await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
                await service.UbahStatusAsync(invalidId, StatusPengaduan.Diproses));

            Assert.Equal("Pengaduan dengan ID tersebut tidak ditemukan.", ex.Message);
        }
        [Fact]
        public async Task Should_Count_Status_Composition()
        {
            var service = new PengaduanKeamananService();
            await service.TambahPengaduanAsync(1, "User1", "Area 1", "Kejahatan 1", "005", "Pencurian");
            var p2 = await service.TambahPengaduanAsync(2, "User2", "Area 2", "Kejahatan 2", "006", "Perampokan");
            await service.UbahStatusAsync(p2.Id, StatusPengaduan.Diproses);

            var komposisi = await service.HitungKomposisiStatusAsync();

            Assert.True(komposisi.ContainsKey(StatusPengaduan.Dibuat));
            Assert.True(komposisi.ContainsKey(StatusPengaduan.Diproses));
            Assert.True(komposisi[StatusPengaduan.Dibuat] >= 1);
            Assert.True(komposisi[StatusPengaduan.Diproses] >= 1);
        }
        [Fact]
        public async Task Should_Count_Total_Pengaduan()
        {
            var service = new PengaduanKeamananService();
            var initialCount = await service.HitungTotalPengaduanAsync();

            await service.TambahPengaduanAsync(1, "Test User", "Test Area", "Test Kejahatan", "007", "Test");

            var newCount = await service.HitungTotalPengaduanAsync();

            Assert.True(newCount > initialCount);
        }
        [Fact]
        public async Task Should_Generate_Unique_Id_For_Each_Pengaduan()
        {
            var service = new PengaduanKeamananService();
            var p1 = await service.TambahPengaduanAsync(1, "User1", "Lokasi A", "Kejahatan A", "008", "Pencurian");
            var p2 = await service.TambahPengaduanAsync(2, "User2", "Lokasi B", "Kejahatan B", "009", "Perampokan");

            Assert.NotEqual(p1.Id, p2.Id);
        }
        [Fact]
        public async Task Should_Have_Default_Status_Dibuat_When_Added()
        {
            var service = new PengaduanKeamananService();
            var pengaduan = await service.TambahPengaduanAsync(1, "User", "Lokasi", "Deskripsi", "010", "Pencurian");

            Assert.Equal(StatusPengaduan.Dibuat, pengaduan.Status);
        }
    }
}
