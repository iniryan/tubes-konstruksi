using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Models;

namespace App.Tests.Tests
{
    public class PengaduanTests
    {
        [Fact]
        public void Should_Create_Pengaduan_With_Valid_Inputs()
        {
            // Arrange
            var detail = "Sampah menumpuk di koridor";
            var pengaduan = new Pengaduan<string>("1", detail);

            // Assert
            Assert.Equal("1", pengaduan.Id);
            Assert.Equal(detail, pengaduan.Detail);
            Assert.Equal(StatusPengaduan.Dibuat, pengaduan.Status);
        }

        [Fact]
        public void Should_Proses_Pengaduan_From_Dibuat_To_Diproses()
        {
            // Arrange
            var pengaduan = new Pengaduan<string>("2", "Sampah tidak terangkut");

            // Act
            pengaduan.Proses();

            // Assert
            Assert.Equal(StatusPengaduan.Diproses, pengaduan.Status);
        }

        [Fact]
        public void Should_Throw_Exception_When_Proses_Without_Dibuat_Status()
        {
            // Arrange
            var pengaduan = new Pengaduan<string>("3", "Masalah di jalan");

            // Act & Assert
            pengaduan.Proses();
            var exception = Assert.Throws<InvalidOperationException>(() => pengaduan.Proses());
            Assert.Equal("Transisi status dari Diproses ke Diproses tidak valid.", exception.Message);
        }

        [Fact]
        public void Should_Selesai_Pengaduan_From_Diproses_To_Selesai()
        {
            // Arrange
            var pengaduan = new Pengaduan<string>("4", "Lampu jalan mati");
            pengaduan.Proses(); // Status harus Diproses dulu

            // Act
            pengaduan.Selesai();

            // Assert
            Assert.Equal(StatusPengaduan.Selesai, pengaduan.Status);
        }

        [Fact]
        public void Should_Throw_Exception_When_Selesai_Without_Diproses_Status()
        {
            // Arrange
            var pengaduan = new Pengaduan<string>("5", "Jalan berlubang");

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => pengaduan.Selesai());
            Assert.Equal("Transisi status dari Dibuat ke Selesai tidak valid.", exception.Message);
        }

        [Fact]
        public void Should_Tolak_Pengaduan_From_Dibuat_To_Ditolak()
        {
            // Arrange
            var pengaduan = new Pengaduan<string>("6", "Kebersihan kurang");

            // Act
            pengaduan.Tolak();

            // Assert
            Assert.Equal(StatusPengaduan.Ditolak, pengaduan.Status);
        }

        [Fact]
        public void Should_Throw_Exception_When_Tolak_Without_Dibuat_Status()
        {
            // Arrange
            var pengaduan = new Pengaduan<string>("7", "Fasilitas rusak");
            pengaduan.Proses(); // Status diubah jadi Diproses

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => pengaduan.Tolak());
            Assert.Equal("Transisi status dari Diproses ke Ditolak tidak valid.", exception.Message);
        }
    }
}
