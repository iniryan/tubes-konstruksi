using System;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Models;
using App.Core.Services;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("===== Aplikasi Tes Pengaduan Kebersihan =====");

        var service = new PengaduanKebersihanService();

        try
        {
            // === PERSIAPAN DATA UJI COBA ===
            Console.WriteLine("\nINFO: Mempersiapkan data uji coba...");
            var semuaDataLama = await service.AmbilSemuaPengaduanAsync();
            foreach (var item in semuaDataLama) { await service.HapusPengaduanAsync(item.Id); }

            // Tambahkan data contoh
            await service.TambahPengaduanAsync("Budi Santoso", "AC tidak dingin", "Lantai 5", Prioritas.Tinggi, "Elektronik");
            await Task.Delay(5); // Jeda kecil untuk memastikan TanggalDibuat berbeda
            var p2 = await service.TambahPengaduanAsync("Siti Aminah", "Keran bocor", "Toilet Wanita Lt. 2", Prioritas.Sedang, "Sanitasi");
            await Task.Delay(5);
            var p3 = await service.TambahPengaduanAsync("Budi Santoso", "Lampu koridor mati", "Koridor Blok C", Prioritas.Rendah, "Listrik");
            await Task.Delay(5);
            var p4 = await service.TambahPengaduanAsync("Andi Wijaya", "Proyektor rusak", "Ruang Rapat 3A", Prioritas.Tinggi, "Elektronik");
            await Task.Delay(5);
            var p5 = await service.TambahPengaduanAsync("Rina Lestari", "Sampah menumpuk", "Pantry Lt. 4", Prioritas.Sedang, "Sampah");

            // Ubah beberapa status untuk data uji dengan alur yang benar
            await service.UbahStatusAsync(p2.Id, StatusPengaduan.Diproses);
            await service.UbahStatusAsync(p3.Id, StatusPengaduan.Diproses);
            await service.UbahStatusAsync(p3.Id, StatusPengaduan.Selesai);
            await service.UbahStatusAsync(p5.Id, StatusPengaduan.Ditolak);

            Console.WriteLine("-> SUKSES: Data uji coba berhasil dibuat.");

            // === PENGUJIAN FUNGSI UPDATE ===

            // [TEST 3] Mengubah Detail Data Pengaduan
            Console.WriteLine($"\n===== [TEST 3] PENGUJIAN UBAH DETAIL DATA (ID: {p4.Id.Substring(0, 8)}) =====");
            Console.WriteLine("Data Sebelum Diubah:");
            Console.WriteLine($"  -> {await service.AmbilPengaduanByIdAsync(p4.Id)}");

            await service.UbahDataPengaduanAsync(
                id: p4.Id,
                namaPelapor: "Andi Wijaya", // Nama tetap
                deskripsi: "Proyektor di Ruang Rapat 3A gambarnya buram dan kekuningan.", // Deskripsi diubah
                lokasi: "Ruang Rapat 3A (Gedung B)", // Lokasi diubah
                prioritas: Prioritas.Sedang, // Prioritas diubah
                kategori: "Aset Kantor" // Kategori diubah
            );

            Console.WriteLine("\nData Setelah Diubah:");
            Console.WriteLine($"  -> {await service.AmbilPengaduanByIdAsync(p4.Id)}");
            Console.WriteLine("-> SUKSES: Detail data berhasil diubah.");

            // =================================================================
            // [BAGIAN 1] DASBOR UTAMA ADMIN (KPI & GRAFIK)
            // =================================================================
            Console.WriteLine("\n\n" + new string('=', 50));
            Console.WriteLine("===== [BAGIAN 1] DASBOR UTAMA (ADMIN VIEW) =====");
            Console.WriteLine(new string('=', 50));

            // 1.1: Kartu Statistik Utama (KPI)
            Console.WriteLine("\n--- Kartu Statistik Utama (KPI) ---");
            var kpi = await service.HitungStatistikUtamaAsync();
            Console.WriteLine($"  Total Pengaduan Masuk   : {kpi.totalSemua}");
            Console.WriteLine($"  Pengaduan Perlu Diproses: {kpi.perluDiproses}");

            // 1.2: Grafik Batang - Jumlah Pengaduan per Kategori
            Console.WriteLine("\n--- Grafik Batang: Jumlah Pengaduan per Kategori ---");
            var dataGrafikKategori = await service.HitungJumlahPerKategoriAsync();
            if (dataGrafikKategori.Any())
            {
                int maxLabelLength = dataGrafikKategori.Keys.Max(k => k.Length);
                foreach (var kvp in dataGrafikKategori.OrderByDescending(kv => kv.Value))
                {
                    Console.Write($"  {kvp.Key.PadRight(maxLabelLength)} | ");
                    Console.WriteLine(new string('█', kvp.Value) + $" ({kvp.Value})");
                }
            }

            // 1.3: Grafik Lingkaran - Komposisi Status Pengaduan
            Console.WriteLine("\n--- Grafik Lingkaran: Komposisi Status Pengaduan ---");
            var dataGrafikStatus = await service.HitungKomposisiStatusAsync();
            if (kpi.totalSemua > 0)
            {
                foreach (var kvp in dataGrafikStatus.OrderBy(kv => kv.Key.ToString()))
                {
                    double percentage = (double)kvp.Value / kpi.totalSemua * 100;
                    Console.WriteLine($"  {kvp.Key,-10}: {kvp.Value} pengaduan ({percentage:F1}%)");
                }
            }

            // =================================================================
            // [BAGIAN 2] DASBOR TINDAKAN ADMIN (ACTIONABLE LISTS)
            // =================================================================
            Console.WriteLine("\n\n" + new string('=', 50));
            Console.WriteLine("===== [BAGIAN 2] DAFTAR TINDAKAN (ADMIN VIEW) =====");
            Console.WriteLine(new string('=', 50));

            // 2.1: Ambil 5 pengaduan terbaru
            Console.WriteLine("\n--- 5 Pengaduan Terbaru ---");
            var pengaduanTerbaru = await service.AmbilPengaduanTerbaruAsync(5);
            foreach (var p in pengaduanTerbaru)
            {
                Console.WriteLine($"  ID: {p.Id.Substring(0, 8)} | Kategori: {p.Detail.Kategori,-12} | Dibuat: {p.TanggalDibuat:g}");
            }

            // 2.2: Ambil pengaduan terlama yang belum selesai
            Console.WriteLine("\n--- Pengaduan Terlama Berstatus 'Diproses' ---");
            var pengaduanTerlama = await service.AmbilPengaduanTerlamaBelumSelesaiAsync(5);
            foreach (var p in pengaduanTerlama)
            {
                Console.WriteLine($"  ID: {p.Id.Substring(0, 8)} | Status: {p.Status,-8} | Pelapor: {p.Detail.NamaPelapor}");
            }

            // =================================================================
            // [BAGIAN 3] DASBOR PELAPOR (USER VIEW)
            // =================================================================
            Console.WriteLine("\n\n" + new string('=', 50));
            Console.WriteLine("===== [BAGIAN 3] DASBOR PELAPOR (Nama: Budi Santoso) =====");
            Console.WriteLine(new string('=', 50));
            string namaPelaporTes = "Budi Santoso";

            // 3.1: Hitung statistik pengaduan
            Console.WriteLine("\n--- Kartu Statistik Pribadi ---");
            var statistik = await service.HitungStatistikPengaduanPelaporAsync(namaPelaporTes);
            Console.WriteLine($"  Total Pengaduan Saya: {statistik.total}");
            Console.WriteLine($"  Pengaduan Diproses  : {statistik.diproses}");
            Console.WriteLine($"  Pengaduan Selesai   : {statistik.selesai}");

            // 3.2: Ambil daftar pengaduan terakhir
            Console.WriteLine("\n--- Daftar 5 Pengaduan Terakhir Saya ---");
            var pengaduanTerakhirPelapor = await service.AmbilPengaduanTerakhirPelaporAsync(namaPelaporTes, 5);
            foreach (var p in pengaduanTerakhirPelapor)
            {
                Console.WriteLine($"  ID: {p.Id.Substring(0, 8)} | Kategori: {p.Detail.Kategori,-12} | Dibuat: {p.TanggalDibuat:d} | Status: {p.Status}");
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nTerjadi kesalahan: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("\n\n===== Tes Selesai =====");
    }
}
