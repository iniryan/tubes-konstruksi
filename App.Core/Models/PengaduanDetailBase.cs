namespace App.Core.Models
{
    public abstract class PengaduanDetailBase
    {
        [System.Text.Json.Serialization.JsonPropertyName("userId")]
        public int UserId { get; set; }
        public string NamaPelapor { get; set; }
        public string Lokasi { get; set; }
        public string Deskripsi { get; set; }

        protected PengaduanDetailBase(int userId, string namaPelapor, string lokasi, string deskripsi)
        {
            if (userId <= 0) throw new ArgumentException("User ID harus lebih besar dari 0.", nameof(userId));
            if (string.IsNullOrWhiteSpace(namaPelapor)) throw new ArgumentException("Nama pelapor tidak boleh kosong.", nameof(namaPelapor));
            if (string.IsNullOrWhiteSpace(lokasi)) throw new ArgumentException("Lokasi tidak boleh kosong.", nameof(lokasi));
            if (string.IsNullOrWhiteSpace(deskripsi)) throw new ArgumentException("Deskripsi tidak boleh kosong.", nameof(deskripsi));

            UserId = userId;
            NamaPelapor = namaPelapor;
            Lokasi = lokasi;
            Deskripsi = deskripsi;
        }
    }
}