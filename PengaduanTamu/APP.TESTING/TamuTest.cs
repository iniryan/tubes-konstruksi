using GuestApp.Models;
using GuestApp.Helpers;




namespace APP.TESTING
{
    [TestClass]
    public class TamuTest
    {
        [TestMethod]
        public void CariTamu_ReturnsMatchingTamu_ByName()
        {
            // Arrange
            var tamuList = new List<Tamu>
            {
                new Tamu { Id = 1, Nama = "Damasya", WaktuDatang = DateTime.Today },
                new Tamu { Id = 2, Nama = "Budi", WaktuDatang = DateTime.Today }
            };

            // Act
            var result = TamuHelper.CariTamu(tamuList, "dam");

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Damasya", result[0].Nama);
        }

        [TestMethod]
        public void HitungHarian_ReturnsCorrectCount()
        {
            // Arrange
            var tamuList = new List<Tamu>
            {
                new Tamu { WaktuDatang = DateTime.Today },
                new Tamu { WaktuDatang = DateTime.Today.AddDays(-1) }
            };

            // Act
            var count = TamuHelper.HitungHarian(tamuList);

            // Assert
            Assert.AreEqual(1, count);
        }
    }
}
