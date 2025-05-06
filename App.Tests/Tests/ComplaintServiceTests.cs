using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Models;
using App.Core.Services;

namespace App.Tests.Tests
{
    public class ComplaintServiceTests
    {
        [Fact]
        public void AddComplaint_InvalidCategory_ShouldThrowException()
        {
            // Arrange untuk membuat instance ComplaintService dan Complaint dengan kategori salah
            var service = new ComplaintService<Complaint>();
            var invalidComplaint = new Complaint
            {
                Id = 2,
                Description = "Lampu jalan mati",
                Category = "Keamanan",  // Kategori yang salah
                Date = DateTime.Now
            };

            // Act & Assert untuk mengharapkan exception dilemparkan
            var ex = Assert.Throws<ArgumentException>(() => service.AddComplaint(invalidComplaint));
            Assert.Equal("Kategori tidak valid. Hanya 'Kebersihan' yang diperbolehkan.", ex.Message);
        }

        [Fact]
        public void AddComplaint_ValidComplaint_ShouldAddSuccessfully()
        {
            // Arrange untuk membuat instance ComplaintService dan Complaint yang valid
            var service = new ComplaintService<Complaint>();
            var validComplaint = new Complaint
            {
                Id = 1,
                Description = "Sampah menumpuk di koridor.",
                Category = "Kebersihan",
                Date = DateTime.Now
            };

            // Act untuk menambahkan pengaduan yang valid
            service.AddComplaint(validComplaint);

            // Assert untuk memastikan jumlah pengaduan dalam list bertambah
            var complaints = service.GetAllComplaints();
            Assert.Single(complaints);
        }

        [Fact]
        public void AddComplaint_Performance_ShouldBeFastEnough()
        {
            var service = new ComplaintService<Complaint>();
            var complaint = new Complaint
            {
                Id = 1,
                Description = "Test",
                Category = "Kebersihan",
                Date = DateTime.Now
            };

            var sw = Stopwatch.StartNew();
            service.AddComplaint(complaint);
            sw.Stop();

            Assert.True(sw.ElapsedMilliseconds < 10, "AddComplaint terlalu lambat.");
        }

    }
}
