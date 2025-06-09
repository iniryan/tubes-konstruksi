using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PengaduanFasilitas.Models
{
    public class Pengaduan
    {
        public string Type { get; set; }
        public string Description { get; set; }

        public Pengaduan(string type, string description)
        {
            Type = type;
            Description = description;
        }
    }
}
