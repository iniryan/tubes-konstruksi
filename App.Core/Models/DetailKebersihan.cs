namespace App.Core.Models
{
    public enum Prioritas { Rendah, Sedang, Tinggi }

    public class DetailKebersihan : PengaduanDetailBase
    {
        public Prioritas PrioritasPengaduan { get; set; }
        public string Kategori { get; set; }

        public DetailKebersihan(string namaPelapor, string lokasi, string deskripsi, Prioritas prioritas, string kategori)
            : base(namaPelapor, lokasi, deskripsi)
        {
            if (string.IsNullOrWhiteSpace(kategori))
                throw new ArgumentException("Kategori harus diisi.", nameof(kategori));

            PrioritasPengaduan = prioritas;
            Kategori = kategori;
        }
    }
}