using App.Core.Models;

namespace App.Core.Services
{
    public interface IPengaduanService<TDetail> where TDetail : PengaduanDetailBase
    {
        Pengaduan<TDetail> BuatPengaduan(TDetail detail);
        Pengaduan<TDetail>? AmbilPengaduanById(string id);
        IEnumerable<Pengaduan<TDetail>> AmbilSemuaPengaduan();
        void UbahStatus(string id, StatusPengaduan statusBaru);
        void HapusPengaduan(string id);
        void UbahDataPengaduan(string id, TDetail detailBaru);
    }
}