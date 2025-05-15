using Xunit;
using PengaduanKeamananCLI.Services;
using PengaduanKeamananCLI.Models;
using PengaduanKeamananCLI.Database;
using System.Linq;

namespace PengaduanKeamananCLI.Tests
{
    public class PengaduanServiceTests
    {
        public PengaduanServiceTests()
        {
            DatabaseHelper.InitDatabase();
        }

        [Fact]
        public void TambahPengaduan_ValidData_Success()
        {
            var pengaduan = new Pengaduan
            {
                NamaPengadu = "tester",
                RT = "01",
                JenisKejadian = "Kehilangan",
                IsiKeluhan = "Dompet hilang",
                LokasiKeluhan = "Ruang A",
                Status = 1
            };
            PengaduanService.TambahPengaduan(pengaduan);
            var list = PengaduanService.GetByUser("tester");
            Assert.Contains(list, p => p.IsiKeluhan == "Dompet hilang");
        }

        [Fact]
        public void UpdateStatus_ChangeStatus_Success()
        {
            var pengaduan = new Pengaduan
            {
                NamaPengadu = "tester2",
                RT = "02",
                JenisKejadian = "Pencurian",
                IsiKeluhan = "Motor hilang",
                LokasiKeluhan = "Ruang B",
                Status = 1
            };
            PengaduanService.TambahPengaduan(pengaduan);
            var list = PengaduanService.GetByUser("tester2");
            var last = list.Last();
            var result = PengaduanService.UpdateStatus(last.Id, 2);
            Assert.True(result);
            var updated = PengaduanService.GetByUser("tester2").FirstOrDefault(p => p.Id == last.Id);
            Assert.NotNull(updated);
            Assert.Equal(2, updated!.Status);
        }

        [Fact]
        public void DeletePengaduan_Success()
        {
            var pengaduan = new Pengaduan
            {
                NamaPengadu = "tester3",
                RT = "03",
                JenisKejadian = "Kebakaran",
                IsiKeluhan = "Gudang terbakar",
                LokasiKeluhan = "Ruang C",
                Status = 1
            };
            PengaduanService.TambahPengaduan(pengaduan);
            var list = PengaduanService.GetByUser("tester3");
            var last = list.Last();
            var result = PengaduanService.Delete(last.Id);
            Assert.True(result);
            var afterDelete = PengaduanService.GetByUser("tester3");
            Assert.DoesNotContain(afterDelete, p => p.Id == last.Id);
        }

        [Fact]
        public void Admin_CanSeeAllPengaduan()
        {
            var pengaduan1 = new Pengaduan { NamaPengadu = "userA", RT = "01", JenisKejadian = "A", IsiKeluhan = "A", LokasiKeluhan = "A", Status = 1 };
            var pengaduan2 = new Pengaduan { NamaPengadu = "userB", RT = "02", JenisKejadian = "B", IsiKeluhan = "B", LokasiKeluhan = "B", Status = 2 };
            PengaduanService.TambahPengaduan(pengaduan1);
            PengaduanService.TambahPengaduan(pengaduan2);
            var all = PengaduanService.GetAll();
            Assert.Contains(all, p => p.NamaPengadu == "userA");
            Assert.Contains(all, p => p.NamaPengadu == "userB");
        }

        [Fact]
        public void Admin_CanFilterPengaduanByStatus()
        {
            var pengaduan = new Pengaduan { NamaPengadu = "userC", RT = "03", JenisKejadian = "C", IsiKeluhan = "C", LokasiKeluhan = "C", Status = 3 };
            PengaduanService.TambahPengaduan(pengaduan);
            var filtered = PengaduanService.GetByStatus(3);
            Assert.Contains(filtered, p => p.NamaPengadu == "userC");
        }
    }
} 