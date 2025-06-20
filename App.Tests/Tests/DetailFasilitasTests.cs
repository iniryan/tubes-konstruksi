using System;
using Xunit;
using App.Core.Models;

namespace App.Tests.Tests
{
    public class DetailFasilitasTests
    {
        [Fact]
        public void Should_Create_DetailFasilitas_With_Valid_Data()
        {
            var detail = new DetailFasilitas(1, "Sari", "Gedung A", "AC tidak berfungsi", Prioritas.Tinggi, "AC");

            Assert.Equal(1, detail.UserId);
            Assert.Equal("Sari", detail.NamaPelapor);
            Assert.Equal("Gedung A", detail.Lokasi);
            Assert.Equal("AC tidak berfungsi", detail.Deskripsi);
            Assert.Equal(Prioritas.Tinggi, detail.PrioritasPengaduan);
            Assert.Equal("AC", detail.JenisFasilitas);
        }

        [Fact]
        public void Should_Create_DetailFasilitas_With_Default_Prioritas()
        {
            var detail = new DetailFasilitas(1, "Budi", "Ruang 101", "Proyektor rusak", "Proyektor");

            Assert.Equal(Prioritas.Rendah, detail.PrioritasPengaduan);
            Assert.Equal("Proyektor", detail.JenisFasilitas);
        }

        [Fact]
        public void Should_Throw_Exception_When_UserId_Is_Invalid()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new DetailFasilitas(-1, "Sari", "Lokasi", "Deskripsi", "Fasilitas"));

            Assert.Equal("User ID harus lebih besar dari 0. (Parameter 'userId')", ex.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_JenisFasilitas_Is_Empty()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new DetailFasilitas(1, "Sari", "Lokasi", "Deskripsi", Prioritas.Sedang, ""));

            Assert.Equal("Jenis fasilitas harus diisi. (Parameter 'jenisFasilitas')", ex.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_NamaPelapor_Is_Empty()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new DetailFasilitas(1, "", "Lokasi", "Deskripsi", "Fasilitas"));

            Assert.Equal("Nama pelapor tidak boleh kosong. (Parameter 'namaPelapor')", ex.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Lokasi_Is_Empty()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new DetailFasilitas(1, "Sari", "", "Deskripsi", "Fasilitas"));

            Assert.Equal("Lokasi tidak boleh kosong. (Parameter 'lokasi')", ex.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Deskripsi_Is_Empty()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new DetailFasilitas(1, "Sari", "Lokasi", "", "Fasilitas"));

            Assert.Equal("Deskripsi tidak boleh kosong. (Parameter 'deskripsi')", ex.Message);
        }
    }
}
