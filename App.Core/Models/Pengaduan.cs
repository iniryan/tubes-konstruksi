using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Services;

namespace App.Core.Models
{
    public enum StatusPengaduan
    {
        Dibuat,
        Diproses,
        Selesai,
        Ditolak
    }

    public class Pengaduan<T>
    {
        public string Id { get; private set; }
        public T Detail { get; private set; }
        public StatusPengaduan Status { get; private set; }
        public DateTime TanggalDibuat { get; private set; }

        public Pengaduan(string id, T detail)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("ID tidak boleh kosong");
            Id = id;
            Detail = detail ?? throw new ArgumentNullException(nameof(detail));
            Status = StatusPengaduan.Dibuat;
            TanggalDibuat = DateTime.Now;
        }

        public void UbahStatus(StatusPengaduan statusBaru)
        {
            if (!StatusTransisi.BisaTransisi(this.Status, statusBaru))
                throw new InvalidOperationException("Transisi dari " + this.Status + " ke " + statusBaru + " tidak valid.");

            this.Status = statusBaru;
        }

        public override string ToString()
        {
            var detailInfo = "";

            if (Detail is PengaduanKebersihan kebersihan)
            {
                detailInfo = "\n  Nama Pelapor : " + kebersihan.NamaPelapor +
                             "\n  Kategori  : " + kebersihan.Kategori +
                             "\n  Prioritas : " + kebersihan.PrioritasPengaduan +
                             "\n  Masalah    : " + kebersihan.Masalah +
                             "\n  Lokasi    : " + kebersihan.Lokasi;
            }

            return "[" + Id + "] " + Status + " - Dibuat pada " + TanggalDibuat.ToString("dd/MM/yyyy HH:mm:ss") + detailInfo;
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
