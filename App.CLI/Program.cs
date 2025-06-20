using System;
using System.Threading.Tasks;
using App.Core.Models;
using App.Core.Services;

namespace App.CLI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("=== Aplikasi CLI Pengaduan ===");
            Console.WriteLine();

            try
            {
                // Test service initialization
                Console.WriteLine("Initializing services...");

                var kebersihanService = new PengaduanKebersihanService();
                var fasilitasService = new PengaduanFasilitasService();
                var keamananService = new PengaduanKeamananService();
                var guestRepository = new GuestRepository();
                var authService = new AuthService();
                var userCreationService = new UserCreationService(authService);

                Console.WriteLine("✅ All services initialized successfully!");

                // Simple menu demo
                await DemoServices(kebersihanService, fasilitasService, keamananService, guestRepository, authService, userCreationService);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        private static async Task DemoServices(
            PengaduanKebersihanService kebersihan,
            PengaduanFasilitasService fasilitas,
            PengaduanKeamananService keamanan,
            GuestRepository guest,
            AuthService auth,
            UserCreationService userCreation)
        {
            Console.WriteLine("\n=== SERVICE DEMO ===");

            try
            {
                // Demo Kebersihan
                Console.WriteLine("\n1. Testing Kebersihan Service:");
                var pengaduanKebersihan = await kebersihan.TambahPengaduanAsync(
                    1, "John Doe", "Ruang A", "Sampah berserakan", Prioritas.Sedang, "Sampah");
                Console.WriteLine($"✅ Kebersihan pengaduan created: {pengaduanKebersihan.Id}");                // Demo Fasilitas
                Console.WriteLine("\n2. Testing Fasilitas Service:");
                var pengaduanFasilitas = await fasilitas.TambahPengaduanAsync(
                    1, "Jane Smith", "Lab B", "Lampu rusak", Prioritas.Tinggi, "Lampu Jalan");
                Console.WriteLine($"✅ Fasilitas pengaduan created: {pengaduanFasilitas.Id}");

                // Demo Keamanan
                Console.WriteLine("\n3. Testing Keamanan Service:");
                var pengaduanKeamanan = await keamanan.TambahPengaduanAsync(
                    1, "Bob Wilson", "Parkir C", "Pintu rusak", "Akses Tidak Sah", "Tinggi");
                Console.WriteLine($"✅ Keamanan pengaduan created: {pengaduanKeamanan.Id}");

                // Demo Guest
                Console.WriteLine("\n4. Testing Guest Repository:");
                var tamu = await guest.TambahTamuAsync(
                    1, "Alice Johnson", "Lobby", "Kunjungan meeting", "1234567890", "Meeting", "Manager", null);
                Console.WriteLine($"✅ Guest entry created: {tamu.Id}");

                // Demo Auth
                Console.WriteLine("\n5. Testing Auth Service:");
                var user = await auth.RegisterAsync("testuser", "password123", "civilian", "Jl. Test", "08123456789", "Test User");
                Console.WriteLine($"✅ User registered: {user.Username}");

                var loginUser = await auth.LoginAsync("testuser", "password123");
                Console.WriteLine($"✅ User logged in: {loginUser.Name}");

                // Demo User Creation
                Console.WriteLine("\n6. Testing User Creation Service:");
                var autoUser = await userCreation.CreateNewUserAsync("Automatic User");
                Console.WriteLine($"✅ Auto user created: {autoUser.Username}");

                // Statistics
                Console.WriteLine("\n=== STATISTICS ===");
                var totalKebersihan = await kebersihan.HitungTotalPengaduanAsync();
                var totalFasilitas = await fasilitas.HitungTotalPengaduanAsync();
                var totalKeamanan = await keamanan.HitungTotalPengaduanAsync();
                var totalTamu = await guest.HitungTotalPengaduanAsync();
                var totalUsers = await userCreation.GetTotalUsersCountAsync();

                Console.WriteLine($"📊 Total Kebersihan: {totalKebersihan}");
                Console.WriteLine($"🔧 Total Fasilitas: {totalFasilitas}");
                Console.WriteLine($"🔒 Total Keamanan: {totalKeamanan}");
                Console.WriteLine($"👥 Total Tamu: {totalTamu}");
                Console.WriteLine($"👤 Total Users: {totalUsers}");

                Console.WriteLine("\n✅ All services working correctly!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Demo error: {ex.Message}");
            }
        }
    }
}