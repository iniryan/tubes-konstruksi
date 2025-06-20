using System;
using Xunit;
using App.Core.Services;
using App.Core.Models;
using System.Threading.Tasks;
using System.Linq;

namespace App.Tests.Tests
{
    public class GuestRepositoryTests
    {
        [Fact]
        public async Task Should_Add_New_Tamu_Successfully()
        {
            var repository = new GuestRepository();
            var userId = 1;
            var namaPelapor = "John Visitor";
            var lokasi = "Lobby Utama";
            var deskripsi = "Kunjungan bisnis";
            var nomorIdentitas = "1234567890123456";
            var tujuan = "Meeting dengan manager";
            var pegawaiTujuan = "Manager Sales";
            var waktuKeluar = DateTime.Now.AddHours(2);

            var pengaduan = await repository.TambahTamuAsync(
                userId, namaPelapor, lokasi, deskripsi, nomorIdentitas, tujuan, pegawaiTujuan, waktuKeluar);

            Assert.NotNull(pengaduan);
            Assert.Equal(namaPelapor, pengaduan.Detail.NamaPelapor);
            Assert.Equal(lokasi, pengaduan.Detail.Lokasi);
            Assert.Equal(deskripsi, pengaduan.Detail.Deskripsi);
            Assert.Equal(nomorIdentitas, pengaduan.Detail.NomorIdentitas);
            Assert.Equal(tujuan, pengaduan.Detail.Tujuan);
            Assert.Equal(pegawaiTujuan, pengaduan.Detail.PegawaiTujuan);
            Assert.Equal(waktuKeluar, pengaduan.Detail.WaktuKeluar);
            Assert.Equal(StatusPengaduan.Dibuat, pengaduan.Status);
        }

        [Fact]
        public async Task Should_Add_Tamu_Without_WaktuKeluar()
        {
            var repository = new GuestRepository();

            var pengaduan = await repository.TambahTamuAsync(
                1, "Jane Visitor", "Reception", "Kunjungan kerja", "9876543210", "Konsultasi", "HR Manager", null);

            Assert.NotNull(pengaduan);
            Assert.Null(pengaduan.Detail.WaktuKeluar);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_NamaPelapor_Is_Empty()
        {
            var repository = new GuestRepository();

            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await repository.TambahTamuAsync(1, "", "Lokasi", "Deskripsi", "1234567890", "Tujuan", "Pegawai", null));

            Assert.Contains("NamaPelapor", ex.Message);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_NamaPelapor_Too_Long()
        {
            var repository = new GuestRepository();
            var longName = new string('x', 101); // Exceeds 100 character limit

            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await repository.TambahTamuAsync(1, longName, "Lokasi", "Deskripsi", "1234567890", "Tujuan", "Pegawai", null));

            Assert.Contains("NamaPelapor", ex.Message);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_NomorIdentitas_Too_Short()
        {
            var repository = new GuestRepository();

            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await repository.TambahTamuAsync(1, "John", "Lokasi", "Deskripsi", "123", "Tujuan", "Pegawai", null));

            Assert.Contains("NomorIdentitas", ex.Message);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_NomorIdentitas_Too_Long()
        {
            var repository = new GuestRepository();
            var longId = new string('1', 21); // Exceeds 20 character limit

            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await repository.TambahTamuAsync(1, "John", "Lokasi", "Deskripsi", longId, "Tujuan", "Pegawai", null));

            Assert.Contains("NomorIdentitas", ex.Message);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Deskripsi_Too_Long()
        {
            var repository = new GuestRepository();
            var longDescription = new string('x', 501); // Exceeds 500 character limit

            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await repository.TambahTamuAsync(1, "John", "Lokasi", longDescription, "1234567890", "Tujuan", "Pegawai", null));

            Assert.Contains("Deskripsi", ex.Message);
        }

        [Fact]
        public async Task Should_Return_All_Tamu()
        {
            var repository = new GuestRepository();
            await repository.TambahTamuAsync(1, "Guest1", "Lobby", "Meeting", "1111111111", "Business", "Manager1", null);

            var tamuList = await repository.AmbilSemuaTamuAsync();

            Assert.NotEmpty(tamuList);
            Assert.True(tamuList.Count >= 1);
        }

