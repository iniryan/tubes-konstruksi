using System;
using App.Core.Models;
using App.Core.Services;

class Program
{
    static void Main()
    {
        var service = new ComplaintService<Complaint>();

        // Menambahkan pengaduan kebersihan
        var complaint = new Complaint
        {
            Id = 1,
            Description = "Sampah menumpuk di koridor.",
            Category = "Kebersihan",
            Date = DateTime.Now
        };

        service.AddComplaint(complaint);

        // Menampilkan pengaduan
        Console.WriteLine("Daftar Pengaduan:");
        foreach (var c in service.GetAllComplaints())
        {
            Console.WriteLine("[{0}] {1} - {2} ({3}) - Status: {4}", c.Id, c.Category, c.Description, c.Date, c.Status);
        }

        // Interaksi dengan pengguna untuk transisi status
        while (true)
        {
            Console.WriteLine("\nApa yang ingin Anda lakukan?");
            Console.WriteLine("1. Pindahkan status ke InProgress");
            Console.WriteLine("2. Pindahkan status ke Resolved");
            Console.WriteLine("3. Keluar");
            Console.Write("Pilihan (1/2/3): ");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                try
                {
                    complaint.AdvanceStatus(); // Pending → InProgress
                    Console.WriteLine(string.Format("Status sekarang: {0}", complaint.Status));
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(string.Format("Gagal transisi: {0}", ex.Message));
                }
            }
            else if (choice == "2")
            {
                try
                {
                    complaint.AdvanceStatus(); // InProgress → Resolved
                    Console.WriteLine(string.Format("Status sekarang: {0}", complaint.Status));
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(string.Format("Gagal transisi: {0}", ex.Message));
                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("Keluar dari aplikasi.");
                break;
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
            }
        }
    }
}
