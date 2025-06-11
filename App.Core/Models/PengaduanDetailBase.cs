namespace App.Core.Models
{
    public abstract class PengaduanDetailBase
    {
        public string NamaPelapor { get; set; }
        public string Lokasi { get; set; }
        public string Deskripsi { get; set; }

        protected PengaduanDetailBase(string namaPelapor, string lokasi, string deskripsi)
        {
            if (string.IsNullOrWhiteSpace(namaPelapor))
                throw new ArgumentException("Nama pelapor harus diisi.", nameof(namaPelapor));
            if (string.IsNullOrWhiteSpace(lokasi))
                throw new ArgumentException("Lokasi harus diisi.", nameof(lokasi));
            if (string.IsNullOrWhiteSpace(deskripsi))
                throw new ArgumentException("Deskripsi harus diisi.", nameof(deskripsi));

            NamaPelapor = namaPelapor;
            Lokasi = lokasi;
            Deskripsi = deskripsi;
        }
    }
}