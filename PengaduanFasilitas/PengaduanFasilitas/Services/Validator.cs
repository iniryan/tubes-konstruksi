using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace PengaduanFasilitas.Services
{
    public class Validator
    {
        private readonly List<string> allowedTypes;
        private readonly int maxLength;

        public Validator()
        {
            var config = JsonNode.Parse(File.ReadAllText("config.json"));
            allowedTypes = config["AllowedTypes"].AsArray().Select(t => t.ToString()).ToList();
            maxLength = config["MaxDescriptionLength"].GetValue<int>();
        }

        public void Validate(string type, string description)
        {
            if (!allowedTypes.Contains(type))
                throw new ArgumentException("Jenis pengaduan tidak valid.");
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Deskripsi tidak boleh kosong.");
            if (description.Length > maxLength)
                throw new ArgumentException($"Deskripsi terlalu panjang. Maksimal {maxLength} karakter.");
        }
    }
}
