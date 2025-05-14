using System;
using System.Collections.Generic;
using System.Linq;
using App.Core.Models;
using System.Xml.Linq;

namespace App.Core.Services
{
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

            pengaduan.UbahStatus(status);
        }

        // UPDATE - Ubah data pengaduan
        public void UbahDataPengaduan(string id, string namaPelapor, string masalah, string lokasi, Prioritas prioritas, string kategori)
        {
            var pengaduan = AmbilPengaduanById(id);
            if (pengaduan == null) throw new KeyNotFoundException("Pengaduan tidak ditemukan.");
            if (pengaduan.Detail == null) throw new InvalidOperationException("Pengaduan tidak memiliki detail yang valid.");

            pengaduan.Detail.NamaPelapor = namaPelapor;
            pengaduan.Detail.Masalah = masalah;
            pengaduan.Detail.Lokasi = lokasi;
            pengaduan.Detail.PrioritasPengaduan = prioritas;
            pengaduan.Detail.Kategori = kategori;
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
