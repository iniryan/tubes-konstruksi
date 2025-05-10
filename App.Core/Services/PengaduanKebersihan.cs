using System;
using System.Collections.Generic;
using System.Linq;
using App.Core.Models;
using System.Xml.Linq;

namespace App.Core.Services
{
    public enum Prioritas { Rendah, Sedang, Tinggi }

    public class PengaduanKebersihan
    {
        public string NamaPelapor { get; set; }
        public string Masalah { get; set; }
        public string Lokasi { get; set; }
        public Prioritas PrioritasPengaduan { get; set; }
        public string Kategori { get; set; } // Misalnya: "Sampah", "Saluran Air", "WC Umum", dll.

        public PengaduanKebersihan(string namaPelapor, string masalah, string lokasi, Prioritas prioritas, string kategori)
        {
            if (string.IsNullOrWhiteSpace(namaPelapor)) throw new ArgumentException("Nama pelapor harus diisi");
            if (string.IsNullOrWhiteSpace(masalah)) throw new ArgumentException("Masalah harus diisi");
            if (string.IsNullOrWhiteSpace(lokasi)) throw new ArgumentException("Lokasi harus diisi");
            if (string.IsNullOrWhiteSpace(kategori)) throw new ArgumentException("Kategori harus diisi");

            NamaPelapor = namaPelapor;
            Masalah = masalah;
            Lokasi = lokasi;
            Kategori = kategori;
            PrioritasPengaduan = prioritas;
        }
    }

    public class PengaduanKebersihanService
    {
        private readonly List<Pengaduan<PengaduanKebersihan>> _pengaduanList = new();

        // CREATE
        public Pengaduan<PengaduanKebersihan> TambahPengaduan(string namaPelapor, string masalah, string lokasi, Prioritas prioritas, string kategori)
        {
            var pengaduan = new Pengaduan<PengaduanKebersihan>(
                id: Guid.NewGuid().ToString(),
                detail: new PengaduanKebersihan(namaPelapor, masalah, lokasi, prioritas, kategori)
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
