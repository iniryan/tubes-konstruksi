using System;
using Xunit;
using App.Core.Services;
using App.Core.Models;

namespace App.Tests.Tests
{
    public class PengaduanKebersihanServiceTests
    {
        [Fact]
        public void Should_Add_New_Pengaduan()
        {
            var service = new PengaduanKebersihanService();
            var masalah = "Sampah tidak diangkut";
            var lokasi = "Koridor 1";

            var pengaduan = service.TambahPengaduan(
                "Joko",
                masalah,
                lokasi,
                Prioritas.Tinggi,
                "Kebersihan"
            );

            Assert.NotNull(pengaduan);
            Assert.Equal(masalah, pengaduan.Detail.Masalah);
            Assert.Equal(lokasi, pengaduan.Detail.Lokasi);
        }

        [Fact]
        public void Should_Throw_Exception_When_NamaPelapor_Is_Empty()
        {
            var service = new PengaduanKebersihanService();

            var ex = Assert.Throws<ArgumentException>(() =>
                service.TambahPengaduan("", "Masalah", "Lokasi", Prioritas.Sedang, "Kebersihan"));

            Assert.Equal("Nama pelapor harus diisi", ex.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Adding_Empty_Masalah()
        {
            var service = new PengaduanKebersihanService();
            var exception = Assert.Throws<ArgumentException>(() =>
                service.TambahPengaduan("Joko", "", "Lokasi A", Prioritas.Sedang, "Kebersihan"));

            Assert.Equal("Masalah harus diisi", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Adding_Empty_Lokasi()
        {
            var service = new PengaduanKebersihanService();
            var exception = Assert.Throws<ArgumentException>(() =>
                service.TambahPengaduan("Joko", "Masalah A", "", Prioritas.Rendah, "Kebersihan"));

            Assert.Equal("Lokasi harus diisi", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Kategori_Is_Empty()
        {
            var service = new PengaduanKebersihanService();

            var ex = Assert.Throws<ArgumentException>(() =>
                service.TambahPengaduan("Joko", "Masalah", "Lokasi", Prioritas.Sedang, ""));

            Assert.Equal("Kategori harus diisi", ex.Message);
        }

        [Fact]
        public void Should_Return_All_Added_Pengaduan()
        {
            var service = new PengaduanKebersihanService();
            service.TambahPengaduan("Joko", "Masalah A", "Lokasi A", Prioritas.Sedang, "Kebersihan");
            service.TambahPengaduan("Sari", "Masalah B", "Lokasi B", Prioritas.Rendah, "Kebersihan");

            var all = service.AmbilSemuaPengaduan();

            Assert.Equal(2, all.Count);
        }

        [Fact]
        public void Should_Return_All_Pengaduan()
        {
            var service = new PengaduanKebersihanService();
            service.TambahPengaduan("Joko", "Sampah menumpuk", "Koridor 2", Prioritas.Tinggi, "Kebersihan");

            var pengaduanList = service.AmbilSemuaPengaduan();

            Assert.NotEmpty(pengaduanList);
            Assert.Single(pengaduanList);
        }

        [Fact]
        public void Should_Have_Default_Status_Dibuat_When_Added()
        {
            var service = new PengaduanKebersihanService();
            var pengaduan = service.TambahPengaduan("Joko", "Masalah", "Lokasi", Prioritas.Tinggi, "Kebersihan");

            Assert.Equal(StatusPengaduan.Dibuat, pengaduan.Status);
        }

        [Fact]
        public void Should_Update_Status_To_Diproses()
        {
            var service = new PengaduanKebersihanService();
            var pengaduan = service.TambahPengaduan("Joko", "Sampah berserakan", "Halaman", Prioritas.Sedang, "Kebersihan");

            service.UbahStatus(pengaduan.Id, StatusPengaduan.Diproses);

            Assert.Equal(StatusPengaduan.Diproses, pengaduan.Status);
        }

        [Fact]
        public void Should_Update_Status_To_Selesai_From_Diproses()
        {
            var service = new PengaduanKebersihanService();
            var pengaduan = service.TambahPengaduan("Joko", "Sampah belum diangkut", "Lorong", Prioritas.Sedang, "Kebersihan");
            service.UbahStatus(pengaduan.Id, StatusPengaduan.Diproses);

            service.UbahStatus(pengaduan.Id, StatusPengaduan.Selesai);

            Assert.Equal(StatusPengaduan.Selesai, pengaduan.Status);
        }

        [Fact]
        public void Should_Update_Status_To_Ditolak_From_Dibuat()
        {
            var service = new PengaduanKebersihanService();
            var pengaduan = service.TambahPengaduan("Joko", "Pengaduan tidak relevan", "Tempat Sampah", Prioritas.Rendah, "Kebersihan");

            service.UbahStatus(pengaduan.Id, StatusPengaduan.Ditolak);

            Assert.Equal(StatusPengaduan.Ditolak, pengaduan.Status);
        }

        [Fact]
        public void Should_Throw_Exception_If_Transition_Invalid()
        {
            var service = new PengaduanKebersihanService();
            var pengaduan = service.TambahPengaduan("Joko", "Sampah banyak", "Area Belakang", Prioritas.Sedang, "Kebersihan");
            service.UbahStatus(pengaduan.Id, StatusPengaduan.Diproses);

            var ex = Assert.Throws<InvalidOperationException>(() =>
                service.UbahStatus(pengaduan.Id, StatusPengaduan.Ditolak));

            Assert.Equal("Transisi status dari Diproses ke Ditolak tidak valid.", ex.Message);
        }

        [Fact]
        public void Should_Throw_Exception_If_Pengaduan_Not_Found()
        {
            var service = new PengaduanKebersihanService();
            var invalidId = "nonexistent-id";

            var ex = Assert.Throws<KeyNotFoundException>(() =>
                service.UbahStatus(invalidId, StatusPengaduan.Diproses));

            Assert.Equal("Pengaduan tidak ditemukan.", ex.Message);
        }

        [Fact]
        public void Should_Delete_Pengaduan_By_Id()
        {
            var service = new PengaduanKebersihanService();
            var pengaduan = service.TambahPengaduan("Joko", "Sampah di tangga", "Tangga", Prioritas.Tinggi, "Kebersihan");

            service.HapusPengaduan(pengaduan.Id);

            var ex = Assert.Throws<KeyNotFoundException>(() =>
                service.UbahStatus(pengaduan.Id, StatusPengaduan.Diproses));

            Assert.Equal("Pengaduan tidak ditemukan.", ex.Message);
        }

        [Fact]
        public void Should_Get_Pengaduan_By_Id()
        {
            var service = new PengaduanKebersihanService();
            var pengaduan = service.TambahPengaduan("Joko", "Tumpukan sampah", "Lobby", Prioritas.Sedang, "Kebersihan");

            var result = service.AmbilPengaduanById(pengaduan.Id);

            Assert.NotNull(result);
            Assert.Equal(pengaduan.Id, result.Id);
        }

        [Fact]
        public void Should_Generate_Unique_Id_For_Each_Pengaduan()
        {
            var service = new PengaduanKebersihanService();
            var p1 = service.TambahPengaduan("Joko", "Masalah A", "Lokasi A", Prioritas.Tinggi, "Kebersihan");
            var p2 = service.TambahPengaduan("Sari", "Masalah B", "Lokasi B", Prioritas.Rendah, "Kebersihan");

            Assert.NotEqual(p1.Id, p2.Id);
        }

    }
}
