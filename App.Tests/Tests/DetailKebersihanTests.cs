using System;
using Xunit;
using App.Core.Models;

namespace App.Tests.Tests
{
    public class DetailKebersihanTests
    {
        [Fact]
        public void Should_Create_DetailKebersihan_With_Valid_Data()
        {
            var detail = new DetailKebersihan(1, "Joko", "Koridor 1", "Sampah menumpuk", Prioritas.Tinggi, "Sampah");

            Assert.Equal(1, detail.UserId);
            Assert.Equal("Joko", detail.NamaPelapor);
            Assert.Equal("Koridor 1", detail.Lokasi);
            Assert.Equal("Sampah menumpuk", detail.Deskripsi);
            Assert.Equal(Prioritas.Tinggi, detail.PrioritasPengaduan);
            Assert.Equal("Sampah", detail.Kategori);
        }

        [Fact]
        public void Should_Throw_Exception_When_UserId_Is_Invalid()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new DetailKebersihan(0, "Joko", "Lokasi", "Deskripsi", Prioritas.Sedang, "Sampah"));

            Assert.Equal("User ID harus lebih besar dari 0. (Parameter 'userId')", ex.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_NamaPelapor_Is_Empty()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new DetailKebersihan(1, "", "Lokasi", "Deskripsi", Prioritas.Sedang, "Sampah"));

            Assert.Equal("Nama pelapor tidak boleh kosong. (Parameter 'namaPelapor')", ex.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Lokasi_Is_Empty()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new DetailKebersihan(1, "Joko", "", "Deskripsi", Prioritas.Sedang, "Sampah"));

            Assert.Equal("Lokasi tidak boleh kosong. (Parameter 'lokasi')", ex.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Deskripsi_Is_Empty()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new DetailKebersihan(1, "Joko", "Lokasi", "", Prioritas.Sedang, "Sampah"));

            Assert.Equal("Deskripsi tidak boleh kosong. (Parameter 'deskripsi')", ex.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Kategori_Is_Empty()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new DetailKebersihan(1, "Joko", "Lokasi", "Deskripsi", Prioritas.Sedang, ""));

            Assert.Equal("Kategori harus diisi. (Parameter 'kategori')", ex.Message);
        }

        [Theory]
        [InlineData(Prioritas.Rendah)]
        [InlineData(Prioritas.Sedang)]
        [InlineData(Prioritas.Tinggi)]
        public void Should_Accept_All_Valid_Prioritas_Values(Prioritas prioritas)
        {
            var detail = new DetailKebersihan(1, "Joko", "Lokasi", "Deskripsi", prioritas, "Sampah");

            Assert.Equal(prioritas, detail.PrioritasPengaduan);
        }
    }
}
