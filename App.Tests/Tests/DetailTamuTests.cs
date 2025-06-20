using System;
using Xunit;
using App.Core.Models;

namespace App.Tests.Tests
{
    public class DetailTamuTests
    {
        [Fact]
        public void Should_Create_DetailTamu_With_Valid_Data()
        {
            var userId = 1;
            var namaPelapor = "John Doe";
            var lokasi = "Lobby Utama";
            var deskripsi = "Bertemu dengan manager";
            var nomorIdentitas = "3201234567890123";
            var tujuan = "Meeting bisnis";
            var pegawaiTujuan = "Manager Sales";
            var waktuDatang = DateTime.Now;
            var waktuKeluar = DateTime.Now.AddHours(2);

            var detail = new DetailTamu(userId, namaPelapor, lokasi, deskripsi, nomorIdentitas, tujuan, pegawaiTujuan, waktuDatang, waktuKeluar);

            Assert.Equal(userId, detail.UserId);
            Assert.Equal(namaPelapor, detail.NamaPelapor);
            Assert.Equal(lokasi, detail.Lokasi);
            Assert.Equal(deskripsi, detail.Deskripsi);
            Assert.Equal(nomorIdentitas, detail.NomorIdentitas);
            Assert.Equal(tujuan, detail.Tujuan);
            Assert.Equal(pegawaiTujuan, detail.PegawaiTujuan);
            Assert.Equal(waktuDatang, detail.WaktuDatang);
            Assert.Equal(waktuKeluar, detail.WaktuKeluar);
        }

        [Fact]
        public void Should_Create_DetailTamu_With_Default_WaktuDatang()
        {
            var beforeCreation = DateTime.Now;
            var detail = new DetailTamu(1, "Jane Doe", "Reception", "Kunjungan kerja", "1234567890", "Konsultasi", "HR Manager");
            var afterCreation = DateTime.Now;

            Assert.True(detail.WaktuDatang >= beforeCreation);
            Assert.True(detail.WaktuDatang <= afterCreation);
            Assert.Null(detail.WaktuKeluar);
        }
        [Fact]
        public void Should_Create_DetailTamu_With_WaktuKeluar_Specified()
        {
            var waktuDatang = DateTime.Now;
            var waktuKeluar = DateTime.Now.AddHours(3);
            var detail = new DetailTamu(1, "Bob Smith", "Kantor", "Meeting", "9876543210", "Diskusi project", "Project Manager", waktuDatang, waktuKeluar);

            Assert.Equal(waktuKeluar, detail.WaktuKeluar);
        }

        [Fact]
        public void Should_Throw_Exception_When_UserId_Is_Invalid()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new DetailTamu(0, "John Doe", "Lokasi", "Deskripsi", "1234567890", "Tujuan", "Pegawai"));

            Assert.Equal("User ID harus lebih besar dari 0. (Parameter 'userId')", ex.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_NamaPelapor_Is_Empty()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new DetailTamu(1, "", "Lokasi", "Deskripsi", "1234567890", "Tujuan", "Pegawai"));

            Assert.Equal("Nama pelapor tidak boleh kosong. (Parameter 'namaPelapor')", ex.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Lokasi_Is_Empty()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new DetailTamu(1, "John Doe", "", "Deskripsi", "1234567890", "Tujuan", "Pegawai"));

            Assert.Equal("Lokasi tidak boleh kosong. (Parameter 'lokasi')", ex.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Deskripsi_Is_Empty()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new DetailTamu(1, "John Doe", "Lokasi", "", "1234567890", "Tujuan", "Pegawai"));

            Assert.Equal("Deskripsi tidak boleh kosong. (Parameter 'deskripsi')", ex.Message);
        }

        [Fact]
        public void Should_Allow_Modification_Of_Properties()
        {
            var detail = new DetailTamu(1, "John Doe", "Lobby", "Meeting", "1234567890", "Konsultasi", "Manager");
            var newWaktuKeluar = DateTime.Now.AddHours(4);

            detail.NomorIdentitas = "9876543210";
            detail.Tujuan = "Tujuan baru";
            detail.PegawaiTujuan = "Pegawai baru";
            detail.WaktuKeluar = newWaktuKeluar;

            Assert.Equal("9876543210", detail.NomorIdentitas);
            Assert.Equal("Tujuan baru", detail.Tujuan);
            Assert.Equal("Pegawai baru", detail.PegawaiTujuan);
            Assert.Equal(newWaktuKeluar, detail.WaktuKeluar);
        }

        [Fact]
        public void Should_Handle_Null_WaktuKeluar_In_Constructor()
        {
            var detail = new DetailTamu(1, "John Doe", "Lobby", "Meeting", "1234567890", "Konsultasi", "Manager", DateTime.Now, null);

            Assert.Null(detail.WaktuKeluar);
        }

        [Fact]
        public void Should_Set_WaktuKeluar_To_Null_By_Default()
        {
            var detail = new DetailTamu(1, "John Doe", "Lobby", "Meeting", "1234567890", "Konsultasi", "Manager");

            Assert.Null(detail.WaktuKeluar);
        }
    }
}
