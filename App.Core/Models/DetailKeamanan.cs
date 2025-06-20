namespace App.Core.Models
{
    public class DetailKeamanan : PengaduanDetailBase
    {
        public string JenisKejadian { get; set; }
        public string TingkatUrgensitas { get; set; }

        [System.Text.Json.Serialization.JsonConstructor]
        public DetailKeamanan(int userId, string namaPelapor, string lokasi, string deskripsi, string jenisKejadian, string tingkatUrgensitas)
            : base(userId, namaPelapor, lokasi, deskripsi)
        {
            if (string.IsNullOrWhiteSpace(jenisKejadian))
                throw new ArgumentException("Jenis kejadian harus diisi.", nameof(jenisKejadian));
            if (string.IsNullOrWhiteSpace(tingkatUrgensitas))
                throw new ArgumentException("Tingkat urgensitas harus diisi.", nameof(tingkatUrgensitas));

            JenisKejadian = jenisKejadian;
            TingkatUrgensitas = tingkatUrgensitas;
        }
    }
}