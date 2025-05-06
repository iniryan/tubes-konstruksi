using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Models;

namespace App.Core.Services
{
    public class ComplaintService<T> where T : Complaint
    {
        private readonly List<T> _complaints = new();

        // Menambahkan pengaduan ke dalam list
        public void AddComplaint(T complaint)
        {
            complaint.Validate();  // Validasi sebelum ditambahkan
            _complaints.Add(complaint);
        }

        // Mengambil semua pengaduan
        public IEnumerable<T> GetAllComplaints() => _complaints;
    }
}
