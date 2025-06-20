namespace App.Core.Models
{
    public class DetailKeamanan : PengaduanDetailBase
    {
        public string RT { get; set; }
        public string JenisKejadian { get; set; }

        [System.Text.Json.Serialization.JsonConstructor]
        public DetailKeamanan(int userId, string namaPelapor, string lokasi, string deskripsi, string rt, string jenisKejadian)
            : base(userId, namaPelapor, lokasi, deskripsi)
        {
            if (string.IsNullOrWhiteSpace(rt))
                throw new ArgumentException("RT harus diisi.", nameof(rt));
            if (string.IsNullOrWhiteSpace(jenisKejadian))
                throw new ArgumentException("Jenis kejadian harus diisi.", nameof(jenisKejadian));

            RT = rt;
            JenisKejadian = jenisKejadian;
        }
    }
}