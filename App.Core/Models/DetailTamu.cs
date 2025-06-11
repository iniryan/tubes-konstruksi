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

        public DetailTamu(string namaPelapor, string lokasi, string deskripsi, string nomorIdentitas, string tujuan, string pegawaiTujuan, DateTime? waktuKeluar = null)
            : base(namaPelapor, lokasi, deskripsi)
        {
            NomorIdentitas = nomorIdentitas;
            Tujuan = tujuan;
            PegawaiTujuan = pegawaiTujuan;
            WaktuKeluar = waktuKeluar;
        }
    }
}