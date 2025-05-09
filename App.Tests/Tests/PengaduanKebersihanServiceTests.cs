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
            // Arrange
            var service = new PengaduanKebersihanService();
            var masalah = "Sampah tidak diangkut";
            var lokasi = "Koridor 1";

            // Act
            var pengaduan = service.TambahPengaduan(masalah, lokasi);

            // Assert
            Assert.NotNull(pengaduan);
            Assert.Equal(masalah, pengaduan.Detail.Masalah);
            Assert.Equal(lokasi, pengaduan.Detail.Lokasi);
        }

        [Fact]
        public void Should_Throw_Exception_When_Adding_Empty_Masalah()
        {
            // Arrange
            var service = new PengaduanKebersihanService();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => service.TambahPengaduan("", "Lokasi A"));
            Assert.Equal("Masalah harus diisi", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Adding_Empty_Lokasi()
        {
            // Arrange
            var service = new PengaduanKebersihanService();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => service.TambahPengaduan("Masalah A", ""));
            Assert.Equal("Lokasi harus diisi", exception.Message);
        }

        [Fact]
        public void Should_Return_All_Pengaduan()
        {
            // Arrange
            var service = new PengaduanKebersihanService();
            service.TambahPengaduan("Sampah menumpuk", "Koridor 2");

            // Act
            var pengaduanList = service.AmbilSemuaPengaduan();

            // Assert
            Assert.NotEmpty(pengaduanList);
            Assert.Single(pengaduanList);
        }
        [Fact]
        public void Should_Update_Status_To_Diproses()
        {
            // Arrange
            var service = new PengaduanKebersihanService();
            var pengaduan = service.TambahPengaduan("Sampah berserakan", "Halaman");

            // Act
            service.UbahStatus(pengaduan.Id, StatusPengaduan.Diproses);

            // Assert
            Assert.Equal(StatusPengaduan.Diproses, pengaduan.Status);
        }

        [Fact]
        public void Should_Update_Status_To_Selesai_From_Diproses()
        {
            // Arrange
            var service = new PengaduanKebersihanService();
            var pengaduan = service.TambahPengaduan("Sampah belum diangkut", "Lorong");
            service.UbahStatus(pengaduan.Id, StatusPengaduan.Diproses);

            // Act
            service.UbahStatus(pengaduan.Id, StatusPengaduan.Selesai);

            // Assert
            Assert.Equal(StatusPengaduan.Selesai, pengaduan.Status);
        }

        [Fact]
        public void Should_Update_Status_To_Ditolak_From_Dibuat()
        {
            // Arrange
            var service = new PengaduanKebersihanService();
            var pengaduan = service.TambahPengaduan("Pengaduan tidak relevan", "Tempat Sampah");

            // Act
            service.UbahStatus(pengaduan.Id, StatusPengaduan.Ditolak);

            // Assert
            Assert.Equal(StatusPengaduan.Ditolak, pengaduan.Status);
        }

        [Fact]
        public void Should_Throw_Exception_If_Transition_Invalid()
        {
            // Arrange
            var service = new PengaduanKebersihanService();
            var pengaduan = service.TambahPengaduan("Sampah banyak", "Area Belakang");

            // Ubah ke Diproses dulu
            service.UbahStatus(pengaduan.Id, StatusPengaduan.Diproses);

            // Act & Assert: langsung dari Diproses ke Ditolak tidak valid
            var ex = Assert.Throws<InvalidOperationException>(() =>
                service.UbahStatus(pengaduan.Id, StatusPengaduan.Ditolak));

            Assert.Equal("Transisi status dari Diproses ke Ditolak tidak valid.", ex.Message);
        }

        [Fact]
        public void Should_Throw_Exception_If_Pengaduan_Not_Found()
        {
            // Arrange
            var service = new PengaduanKebersihanService();
            var invalidId = "nonexistent-id";

            // Act & Assert
            var ex = Assert.Throws<KeyNotFoundException>(() =>
                service.UbahStatus(invalidId, StatusPengaduan.Diproses));

            Assert.Equal("Pengaduan tidak ditemukan.", ex.Message);
        }
    }
}
