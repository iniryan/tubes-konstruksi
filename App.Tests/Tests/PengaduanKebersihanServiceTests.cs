using System;
using Xunit;
using App.Core.Services;
using App.Core.Models;
using System.Threading.Tasks;

namespace App.Tests.Tests
{
    public class PengaduanKebersihanServiceTests
    {
        [Fact]
        public async Task Should_Add_New_Pengaduan()
        {
            var service = new PengaduanKebersihanService();
            var deskripsi = "Sampah tidak diangkut";
            var lokasi = "Koridor 1";
            var userId = 1;

            var pengaduan = await service.TambahPengaduanAsync(
                userId,
                "Joko",
                lokasi,
                deskripsi,
                Prioritas.Tinggi,
                "Sampah"
            );

            Assert.NotNull(pengaduan);
            Assert.Equal(deskripsi, pengaduan.Detail.Deskripsi);
            Assert.Equal(lokasi, pengaduan.Detail.Lokasi);
            Assert.Equal(userId, pengaduan.Detail.UserId);
        }
        [Fact]
        public async Task Should_Throw_Exception_When_NamaPelapor_Is_Empty()
        {
            var service = new PengaduanKebersihanService();

            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await service.TambahPengaduanAsync(1, "", "Lokasi", "Deskripsi", Prioritas.Sedang, "Sampah"));

            Assert.Equal("Nama pelapor tidak boleh kosong. (Parameter 'namaPelapor')", ex.Message);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Adding_Empty_Deskripsi()
        {
            var service = new PengaduanKebersihanService();
            var exception = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await service.TambahPengaduanAsync(1, "Joko", "Lokasi A", "", Prioritas.Sedang, "Sampah"));

            Assert.Equal("Deskripsi tidak boleh kosong. (Parameter 'deskripsi')", exception.Message);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Adding_Empty_Lokasi()
        {
            var service = new PengaduanKebersihanService();
            var exception = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await service.TambahPengaduanAsync(1, "Joko", "", "Deskripsi A", Prioritas.Rendah, "Sampah"));

            Assert.Equal("Lokasi tidak boleh kosong. (Parameter 'lokasi')", exception.Message);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Kategori_Is_Empty()
        {
            var service = new PengaduanKebersihanService();

            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await service.TambahPengaduanAsync(1, "Joko", "Lokasi", "Deskripsi", Prioritas.Sedang, ""));

            Assert.Equal("Kategori harus diisi. (Parameter 'kategori')", ex.Message);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_UserId_Is_Invalid()
        {
            var service = new PengaduanKebersihanService();

            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await service.TambahPengaduanAsync(0, "Joko", "Lokasi", "Deskripsi", Prioritas.Sedang, "Sampah"));

            Assert.Equal("User ID harus lebih besar dari 0. (Parameter 'userId')", ex.Message);
        }
        [Fact]
        public async Task Should_Return_All_Added_Pengaduan()
        {
            var service = new PengaduanKebersihanService();
            await service.TambahPengaduanAsync(1, "Joko", "Lokasi A", "Deskripsi A", Prioritas.Sedang, "Sampah");
            await service.TambahPengaduanAsync(2, "Sari", "Lokasi B", "Deskripsi B", Prioritas.Rendah, "Sampah");

            var all = await service.AmbilSemuaPengaduanAsync();

            Assert.True(all.Count >= 2);
        }

        [Fact]
        public async Task Should_Return_All_Pengaduan()
        {
            var service = new PengaduanKebersihanService();
            await service.TambahPengaduanAsync(1, "Joko", "Koridor 2", "Sampah menumpuk", Prioritas.Tinggi, "Sampah");

            var pengaduanList = await service.AmbilSemuaPengaduanAsync();

            Assert.NotEmpty(pengaduanList);
            Assert.True(pengaduanList.Count >= 1);
        }
        [Fact]
        public async Task Should_Have_Default_Status_Dibuat_When_Added()
        {
            var service = new PengaduanKebersihanService();
            var pengaduan = await service.TambahPengaduanAsync(1, "Joko", "Lokasi", "Deskripsi", Prioritas.Tinggi, "Sampah");

            Assert.Equal(StatusPengaduan.Dibuat, pengaduan.Status);
        }

        [Fact]
        public async Task Should_Update_Status_To_Diproses()
        {
            var service = new PengaduanKebersihanService();
            var pengaduan = await service.TambahPengaduanAsync(1, "Joko", "Halaman", "Sampah berserakan", Prioritas.Sedang, "Sampah");

            await service.UbahStatusAsync(pengaduan.Id, StatusPengaduan.Diproses);

            var updatedPengaduan = await service.AmbilPengaduanByIdAsync(pengaduan.Id);
            Assert.Equal(StatusPengaduan.Diproses, updatedPengaduan?.Status);
        }

        [Fact]
        public async Task Should_Update_Status_To_Selesai_From_Diproses()
        {
            var service = new PengaduanKebersihanService();
            var pengaduan = await service.TambahPengaduanAsync(1, "Joko", "Lorong", "Sampah belum diangkut", Prioritas.Sedang, "Sampah");
            await service.UbahStatusAsync(pengaduan.Id, StatusPengaduan.Diproses);

            await service.UbahStatusAsync(pengaduan.Id, StatusPengaduan.Selesai);

            var updatedPengaduan = await service.AmbilPengaduanByIdAsync(pengaduan.Id);
            Assert.Equal(StatusPengaduan.Selesai, updatedPengaduan?.Status);
        }

