namespace App.Core.Models
{
    public class DetailFasilitas : PengaduanDetailBase
    {
        public Prioritas PrioritasPengaduan { get; set; }
        public string JenisFasilitas { get; set; }

        public DetailFasilitas(int userId, string namaPelapor, string lokasi, string deskripsi, string jenisFasilitas)
            : base(userId, namaPelapor, lokasi, deskripsi)
        {
            if (string.IsNullOrWhiteSpace(jenisFasilitas))
                throw new ArgumentException("Jenis fasilitas harus diisi.", nameof(jenisFasilitas));
            JenisFasilitas = jenisFasilitas;
        }
    }
}