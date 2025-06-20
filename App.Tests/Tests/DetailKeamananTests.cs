using System;
using Xunit;
using App.Core.Models;

namespace App.Tests.Tests
{
    public class DetailKeamananTests
    {
        [Fact]
        public void Should_Create_DetailKeamanan_With_Valid_Data()
        {
            var detail = new DetailKeamanan(1, "Budi", "Jl. Merdeka No. 5", "Pencurian sepeda motor", "014", "Pencurian");

            Assert.Equal(1, detail.UserId);
            Assert.Equal("Budi", detail.NamaPelapor);
            Assert.Equal("Jl. Merdeka No. 5", detail.Lokasi);
            Assert.Equal("Pencurian sepeda motor", detail.Deskripsi);
            Assert.Equal("014", detail.RT);
            Assert.Equal("Pencurian", detail.JenisKejadian);
        }
        [Fact]
        public void Should_Throw_Exception_When_UserId_Is_Invalid()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new DetailKeamanan(0, "Budi", "Lokasi", "Deskripsi", "001", "Pencurian"));

            Assert.Equal("User ID harus lebih besar dari 0. (Parameter 'userId')", ex.Message);
        }
        [Fact]
        public void Should_Throw_Exception_When_RT_Is_Empty()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new DetailKeamanan(1, "Budi", "Lokasi", "Deskripsi", "", "Pencurian"));

            Assert.Equal("RT harus diisi. (Parameter 'rt')", ex.Message);
        }
        [Fact]
        public void Should_Throw_Exception_When_JenisKejadian_Is_Empty()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new DetailKeamanan(1, "Budi", "Lokasi", "Deskripsi", "001", ""));

            Assert.Equal("Jenis kejadian harus diisi. (Parameter 'jenisKejadian')", ex.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_NamaPelapor_Is_Empty()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new DetailKeamanan(1, "", "Lokasi", "Deskripsi", "001", "Pencurian"));

            Assert.Equal("Nama pelapor tidak boleh kosong. (Parameter 'namaPelapor')", ex.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Lokasi_Is_Empty()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new DetailKeamanan(1, "Budi", "", "Deskripsi", "001", "Pencurian"));

            Assert.Equal("Lokasi tidak boleh kosong. (Parameter 'lokasi')", ex.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Deskripsi_Is_Empty()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new DetailKeamanan(1, "Budi", "Lokasi", "", "001", "Pencurian"));

            Assert.Equal("Deskripsi tidak boleh kosong. (Parameter 'deskripsi')", ex.Message);
        }
    }
}
