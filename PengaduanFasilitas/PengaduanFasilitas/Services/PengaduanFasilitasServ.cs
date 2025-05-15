using PengaduanFasilitas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PengaduanFasilitas.Services
{
    public class PengaduanFasilitasServ
    {
        private List<Pengaduan> complaints = new();
        private readonly Validator validator = new();

        public void SubmitComplaint(string type, string description)
        {
            validator.Validate(type, description);
            complaints.Add(new Pengaduan(type, description));
            Console.WriteLine("Pengaduan berhasil dikirim.");
        }

        public void ShowAllComplaints()
        {
            if (!complaints.Any())
            {
                Console.WriteLine("Belum ada pengaduan.");
                return;
            }

            foreach (var c in complaints)
            {
                Console.WriteLine($"- [{c.Type}] {c.Description}");
            }
        }

        // Digunakan hanya untuk unit testing
        public List<Pengaduan> GetComplaints()
        {
            return complaints;
        }


    }
}
