using System;
using App.Core.Models;
using App.Core.Services;

class Program
{
    static void Main()
    {
        var service = new PengaduanKebersihanService();

        Console.WriteLine("========================================");
        Console.WriteLine("Selamat datang di aplikasi pengaduan");
        Console.WriteLine("========================================");

        while (true)
        {
            Console.WriteLine("\nPilih jenis pengaduan:");
            Console.WriteLine("1. Pengaduan Kebersihan");
            Console.WriteLine("2. Keluar");
            Console.Write("Pilih menu pengaduan (1-2): ");
            var pilihan = Console.ReadLine();

            if (pilihan == "1")
            {
                KelolaPengaduanKebersihan(service);
            }
            else if (pilihan == "2")
            {
                Console.WriteLine("\nTerima kasih telah menggunakan aplikasi pengaduan. Sampai jumpa!");
                break;
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
            }
        }
    }

    static void KelolaPengaduanKebersihan(PengaduanKebersihanService service)
    {
        while (true)
        {
            Console.WriteLine("\n=== Pengaduan Kebersihan ===");
            Console.WriteLine("1. Tambah Pengaduan");
            Console.WriteLine("2. Lihat Semua Pengaduan");
            Console.WriteLine("3. Ubah Status Pengaduan");
            Console.WriteLine("4. Kembali ke Menu Utama");
            Console.Write("Pilih menu (1-4): ");
            var pilihan = Console.ReadLine();

            switch (pilihan)
            {
                case "1":
                    Console.Write("\nMasukkan masalah: ");
                    var masalah = Console.ReadLine();
                    Console.Write("Masukkan lokasi: ");
                    var lokasi = Console.ReadLine();

                    try
                    {
                        var pengaduan = service.TambahPengaduan(masalah, lokasi);
                        Console.WriteLine($"Pengaduan berhasil ditambahkan dengan ID: {pengaduan.Id}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Gagal menambah pengaduan: {ex.Message}");
                    }
                    break;

                case "2":
                    var semuaPengaduan = service.AmbilSemuaPengaduan();
                    Console.WriteLine("\nDaftar Pengaduan Kebersihan:");
                    foreach (var p in semuaPengaduan)
                    {
                        Console.WriteLine(p.ToString());
                    }
                    break;

                case "3":
                    Console.Write("\nMasukkan ID pengaduan yang ingin diubah statusnya: ");
                    var idUbah = Console.ReadLine();

                    // Menampilkan status
                    Console.WriteLine("Pilih status baru:");
                    Console.WriteLine("1. Diproses");
                    Console.WriteLine("2. Selesai");
                    Console.WriteLine("3. Ditolak");
                    Console.Write("Pilih status (1-3): ");
                    var statusPilihan = Console.ReadLine();

                    try
                    {
                        var statusBaru = statusPilihan switch
                        {
                            "1" => StatusPengaduan.Diproses,
                            "2" => StatusPengaduan.Selesai,
                            "3" => StatusPengaduan.Ditolak,
                            _ => throw new ArgumentException("Pilihan status tidak valid")
                        };

                        service.UbahStatus(idUbah, statusBaru);
                        Console.WriteLine("Status pengaduan berhasil diubah.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Gagal mengubah status: {ex.Message}");
                    }
                    break;

                case "4":
                    Console.WriteLine("\nKembali ke menu utama...");
                    return;

                default:
                    Console.WriteLine("\nPilihan tidak valid. Silakan coba lagi.");
                    break;
            }
        }
    }
}
