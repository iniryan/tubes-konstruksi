using System.Text.Json.Nodes;
using PengaduanFasilitas.Services;

class Program
{
    static void Main()
    {
        var handler = new PengaduanFasilitasServ();
        var config = JsonNode.Parse(File.ReadAllText("config.json"));
        var allowedTypes = config["AllowedTypes"].AsArray().Select(t => t.ToString()).ToList();

        while (true)
        {
            Console.WriteLine("\n==========================================");
            Console.WriteLine("         SISTEM PENGADUAN FASILITAS       ");
            Console.WriteLine("==========================================");

            Console.WriteLine("Menu Utama:");
            Console.WriteLine("  1. Buat Pengaduan");
            Console.WriteLine("  2. Lihat Semua Pengaduan");
            Console.WriteLine("  3. Keluar");
            Console.Write("Pilih menu [1-3]: ");
            var input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine("\n------------------------------------------");
                Console.WriteLine("             FORMULIR PENGADUAN           ");
                Console.WriteLine("------------------------------------------");

                Console.WriteLine("Pilih Jenis Pengaduan:");
                for (int i = 0; i < allowedTypes.Count; i++)
                {
                    Console.WriteLine($"  {i + 1}. {allowedTypes[i]}");
                }

                Console.Write("Nomor Jenis Pengaduan: ");
                var typeInput = Console.ReadLine();

                int typeIndex;
                if (!int.TryParse(typeInput, out typeIndex) || typeIndex < 1 || typeIndex > allowedTypes.Count)
                {
                    Console.WriteLine("[ERROR] Pilihan tidak valid.");
                    continue;
                }

                var selectedType = allowedTypes[typeIndex - 1];

                Console.Write("Deskripsi Pengaduan     : ");
                var desc = Console.ReadLine();

                try
                {
                    handler.SubmitComplaint(selectedType, desc);
                    Console.WriteLine("Pengaduan berhasil dikirim.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"[ERROR] {ex.Message}");
                }
            }
            else if (input == "2")
            {
                Console.WriteLine("\n------------------------------------------");
                Console.WriteLine("             DAFTAR PENGADUAN             ");
                Console.WriteLine("------------------------------------------");

                handler.ShowAllComplaints();
            }
            else if (input == "3")
            {
                Console.WriteLine("Terima kasih telah menggunakan sistem ini.");
                break;
            }
            else
            {
                Console.WriteLine("[ERROR] Menu tidak dikenal.");
            }

            // Tambah baris pemisah setelah setiap aksi
            Console.WriteLine("\nTekan ENTER untuk kembali ke menu...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
