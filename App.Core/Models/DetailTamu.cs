namespace App.Core.Models
{
    public class DetailTamu : PengaduanDetailBase
    {
        public string NomorIdentitas { get; set; }
        public string PegawaiTujuan { get; set; }
        public DateTime WaktuDatang { get; set; }
        public DateTime? WaktuKeluar { get; set; }

        public DetailTamu(string namaTamu, string tujuan, string nomorIdentitas, string pegawaiTujuan)
            : base(namaTamu, tujuan, $"Bertemu dengan {pegawaiTujuan}")
        {
            if (string.IsNullOrWhiteSpace(nomorIdentitas))
                throw new ArgumentException("Nomor identitas harus diisi.", nameof(nomorIdentitas));
            if (string.IsNullOrWhiteSpace(pegawaiTujuan))
                throw new ArgumentException("Pegawai tujuan harus diisi.", nameof(pegawaiTujuan));

            NomorIdentitas = nomorIdentitas;
            PegawaiTujuan = pegawaiTujuan;
            WaktuDatang = DateTime.Now;
            WaktuKeluar = null;
        }
    }
}