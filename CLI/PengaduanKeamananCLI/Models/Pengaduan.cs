namespace PengaduanKeamananCLI.Models
{
    public class Pengaduan
    {
        public int Id { get; set; }
        public string NamaPengadu { get; set; } = string.Empty;
        public string RT { get; set; } = string.Empty;
        public string JenisKejadian { get; set; } = string.Empty;
        public string IsiKeluhan { get; set; } = string.Empty;
        public string LokasiKeluhan { get; set; } = string.Empty;
        public int Status { get; set; }
    }
} 