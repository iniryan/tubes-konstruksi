using App.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Nodes;

namespace App.Core.Utils
{
    public class Validator
    {
        private readonly List<string> _allowedTypes;
        private readonly int _maxLength; public Validator()
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string solutionDirectory = Path.GetFullPath(Path.Combine(exeDirectory, "..", "..", "..", ".."));
            string configPath = Path.Combine(solutionDirectory, "App.Core", "Database", "config.json");

            var config = JsonNode.Parse(File.ReadAllText(configPath));
            _allowedTypes = config["AllowedTypes"].AsArray().Select(t => t.ToString()).ToList();
            _maxLength = config["MaxDescriptionLength"].GetValue<int>();
        }

        public void Validate(DetailFasilitas detail)
        {
            if (detail == null)
                throw new ArgumentNullException(nameof(detail), "Detail pengaduan tidak boleh null.");

            if (!_allowedTypes.Contains(detail.JenisFasilitas))
                throw new ArgumentException($"Jenis fasilitas '{detail.JenisFasilitas}' tidak valid.");

            if (detail.Deskripsi.Length > _maxLength)
                throw new ArgumentException($"Deskripsi terlalu panjang. Maksimal {_maxLength} karakter.");
        }
    }
}