        [Fact]
        public async Task Should_Get_Tamu_By_Id()
        {
            var repository = new GuestRepository();
            var pengaduan = await repository.TambahTamuAsync(1, "Guest Test", "Reception", "Test visit", "2222222222", "Testing", "Test Manager", null);

            var result = await repository.AmbilTamuByIdAsync(pengaduan.Id);

            Assert.NotNull(result);
            Assert.Equal(pengaduan.Id, result.Id);
            Assert.Equal("Guest Test", result.Detail.NamaPelapor);
        }

        [Fact]
        public async Task Should_Return_Null_When_Tamu_Not_Found()
        {
            var repository = new GuestRepository();

            var result = await repository.AmbilTamuByIdAsync("nonexistent-id");

            Assert.Null(result);
        }

        [Fact]
        public async Task Should_Update_Status_Successfully()
        {
            var repository = new GuestRepository();
            var pengaduan = await repository.TambahTamuAsync(1, "Status Test", "Lobby", "Test", "3333333333", "Test", "Manager", null);

            await repository.UbahStatusAsync(pengaduan.Id, StatusPengaduan.Diproses);

            var updatedPengaduan = await repository.AmbilTamuByIdAsync(pengaduan.Id);
            Assert.Equal(StatusPengaduan.Diproses, updatedPengaduan?.Status);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Updating_Nonexistent_Status()
        {
            var repository = new GuestRepository();

            var ex = await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
                await repository.UbahStatusAsync("nonexistent-id", StatusPengaduan.Diproses));

            Assert.Equal("Pengaduan dengan ID tersebut tidak ditemukan.", ex.Message);
        }

        [Fact]
        public async Task Should_Set_WaktuKeluar_Successfully()
        {
            var repository = new GuestRepository();
            var pengaduan = await repository.TambahTamuAsync(1, "Exit Test", "Office", "Visit", "4444444444", "Meeting", "Manager", null);
            var waktuKeluar = DateTime.Now.AddHours(1);

            await repository.AturWaktuKeluarAsync(pengaduan.Id, waktuKeluar);

            var updatedPengaduan = await repository.AmbilTamuByIdAsync(pengaduan.Id);
            Assert.Equal(waktuKeluar, updatedPengaduan?.Detail.WaktuKeluar);
        }

        [Fact]
        public async Task Should_Set_WaktuKeluar_To_Now_When_Null()
        {
            var repository = new GuestRepository();
            var pengaduan = await repository.TambahTamuAsync(1, "Auto Exit", "Office", "Visit", "5555555555", "Meeting", "Manager", null);
            var beforeUpdate = DateTime.Now;

            await repository.AturWaktuKeluarAsync(pengaduan.Id);

            var afterUpdate = DateTime.Now;
            var updatedPengaduan = await repository.AmbilTamuByIdAsync(pengaduan.Id);

            Assert.NotNull(updatedPengaduan?.Detail.WaktuKeluar);
            Assert.True(updatedPengaduan.Detail.WaktuKeluar >= beforeUpdate);
            Assert.True(updatedPengaduan.Detail.WaktuKeluar <= afterUpdate);
        }

        [Fact]
        public async Task Should_Update_Detail_Tamu_Successfully()
        {
            var repository = new GuestRepository();
            var pengaduan = await repository.TambahTamuAsync(1, "Update Test", "Old Location", "Old desc", "6666666666", "Old purpose", "Old employee", null);
            var newWaktuKeluar = DateTime.Now.AddHours(3);

            await repository.UbahDetailTamuAsync(
                pengaduan.Id, "New Name", "New Location", "New description", "7777777777", "New purpose", "New employee", newWaktuKeluar);

            var updatedPengaduan = await repository.AmbilTamuByIdAsync(pengaduan.Id);

            Assert.NotNull(updatedPengaduan);
            Assert.Equal("New Name", updatedPengaduan.Detail.NamaPelapor);
            Assert.Equal("New Location", updatedPengaduan.Detail.Lokasi);
            Assert.Equal("New description", updatedPengaduan.Detail.Deskripsi);
            Assert.Equal("7777777777", updatedPengaduan.Detail.NomorIdentitas);
            Assert.Equal("New purpose", updatedPengaduan.Detail.Tujuan);
            Assert.Equal("New employee", updatedPengaduan.Detail.PegawaiTujuan);
            Assert.Equal(newWaktuKeluar, updatedPengaduan.Detail.WaktuKeluar);
        }

