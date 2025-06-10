namespace App.Core.Models
{
    public enum Prioritas { Rendah, Sedang, Tinggi }

    public class DetailKebersihan : PengaduanDetailBase
    {
        public Prioritas PrioritasPengaduan { get; set; }
        public string Kategori { get; set; }

        [System.Text.Json.Serialization.JsonConstructor]
        public DetailKebersihan(string namaPelapor, string lokasi, string deskripsi, Prioritas prioritasPengaduan, string kategori)
            : base(namaPelapor, lokasi, deskripsi)
        {
            if (string.IsNullOrWhiteSpace(kategori))
                throw new ArgumentException("Kategori harus diisi.", nameof(kategori));

            PrioritasPengaduan = prioritasPengaduan;
            Kategori = kategori;
        }
    }
}