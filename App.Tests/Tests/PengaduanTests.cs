using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Models;
using Xunit;

namespace App.Tests.Tests
{
    public class PengaduanTests
    {
        [Fact]
        public void Should_Create_Pengaduan_With_Valid_Inputs()
        {
            var detail = new DetailKebersihan(1, "Joko", "Koridor 1", "Sampah menumpuk di koridor", Prioritas.Tinggi, "Sampah");
            var pengaduan = new Pengaduan<DetailKebersihan>("1", detail);

            Assert.Equal("1", pengaduan.Id);
            Assert.Equal(detail, pengaduan.Detail);
            Assert.Equal(StatusPengaduan.Dibuat, pengaduan.Status);
            Assert.True(pengaduan.TanggalDibuat <= DateTime.Now);
        }
        [Fact]
        public void Should_Proses_Pengaduan_From_Dibuat_To_Diproses()
        {
            var detail = new DetailKebersihan(1, "Sari", "Koridor 2", "Sampah tidak terangkut", Prioritas.Sedang, "Sampah");
            var pengaduan = new Pengaduan<DetailKebersihan>("2", detail);

            pengaduan.UbahStatus(StatusPengaduan.Diproses);

            Assert.Equal(StatusPengaduan.Diproses, pengaduan.Status);
        }

        [Fact]
        public void Should_Throw_Exception_When_Proses_Without_Dibuat_Status()
        {
            var detail = new DetailKebersihan(1, "Budi", "Jalan", "Masalah di jalan", Prioritas.Rendah, "Infrastruktur");
            var pengaduan = new Pengaduan<DetailKebersihan>("3", detail);
            pengaduan.UbahStatus(StatusPengaduan.Diproses);

            var exception = Assert.Throws<InvalidOperationException>(() => pengaduan.UbahStatus(StatusPengaduan.Diproses));
            Assert.Equal("Transisi dari Diproses ke Diproses tidak valid.", exception.Message);
        }

        [Fact]
        public void Should_Selesai_Pengaduan_From_Diproses_To_Selesai()
        {
            var detail = new DetailKebersihan(1, "Ana", "Jalan Utama", "Lampu jalan mati", Prioritas.Tinggi, "Fasilitas");
            var pengaduan = new Pengaduan<DetailKebersihan>("4", detail);
            pengaduan.UbahStatus(StatusPengaduan.Diproses);

            pengaduan.UbahStatus(StatusPengaduan.Selesai);

            Assert.Equal(StatusPengaduan.Selesai, pengaduan.Status);
        }

        [Fact]
        public void Should_Throw_Exception_When_Selesai_Without_Diproses_Status()
        {
            var detail = new DetailKebersihan(1, "Rina", "Jalan", "Jalan berlubang", Prioritas.Sedang, "Infrastruktur");
            var pengaduan = new Pengaduan<DetailKebersihan>("5", detail);

            var exception = Assert.Throws<InvalidOperationException>(() => pengaduan.UbahStatus(StatusPengaduan.Selesai));
            Assert.Equal("Transisi dari Dibuat ke Selesai tidak valid.", exception.Message);
        }

        [Fact]
        public void Should_Tolak_Pengaduan_From_Dibuat_To_Ditolak()
        {
            var detail = new DetailKebersihan(1, "Dedi", "Area Umum", "Kebersihan kurang", Prioritas.Rendah, "Sampah");
            var pengaduan = new Pengaduan<DetailKebersihan>("6", detail);

            pengaduan.UbahStatus(StatusPengaduan.Ditolak);

            Assert.Equal(StatusPengaduan.Ditolak, pengaduan.Status);
        }

        [Fact]
        public void Should_Throw_Exception_When_Tolak_Without_Dibuat_Status()
        {
            var detail = new DetailKebersihan(1, "Toni", "Gedung", "Fasilitas rusak", Prioritas.Tinggi, "Fasilitas");
            var pengaduan = new Pengaduan<DetailKebersihan>("7", detail);
            pengaduan.UbahStatus(StatusPengaduan.Diproses);

            var exception = Assert.Throws<InvalidOperationException>(() => pengaduan.UbahStatus(StatusPengaduan.Ditolak));
            Assert.Equal("Transisi dari Diproses ke Ditolak tidak valid.", exception.Message);
        }

    }
}