        [Fact]
        public async Task Should_Delete_Tamu_Successfully()
        {
            var repository = new GuestRepository();
            var pengaduan = await repository.TambahTamuAsync(1, "Delete Test", "Temp Location", "Temp visit", "8888888888", "Temp purpose", "Temp employee", null);

            await repository.HapusTamuAsync(pengaduan.Id);

            var deletedPengaduan = await repository.AmbilTamuByIdAsync(pengaduan.Id);
            Assert.Null(deletedPengaduan);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Deleting_Nonexistent_Tamu()
        {
            var repository = new GuestRepository();

            var ex = await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
                await repository.HapusTamuAsync("nonexistent-id"));

            Assert.Equal("Pengaduan tidak ditemukan untuk dihapus.", ex.Message);
        }

        [Fact]
        public async Task Should_Count_Status_Composition()
        {
            var repository = new GuestRepository();
            await repository.TambahTamuAsync(1, "Count Test 1", "Location1", "Desc1", "1111111111", "Purpose1", "Employee1", null);
            var p2 = await repository.TambahTamuAsync(2, "Count Test 2", "Location2", "Desc2", "2222222222", "Purpose2", "Employee2", null);
            await repository.UbahStatusAsync(p2.Id, StatusPengaduan.Diproses);

            var komposisi = await repository.HitungKomposisiStatusAsync();

            Assert.True(komposisi.ContainsKey(StatusPengaduan.Dibuat));
            Assert.True(komposisi.ContainsKey(StatusPengaduan.Diproses));
        }

        [Fact]
        public async Task Should_Count_Total_Pengaduan()
        {
            var repository = new GuestRepository();
            var initialCount = await repository.HitungTotalPengaduanAsync();

            await repository.TambahTamuAsync(1, "Total Test", "Location", "Description", "9999999999", "Purpose", "Employee", null);

            var newCount = await repository.HitungTotalPengaduanAsync();
            Assert.True(newCount > initialCount);
        }

        [Fact]
        public async Task Should_Calculate_Statistics_For_Pelapor()
        {
            var repository = new GuestRepository();
            var namaPelapor = $"Stat Test {Guid.NewGuid():N}";

            // Add multiple entries for the same pelapor
            var p1 = await repository.TambahTamuAsync(1, namaPelapor, "Loc1", "Desc1", "1111111111", "Purpose1", "Emp1", null);
            var p2 = await repository.TambahTamuAsync(1, namaPelapor, "Loc2", "Desc2", "2222222222", "Purpose2", "Emp2", null);
            var p3 = await repository.TambahTamuAsync(1, namaPelapor, "Loc3", "Desc3", "3333333333", "Purpose3", "Emp3", null);            // Update statuses
            await repository.UbahStatusAsync(p2.Id, StatusPengaduan.Diproses);
            await repository.UbahStatusAsync(p3.Id, StatusPengaduan.Diproses);
            await repository.UbahStatusAsync(p3.Id, StatusPengaduan.Selesai);

            var (total, diproses, selesai) = await repository.HitungStatistikTamuAsync(namaPelapor);

            Assert.Equal(3, total);
            Assert.Equal(1, diproses);
            Assert.Equal(1, selesai);
        }

        [Fact]
        public async Task Should_Return_Zero_Statistics_For_Empty_Name()
        {
            var repository = new GuestRepository();

            var (total, diproses, selesai) = await repository.HitungStatistikTamuAsync("");

            Assert.Equal(0, total);
            Assert.Equal(0, diproses);
            Assert.Equal(0, selesai);
        }
        [Fact]
        public void Should_Get_Detail_Fields_Using_Table_Driven_Approach()
        {
            var repository = new GuestRepository();
            var detail = new DetailTamu(1, "Test User", "Test Location", "Test Description", "1234567890", "Test Purpose", "Test Employee");

            var fields = repository.GetDetailFields(detail);

            Assert.Equal("Test User", fields["NamaPelapor"]);
            Assert.Equal("Test Location", fields["Lokasi"]);
            Assert.Equal("Test Description", fields["Deskripsi"]);
            Assert.Equal("1234567890", fields["NomorIdentitas"]);
            Assert.Equal("Test Purpose", fields["Tujuan"]);
            Assert.Equal("Test Employee", fields["PegawaiTujuan"]);
        }
    }
}
