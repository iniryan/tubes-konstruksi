namespace App.Core.Models
{
    public class DetailFasilitas : PengaduanDetailBase
    {
        public Prioritas PrioritasPengaduan { get; set; }
        public string JenisFasilitas { get; set; }

        [System.Text.Json.Serialization.JsonConstructor]
        public DetailFasilitas(int userId, string namaPelapor, string lokasi, string deskripsi, Prioritas prioritasPengaduan, string jenisFasilitas)
            : base(userId, namaPelapor, lokasi, deskripsi)
        {
            if (string.IsNullOrWhiteSpace(jenisFasilitas))
                throw new ArgumentException("Jenis fasilitas harus diisi.", nameof(jenisFasilitas));
            PrioritasPengaduan = prioritasPengaduan;
            JenisFasilitas = jenisFasilitas;
        }

        public DetailFasilitas(int userId, string namaPelapor, string lokasi, string deskripsi, string jenisFasilitas)
            : this(userId, namaPelapor, lokasi, deskripsi, Prioritas.Rendah, jenisFasilitas)
        {
        }
    }
}