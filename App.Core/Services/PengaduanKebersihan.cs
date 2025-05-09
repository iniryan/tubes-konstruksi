using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Models;
using System.Xml.Linq;

namespace App.Core.Services
{
    public class PengaduanKebersihan
    {
        public string Masalah { get; set; }
        public string Lokasi { get; set; }

        public PengaduanKebersihan(string masalah, string lokasi)
        {
            if (string.IsNullOrWhiteSpace(masalah)) throw new ArgumentException("Masalah harus diisi");
            if (string.IsNullOrWhiteSpace(lokasi)) throw new ArgumentException("Lokasi harus diisi");
            Masalah = masalah;
            Lokasi = lokasi;
        }
    }

    public class PengaduanKebersihanService
    {
        private readonly List<Pengaduan<PengaduanKebersihan>> _pengaduanList = new();

        // CREATE
        public Pengaduan<PengaduanKebersihan> TambahPengaduan(string masalah, string lokasi)
        {
            var pengaduan = new Pengaduan<PengaduanKebersihan>(
                id: Guid.NewGuid().ToString(),
                detail: new PengaduanKebersihan(masalah, lokasi)
            );
            _pengaduanList.Add(pengaduan);
            return pengaduan;
        }

        // READ - Semua pengaduan
        public List<Pengaduan<PengaduanKebersihan>> AmbilSemuaPengaduan()
        {
            return _pengaduanList;
        }

        // READ - Pengaduan berdasarkan ID
        public Pengaduan<PengaduanKebersihan>? AmbilPengaduanById(string id)
        {
            return _pengaduanList.FirstOrDefault(p => p.Id == id);
        }

        // UPDATE - Ubah status pengaduan
        public void UbahStatus(string id, StatusPengaduan status)
        {
            var pengaduan = AmbilPengaduanById(id);
            if (pengaduan == null) throw new KeyNotFoundException("Pengaduan tidak ditemukan.");

            switch (status)
            {
                case StatusPengaduan.Diproses:
                    pengaduan.Proses();
                    break;
                case StatusPengaduan.Selesai:
                    pengaduan.Selesai();
                    break;
                case StatusPengaduan.Ditolak:
                    pengaduan.Tolak();
                    break;
                default:
                    throw new InvalidOperationException("Transisi status tidak valid.");
            }
        }

        // DELETE
        public void HapusPengaduan(string id)
        {
            var pengaduan = AmbilPengaduanById(id);
            if (pengaduan == null) throw new KeyNotFoundException("Pengaduan tidak ditemukan.");
            _pengaduanList.Remove(pengaduan);
        }
    }

}
