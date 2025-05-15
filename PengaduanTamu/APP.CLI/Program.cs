using GuestApp.Models;
using GuestApp.Helpers;
using GuestApp.Data;

Dictionary<int, Action> menu = new Dictionary<int, Action>
{
    { 1, () => GuestRepository.TambahTamu() },
    { 2, () => GuestRepository.LihatSemuaTamu() },
    { 3, () => GuestRepository.CariTamu() },
    { 4, () => GuestRepository.CheckoutTamu() },
    { 5, () => GuestRepository.TampilkanStatistik() },
    { 6, () => GuestRepository.HapusTamu() },
    { 7, () => Environment.Exit(0) }
};

while (true)
{
    Console.Clear();
    Console.WriteLine("===== Aplikasi Pelaporan Tamu =====");
    Console.WriteLine("1. Tambah Data Tamu Baru");
    Console.WriteLine("2. Lihat Daftar Semua Tamu");
    Console.WriteLine("3. Cari Tamu");
    Console.WriteLine("4. Checkout Tamu");
    Console.WriteLine("5. Statistik Harian");
    Console.WriteLine("6. Hapus Data Tamu (Admin)");
    Console.WriteLine("7. Keluar");
    Console.Write("Pilih menu: ");

    if (int.TryParse(Console.ReadLine(), out int pilih) && menu.ContainsKey(pilih))
        menu[pilih].Invoke();
    else
        Console.WriteLine("Input tidak valid.");
}
