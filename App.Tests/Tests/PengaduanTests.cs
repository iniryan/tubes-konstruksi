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
            var detail = "Sampah menumpuk di koridor";
            var pengaduan = new Pengaduan<string>("1", detail);

            Assert.Equal("1", pengaduan.Id);
            Assert.Equal(detail, pengaduan.Detail);
            Assert.Equal(StatusPengaduan.Dibuat, pengaduan.Status);
        }

        [Fact]
        public void Should_Proses_Pengaduan_From_Dibuat_To_Diproses()
        {
            var pengaduan = new Pengaduan<string>("2", "Sampah tidak terangkut");

            pengaduan.Proses();

            Assert.Equal(StatusPengaduan.Diproses, pengaduan.Status);
        }

        [Fact]
        public void Should_Throw_Exception_When_Proses_Without_Dibuat_Status()
        {
            var pengaduan = new Pengaduan<string>("3", "Masalah di jalan");
            pengaduan.Proses();

            var exception = Assert.Throws<InvalidOperationException>(() => pengaduan.Proses());
            Assert.Equal("Transisi status dari Diproses ke Diproses tidak valid.", exception.Message);
            
        }

        [Fact]
        public void Should_Selesai_Pengaduan_From_Diproses_To_Selesai()
        {
            var pengaduan = new Pengaduan<string>("4", "Lampu jalan mati");
            pengaduan.Proses(); // Status harus Diproses dulu

            pengaduan.Selesai();

            Assert.Equal(StatusPengaduan.Selesai, pengaduan.Status);
        }

        [Fact]
        public void Should_Throw_Exception_When_Selesai_Without_Diproses_Status()
        {
            var pengaduan = new Pengaduan<string>("5", "Jalan berlubang");

            var exception = Assert.Throws<InvalidOperationException>(() => pengaduan.Selesai());
            Assert.Equal("Transisi status dari Dibuat ke Selesai tidak valid.", exception.Message);
        }

        [Fact]
        public void Should_Tolak_Pengaduan_From_Dibuat_To_Ditolak()
        {
            var pengaduan = new Pengaduan<string>("6", "Kebersihan kurang");

            pengaduan.Tolak();

            Assert.Equal(StatusPengaduan.Ditolak, pengaduan.Status);
        }

        [Fact]
        public void Should_Throw_Exception_When_Tolak_Without_Dibuat_Status()
        {
            var pengaduan = new Pengaduan<string>("7", "Fasilitas rusak");
            pengaduan.Proses(); // Status diubah jadi Diproses

            var exception = Assert.Throws<InvalidOperationException>(() => pengaduan.Tolak());
            Assert.Equal("Transisi status dari Diproses ke Ditolak tidak valid.", exception.Message);
        }
    }
}
