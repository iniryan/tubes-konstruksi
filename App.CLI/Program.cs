using System;
using System.Threading.Tasks;
using App.Core.Models;
using App.Core.Services;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("===== Aplikasi Tes Pengaduan Kebersihan =====");

        var service = new PengaduanKebersihanService();
        string idPengaduanBaru = "";

        try
        {
            // TEST CREATE
            Console.WriteLine("\n[TEST 1] Menambahkan pengaduan baru...");
            var pengaduanDibuat = await service.TambahPengaduanAsync(
                namaPelapor: "Budi Santoso",
                deskripsi: "Tumpukan sampah di depan lobi.",
                lokasi: "Lobi Utama",
                prioritas: Prioritas.Tinggi,
                kategori: "Sampah"
            );
            idPengaduanBaru = pengaduanDibuat.Id;
            Console.WriteLine("-> SUKSES: Pengaduan berhasil dibuat.");
            Console.WriteLine(pengaduanDibuat);
            Console.WriteLine("-> CEK: File 'Database/Kebersihan.json' seharusnya sudah terisi data.");


            // TEST READ
            Console.WriteLine("\n[TEST 2] Mengambil semua data pengaduan...");
            var semuaPengaduan = await service.AmbilSemuaPengaduanAsync();
            if (semuaPengaduan.Count > 0)
            {
                Console.WriteLine($"-> SUKSES: Ditemukan {semuaPengaduan.Count} pengaduan.");
                foreach (var p in semuaPengaduan)
                {
                    Console.WriteLine("   " + p);
                }
            }
            else
            {
                Console.WriteLine("-> INFO: Tidak ada data pengaduan yang ditemukan.");
            }

            // TEST UPDATE
            Console.WriteLine($"\n[TEST 3] Mengubah status pengaduan ID: {idPengaduanBaru} menjadi 'Diproses'...");
            await service.UbahStatusAsync(idPengaduanBaru, StatusPengaduan.Diproses);
            Console.WriteLine("-> SUKSES: Status berhasil diubah.");

            var pengaduanDiupdate = await service.AmbilPengaduanByIdAsync(idPengaduanBaru);
            Console.WriteLine("-> Verifikasi data terbaru:");
            Console.WriteLine("   " + pengaduanDiupdate);

            // TEST UPDATE DATA
            Console.WriteLine($"\n[TEST 4] Mengubah detail data pengaduan ID: {idPengaduanBaru}...");
            await service.UbahDataPengaduanAsync(
                id: idPengaduanBaru,
                namaPelapor: "Budi Santoso (Diperbarui)",
                deskripsi: "Tumpukan sampah di depan lobi utama gedung A.",
                lokasi: "Lobi Gedung A",
                prioritas: Prioritas.Sedang,
                kategori: "Sampah Organik"
            );
            Console.WriteLine("-> SUKSES: Detail data berhasil diubah.");

            // TEST DELETE
            //Console.WriteLine($"\n[TEST 4] Menghapus pengaduan ID: {idPengaduanBaru}...");
            //await service.HapusPengaduanAsync(idPengaduanBaru);
            //Console.WriteLine("-> SUKSES: Pengaduan berhasil dihapus.");

            //var pengaduanSetelahHapus = await service.AmbilSemuaPengaduanAsync();
            //Console.WriteLine($"-> Verifikasi: Jumlah pengaduan sekarang adalah {pengaduanSetelahHapus.Count}.");

        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nTerjadi kesalahan: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("\n===== Tes Selesai =====");
    }
}