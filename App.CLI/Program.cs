using System;
using System.IO;
using System.Linq;
using App.Core.Models;
using App.Core.Services;

public class Program
{
    private static PengaduanFasilitasService _pengaduanService;

    public static void Main(string[] args)
    {
        // --- Runtime Configuration ---
        // Menentukan lokasi file data. Pastikan folder 'Data' sudah ada.
        string dataPath = "Data";
        Directory.CreateDirectory(dataPath); // Membuat folder jika belum ada
        string filePath = Path.Combine(dataPath, "Fasilitas.json");

        // Inisialisasi service dengan path file
        _pengaduanService = new PengaduanFasilitasService(filePath);

        Console.WriteLine("======================================");
        Console.WriteLine("   Sistem Pengaduan Fasilitas v1.0    ");
        Console.WriteLine("======================================");

        bool isRunning = true;
        while (isRunning)
        {
            ShowMenu();
            Console.Write("Pilih menu: ");
            string pilihan = Console.ReadLine();
            Console.Clear(); // Bersihkan layar setelah memilih menu

            switch (pilihan)
            {
                case "1":
                    BuatPengaduanBaru();
                    break;
                case "2":
                    LihatSemuaPengaduan();
                    break;
                case "3":
                    LihatDetailPengaduan();
                    break;
                case "4":
                    UbahStatusPengaduan();
                    break;
                case "5":
                    UbahDataPengaduan();
                    break;
                case "6":
                    HapusPengaduan();
                    break;
                case "7":
                    isRunning = false;
                    Console.WriteLine("Terima kasih telah menggunakan aplikasi!");
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid, silakan coba lagi.");
                    break;
            }

            if (isRunning)
            {
                Console.WriteLine("\nTekan Enter untuk kembali ke menu...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        Console.WriteLine("\n\n===== Tes Selesai =====");
    }

    private static void ShowMenu()
    {
        Console.WriteLine("\n--- MENU UTAMA ---");
        Console.WriteLine("1. Buat Pengaduan Baru");
        Console.WriteLine("2. Lihat Semua Pengaduan");
        Console.WriteLine("3. Lihat Detail Pengaduan");
        Console.WriteLine("4. Ubah Status Pengaduan");
        Console.WriteLine("5. Ubah Data Pengaduan");
        Console.WriteLine("6. Hapus Pengaduan");
        Console.WriteLine("7. Keluar");
    }

    private static void BuatPengaduanBaru()
    {
        try
        {
            Console.WriteLine("--- BUAT PENGADUAN BARU ---");
            Console.Write("Nama Pelapor      : ");
            string nama = Console.ReadLine();
            Console.Write("Lokasi Kejadian   : ");
            string lokasi = Console.ReadLine();
            Console.Write("Jenis Fasilitas   : ");
            string jenis = Console.ReadLine();
            Console.Write("Deskripsi         : ");
            string deskripsi = Console.ReadLine();

            var detail = new DetailFasilitas(nama, lokasi, deskripsi, jenis);
            _pengaduanService.BuatPengaduan(detail);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nError: {ex.Message}");
            Console.ResetColor();
        }
    }

    private static void LihatSemuaPengaduan()
    {
        Console.WriteLine("--- DAFTAR SEMUA PENGADUAN ---");
        var semuaPengaduan = _pengaduanService.AmbilSemuaPengaduan();

        if (!semuaPengaduan.Any())
        {
            Console.WriteLine("Belum ada pengaduan yang dibuat.");
            return;
        }

        foreach (var p in semuaPengaduan)
        {
            Console.WriteLine($"ID: {p.Id} | Status: {p.Status} | Tgl: {p.TanggalDibuat:dd-MM-yyyy} | Jenis: {p.Detail.JenisFasilitas}");
        }
    }

    private static void LihatDetailPengaduan()
    {
        Console.WriteLine("--- DETAIL PENGADUAN ---");
        Console.Write("Masukkan ID Pengaduan: ");
        string id = Console.ReadLine();

        var p = _pengaduanService.AmbilPengaduanById(id);
        if (p == null)
        {
            Console.WriteLine("Pengaduan tidak ditemukan.");
            return;
        }

        Console.WriteLine($"\nID                : {p.Id}");
        Console.WriteLine($"Tanggal Dibuat    : {p.TanggalDibuat}");
        Console.WriteLine($"Status            : {p.Status}");
        Console.WriteLine("----------------------------------");
        Console.WriteLine($"Nama Pelapor      : {p.Detail.NamaPelapor}");
        Console.WriteLine($"Lokasi            : {p.Detail.Lokasi}");
        Console.WriteLine($"Jenis Fasilitas   : {p.Detail.JenisFasilitas}");
        Console.WriteLine($"Deskripsi         : {p.Detail.Deskripsi}");
    }

    private static void UbahStatusPengaduan()
    {
        Console.WriteLine("--- UBAH STATUS PENGADUAN ---");
        Console.Write("Masukkan ID Pengaduan: ");
        string id = Console.ReadLine();

        var p = _pengaduanService.AmbilPengaduanById(id);
        if (p == null)
        {
            Console.WriteLine("Pengaduan tidak ditemukan.");
            return;
        }

        Console.WriteLine("Pilih status baru:");
        var statusOptions = Enum.GetValues(typeof(StatusPengaduan)).Cast<StatusPengaduan>().ToList();
        for (int i = 0; i < statusOptions.Count; i++)
        {
            Console.WriteLine($"{i}. {statusOptions[i]}");
        }

        Console.Write("Pilihan Anda: ");
        if (int.TryParse(Console.ReadLine(), out int pilihan) && pilihan >= 0 && pilihan < statusOptions.Count)
        {
            StatusPengaduan statusBaru = statusOptions[pilihan];
            _pengaduanService.UbahStatus(id, statusBaru);
        }
        else
        {
            Console.WriteLine("Pilihan status tidak valid.");
        }
    }

    private static void UbahDataPengaduan()
    {
        Console.WriteLine("--- UBAH DATA PENGADUAN ---");
        Console.Write("Masukkan ID Pengaduan yang akan diubah: ");
        string id = Console.ReadLine();

        var p = _pengaduanService.AmbilPengaduanById(id);
        if (p == null)
        {
            Console.WriteLine("Pengaduan tidak ditemukan.");
            return;
        }

        try
        {
            Console.WriteLine("Masukkan data baru:");
            Console.Write("Nama Pelapor      : ");
            string nama = Console.ReadLine();
            Console.Write("Lokasi Kejadian   : ");
            string lokasi = Console.ReadLine();
            Console.Write("Jenis Fasilitas   : ");
            string jenis = Console.ReadLine();
            Console.Write("Deskripsi         : ");
            string deskripsi = Console.ReadLine();

            var detailBaru = new DetailFasilitas(nama, lokasi, deskripsi, jenis);
            _pengaduanService.UbahDataPengaduan(id, detailBaru);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nError: {ex.Message}");
            Console.ResetColor();
        }
    }

    private static void HapusPengaduan()
    {
        Console.WriteLine("--- HAPUS PENGADUAN ---");
        Console.Write("Masukkan ID Pengaduan yang akan dihapus: ");
        string id = Console.ReadLine();
        _pengaduanService.HapusPengaduan(id);
    }
}