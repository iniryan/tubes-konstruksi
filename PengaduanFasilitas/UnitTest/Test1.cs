using Microsoft.VisualStudio.TestTools.UnitTesting;
using PengaduanFasilitas.Models;
using PengaduanFasilitas.Services;
using System;

namespace UnitTest
{
    [TestClass]
    public class UjiPengelolaanPengaduan
    {
        [TestMethod]
        public void SubmitComplaint_ShouldStoreComplaint()
        {
            // Arrange
            var handler = new PengaduanFasilitasServ();

            // Act
            handler.SubmitComplaint("Lampu Jalan", "Lampu depan rumah mati");

            // Assert
            var complaints = handler.GetComplaints();
            Assert.AreEqual(1, complaints.Count);
            Assert.AreEqual("Lampu Jalan", complaints[0].Type);
            Assert.AreEqual("Lampu depan rumah mati", complaints[0].Description);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SubmitComplaint_ShouldThrowError_WhenTypeIsEmpty()
        {
            var handler = new PengaduanFasilitasServ();
            handler.SubmitComplaint("", "Deskripsi kosong");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SubmitComplaint_ShouldThrowError_WhenDescriptionIsEmpty()
        {
            var handler = new PengaduanFasilitasServ();
            handler.SubmitComplaint("Jalan Berlubang", "");
        }

        [TestMethod]
        public void SubmitMultipleComplaints_ShouldStoreAll()
        {
            var handler = new PengaduanFasilitasServ();
            handler.SubmitComplaint("Lampu Jalan", "Mati total");
            handler.SubmitComplaint("Jalan Berlubang", "Bahaya kecelakaan");

            var complaints = handler.GetComplaints();
            Assert.AreEqual(2, complaints.Count);
        }
    }
}
