using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Models
{
    public enum ComplaintStatus
    {
        Pending,
        InProgress,
        Resolved
    }

    public class Complaint
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required string Category { get; set; } // "Kebersihan", "Keamanan", dsb.
        public DateTime Date { get; set; }

        public ComplaintStatus Status { get; set; } = ComplaintStatus.Pending;

        public void Validate()
        {
            // Preconditions: cek deskripsi dan kategori pengaduan (untuk saat ini hanya "Kebersihan")
            if (string.IsNullOrEmpty(Description))
                throw new ArgumentException("Deskripsi tidak boleh kosong.");

            if (Category != "Kebersihan")
                throw new ArgumentException("Kategori tidak valid. Hanya 'Kebersihan' yang diperbolehkan.");
        }

        public void AdvanceStatus()
        {
            switch (Status)
            {
                case ComplaintStatus.Pending:
                    Status = ComplaintStatus.InProgress;
                    break;
                case ComplaintStatus.InProgress:
                    Status = ComplaintStatus.Resolved;
                    break;
                case ComplaintStatus.Resolved:
                    throw new InvalidOperationException("Pengaduan sudah selesai. Tidak bisa melanjutkan status.");
                default:
                    throw new InvalidOperationException("Unknown status.");
            }
        }
    }
}
