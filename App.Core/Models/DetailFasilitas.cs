namespace App.Core.Models
{
    public class DetailFasilitas : PengaduanDetailBase
    {
        public Prioritas PrioritasPengaduan { get; set; }
        public string JenisFasilitas { get; set; }

        public DetailFasilitas(string namaPelapor, string lokasi, string deskripsi, string jenisFasilitas)
            : base(namaPelapor, lokasi, deskripsi)
        {
            if (string.IsNullOrWhiteSpace(jenisFasilitas))
                throw new ArgumentException("Jenis fasilitas harus diisi.", nameof(jenisFasilitas));
            JenisFasilitas = jenisFasilitas;
        }
    }
}