        [Fact]
        public async Task Should_Update_Status_To_Ditolak_From_Dibuat()
        {
            var service = new PengaduanKebersihanService();
            var pengaduan = await service.TambahPengaduanAsync(1, "Joko", "Tempat Sampah", "Pengaduan tidak relevan", Prioritas.Rendah, "Sampah");

            await service.UbahStatusAsync(pengaduan.Id, StatusPengaduan.Ditolak);

            var updatedPengaduan = await service.AmbilPengaduanByIdAsync(pengaduan.Id);
            Assert.Equal(StatusPengaduan.Ditolak, updatedPengaduan?.Status);
        }
        [Fact]
        public async Task Should_Throw_Exception_If_Transition_Invalid()
        {
            var service = new PengaduanKebersihanService();
            var pengaduan = await service.TambahPengaduanAsync(1, "Joko", "Area Belakang", "Sampah banyak", Prioritas.Sedang, "Sampah");
            await service.UbahStatusAsync(pengaduan.Id, StatusPengaduan.Diproses);

            var ex = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await service.UbahStatusAsync(pengaduan.Id, StatusPengaduan.Ditolak));

            Assert.Equal("Transisi dari Diproses ke Ditolak tidak valid.", ex.Message);
        }

        [Fact]
        public async Task Should_Throw_Exception_If_Pengaduan_Not_Found()
        {
            var service = new PengaduanKebersihanService();
            var invalidId = "nonexistent-id";

            var ex = await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
                await service.UbahStatusAsync(invalidId, StatusPengaduan.Diproses));

            Assert.Equal("Pengaduan dengan ID tersebut tidak ditemukan.", ex.Message);
        }

        [Fact]
        public async Task Should_Delete_Pengaduan_By_Id()
        {
            var service = new PengaduanKebersihanService();
            var pengaduan = await service.TambahPengaduanAsync(1, "Joko", "Tangga", "Sampah di tangga", Prioritas.Tinggi, "Sampah");

            await service.HapusPengaduanAsync(pengaduan.Id);

            var ex = await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
                await service.UbahStatusAsync(pengaduan.Id, StatusPengaduan.Diproses));

            Assert.Equal("Pengaduan dengan ID tersebut tidak ditemukan.", ex.Message);
        }

        [Fact]
        public async Task Should_Get_Pengaduan_By_Id()
        {
            var service = new PengaduanKebersihanService();
            var pengaduan = await service.TambahPengaduanAsync(1, "Joko", "Lobby", "Tumpukan sampah", Prioritas.Sedang, "Sampah");

            var result = await service.AmbilPengaduanByIdAsync(pengaduan.Id);

            Assert.NotNull(result);
            Assert.Equal(pengaduan.Id, result.Id);
        }
        [Fact]
        public async Task Should_Generate_Unique_Id_For_Each_Pengaduan()
        {
            var service = new PengaduanKebersihanService();
            var p1 = await service.TambahPengaduanAsync(1, "Joko", "Lokasi A", "Deskripsi A", Prioritas.Tinggi, "Sampah");
            var p2 = await service.TambahPengaduanAsync(2, "Sari", "Lokasi B", "Deskripsi B", Prioritas.Rendah, "Sampah");

            Assert.NotEqual(p1.Id, p2.Id);
        }

        [Fact]
        public async Task Should_Update_Data_Pengaduan()
        {
            var service = new PengaduanKebersihanService();
            var pengaduan = await service.TambahPengaduanAsync(1, "Joko", "Koridor 3", "Sampah menumpuk", Prioritas.Tinggi, "Sampah");

            await service.UbahDataPengaduanAsync(pengaduan.Id, 2, "Sari", "Koridor 4", "Sampah bertumpuk", Prioritas.Sedang, "Sampah");

            var updatedPengaduan = await service.AmbilPengaduanByIdAsync(pengaduan.Id);

            Assert.NotNull(updatedPengaduan);
            Assert.Equal(2, updatedPengaduan.Detail.UserId);
            Assert.Equal("Sari", updatedPengaduan.Detail.NamaPelapor);
            Assert.Equal("Sampah bertumpuk", updatedPengaduan.Detail.Deskripsi);
            Assert.Equal("Koridor 4", updatedPengaduan.Detail.Lokasi);
            Assert.Equal(Prioritas.Sedang, updatedPengaduan.Detail.PrioritasPengaduan);
            Assert.Equal("Sampah", updatedPengaduan.Detail.Kategori);
        }

        [Fact]
        public async Task Should_Count_Status_Composition()
        {
            var service = new PengaduanKebersihanService();
            await service.TambahPengaduanAsync(1, "Joko", "Area 1", "Deskripsi 1", Prioritas.Tinggi, "Sampah");
            var p2 = await service.TambahPengaduanAsync(2, "Sari", "Area 2", "Deskripsi 2", Prioritas.Sedang, "Sampah");
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
            var service = new PengaduanKebersihanService();
            var initialCount = await service.HitungTotalPengaduanAsync();

            await service.TambahPengaduanAsync(1, "Joko", "Area Test", "Test Deskripsi", Prioritas.Rendah, "Sampah");

            var newCount = await service.HitungTotalPengaduanAsync();

            Assert.True(newCount > initialCount);
        }

    }
}
