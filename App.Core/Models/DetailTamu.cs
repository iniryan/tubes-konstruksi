using App.Core.Models;
using System;

namespace App.Core.Models
{
    public class DetailTamu : PengaduanDetailBase
    {
        public string NomorIdentitas { get; set; }
        public string Tujuan { get; set; }
        public string PegawaiTujuan { get; set; }
        public DateTime WaktuDatang { get; set; } = DateTime.Now;
        public DateTime? WaktuKeluar { get; set; }

        [System.Text.Json.Serialization.JsonConstructor]
        public DetailTamu(int userId, string namaPelapor, string lokasi, string deskripsi, string nomorIdentitas, string tujuan, string pegawaiTujuan, DateTime waktuDatang, DateTime? waktuKeluar = null)
            : base(userId, namaPelapor, lokasi, deskripsi)
        {
            NomorIdentitas = nomorIdentitas;
            Tujuan = tujuan;
            PegawaiTujuan = pegawaiTujuan;
            WaktuDatang = waktuDatang;
            WaktuKeluar = waktuKeluar;
        }

        public DetailTamu(int userId, string namaPelapor, string lokasi, string deskripsi, string nomorIdentitas, string tujuan, string pegawaiTujuan, DateTime? waktuKeluar = null)
            : this(userId, namaPelapor, lokasi, deskripsi, nomorIdentitas, tujuan, pegawaiTujuan, DateTime.Now, waktuKeluar)
        {
        }
    }
}