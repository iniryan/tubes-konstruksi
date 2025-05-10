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

        public void Proses()
        {
            if (Status == StatusPengaduan.Dibuat)
            {
                Status = StatusPengaduan.Diproses;
            }
            else
            {
                throw new InvalidOperationException("Transisi status dari " + Status + " ke Diproses tidak valid.");
            }
        }

        public void Selesai()
        {
            if (Status == StatusPengaduan.Diproses)
            {
                Status = StatusPengaduan.Selesai;
            }
            else
            {
                throw new InvalidOperationException("Transisi status dari " + Status + " ke Selesai tidak valid.");
            }
        }

        public void Tolak()
        {
            if (Status == StatusPengaduan.Dibuat)
            {
                Status = StatusPengaduan.Ditolak;
            }
            else
            {
                throw new InvalidOperationException("Transisi status dari " + Status + " ke Ditolak tidak valid.");
            }
        }

        public override string ToString()
        {
            var detailInfo = "";

            if (Detail is PengaduanKebersihan kebersihan)
            {
                detailInfo = "\n  Masalah    : " + kebersihan.Masalah +
                             "\n  Lokasi    : " + kebersihan.Lokasi +
                             "\n  Prioritas : " + kebersihan.PrioritasPengaduan +
                             "\n  Nama Pelapor : " + kebersihan.NamaPelapor +
                             "\n  Kategori  : " + kebersihan.Kategori;
            }

            return "[" + Id + "] " + Status + " - Dibuat pada " + TanggalDibuat.ToString("dd/MM/yyyy HH:mm:ss") + detailInfo;
        }

    }

}
