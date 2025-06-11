using System.Text.Json.Serialization;
namespace App.Core.Models
{
    public enum StatusPengaduan
    {
        Dibuat,
        Diproses,
        Selesai,
        Ditolak
    }
    public class Pengaduan<T> where T : PengaduanDetailBase
    {
        public string Id { get; private set; }
        public T Detail { get; private set; }
        public StatusPengaduan Status { get; private set; }
        public DateTime TanggalDibuat { get; private set; }

        public Pengaduan(string id, T detail)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("ID tidak boleh kosong", nameof(id));

            Id = id;
            Detail = detail ?? throw new ArgumentNullException(nameof(detail));
            Status = StatusPengaduan.Dibuat;
            TanggalDibuat = DateTime.Now;
        }

        [JsonConstructor]
        public Pengaduan(string id, T detail, StatusPengaduan status, DateTime tanggalDibuat)
        {
            Id = id;
            Detail = detail;
            Status = status;
            TanggalDibuat = tanggalDibuat;
        }

        public void UbahStatus(StatusPengaduan statusBaru)
        {
            if (!StatusTransisi.BisaTransisi(this.Status, statusBaru))
                throw new InvalidOperationException($"Transisi dari {this.Status} ke {statusBaru} tidak valid.");

            this.Status = statusBaru;
        }
    }

    public static class StatusTransisi
    {
        private static readonly Dictionary<StatusPengaduan, List<StatusPengaduan>> _transisiValid = new()
            {
                { StatusPengaduan.Dibuat, new List<StatusPengaduan> { StatusPengaduan.Diproses, StatusPengaduan.Ditolak } },
                { StatusPengaduan.Diproses, new List<StatusPengaduan> { StatusPengaduan.Selesai } },
            };

        public static bool BisaTransisi(StatusPengaduan dari, StatusPengaduan ke)
        {
            return _transisiValid.ContainsKey(dari) && _transisiValid[dari].Contains(ke);
        }
    }
}