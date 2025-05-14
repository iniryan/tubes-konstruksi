using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Services;

namespace App.Core.Models
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

}
