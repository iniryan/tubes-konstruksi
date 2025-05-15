using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestApp.Models
{
    public class Tamu
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string NomorIdentitas { get; set; }
        public string Tujuan { get; set; }
        public string PegawaiTujuan { get; set; }
        public DateTime WaktuDatang { get; set; } = DateTime.Now;
        public DateTime? WaktuKeluar { get; set; }
    }
}