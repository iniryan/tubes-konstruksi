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
        public Pengaduan<PengaduanKebersihan> TambahPengaduan(string namaPelapor, string masalah, 
            string lokasi, Prioritas prioritas, string kategori)
        {
            var pengaduan = new Pengaduan<PengaduanKebersihan>(
                id: Guid.NewGuid().ToString(),
                detail: new PengaduanKebersihan(namaPelapor, masalah, lokasi, prioritas, kategori)
            );
            _pengaduanList.Add(pengaduan);

            if (!_pengaduanList.Contains(pengaduan))
                throw new InvalidOperationException("Pengaduan gagal ditambahkan ke daftar.");

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

            var statusSebelum = pengaduan.Status;
            pengaduan.UbahStatus(status);

            if (pengaduan.Status == statusSebelum)
                throw new InvalidOperationException("Status pengaduan tidak berubah.");
        }

        // UPDATE - Ubah data pengaduan
        public void UbahDataPengaduan(string id, string namaPelapor, string masalah,
            string lokasi, Prioritas prioritas, string kategori)
        {
            var pengaduan = AmbilPengaduanById(id);
            if (pengaduan == null)
                throw new KeyNotFoundException("Pengaduan dengan ID " + id + " tidak ditemukan.");

            if (pengaduan.Detail == null)
                throw new InvalidOperationException("Pengaduan tidak memiliki detail yang valid.");

            var currentDetail = pengaduan.Detail;
            bool hasChanges = false;

            if (currentDetail.NamaPelapor != namaPelapor)
            {
                currentDetail.NamaPelapor = namaPelapor;
                hasChanges = true;
            }
            if (currentDetail.Masalah != masalah)
            {
                currentDetail.Masalah = masalah;
                hasChanges = true;
            }
            if (currentDetail.Lokasi != lokasi)
            {
                currentDetail.Lokasi = lokasi;
                hasChanges = true;
            }
            if (currentDetail.PrioritasPengaduan != prioritas)
            {
                currentDetail.PrioritasPengaduan = prioritas;
                hasChanges = true;
            }
            if (currentDetail.Kategori != kategori)
            {
                currentDetail.Kategori = kategori;
                hasChanges = true;
            }

            if (!hasChanges)
            {
                throw new InvalidOperationException("Data pengaduan tidak berubah.");
            }
        }

        // DELETE
        public void HapusPengaduan(string id)
        {
            var pengaduan = AmbilPengaduanById(id);
            if (pengaduan == null) throw new KeyNotFoundException("Pengaduan tidak ditemukan.");
            
            var berhasilHapus = _pengaduanList.Remove(pengaduan);

            if (!berhasilHapus)
                throw new InvalidOperationException("Pengaduan gagal dihapus dari daftar.");

            if (_pengaduanList.Contains(pengaduan))
                throw new InvalidOperationException("Pengaduan masih ada di daftar setelah dihapus.");
        }
    }

}
