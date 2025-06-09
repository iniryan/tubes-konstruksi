using System;
using PengaduanKeamananCLI.Models;
using PengaduanKeamananCLI.Services;
using PengaduanKeamananCLI.Utils;
using System.Collections.Generic;

namespace PengaduanKeamananCLI.Services
{
    public static class MenuService
    {
        private static readonly Dictionary<int, string> statusTable = new()
        {
            {1, "Baru"},
            {2, "Diproses"},
            {3, "Selesai"}
        };

        public static void ShowLoginMenu()
        {
            while (true)
            {
                Console.WriteLine("=== LOGIN ===");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register User Baru");
                Console.WriteLine("3. Keluar");
                Console.Write("Pilih menu: ");
                string menu = Console.ReadLine();
                if (menu == "1")
                {
                    string username = ConsoleUtils.ReadNonEmpty("Username: ");
                    Console.Write("Password: ");
                    string password = ConsoleUtils.ReadPassword();
                    var user = AuthService.Login(username, password);
                    if (user != null)
                    {
                        Console.WriteLine($"\nLogin berhasil sebagai {user.Role}!\n");
                        if (user.Role == "admin")
                            ShowAdminMenu();
                        else
                            ShowUserMenu(user);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Login gagal! Coba lagi.\n");
                    }
                }
                else if (menu == "2")
                {
                    ShowRegisterMenu();
                }
                else if (menu == "3")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Menu tidak valid!\n");
                }
            }
        }

        public static void ShowRegisterMenu()
        {
            Console.WriteLine("\n=== Register User Baru ===");
            string username = ConsoleUtils.ReadNonEmpty("Username: ");
            Console.Write("Password: ");
            string password = ConsoleUtils.ReadPassword();
            if (AuthService.Register(username, password))
                Console.WriteLine("Registrasi berhasil! Silakan login.\n");
            else
                Console.WriteLine("Username sudah terdaftar!\n");
        }

        public static void ShowUserMenu(User user)
        {
            var menuTable = new Dictionary<string, Action> {
                {"1", () => TambahPengaduan(user.Username) },
                {"2", () => LihatPengaduanUser(user.Username) },
                {"3", () => Environment.Exit(0) }
            };
            while (true)
            {
                Console.WriteLine("=== MENU USER ===");
                Console.WriteLine("1. Tambah Pengaduan");
                Console.WriteLine("2. Lihat Daftar Pengaduan Saya");
                Console.WriteLine("3. Keluar");
                Console.Write("Pilih menu: ");
                string? pilih = Console.ReadLine();
                if (pilih != null && menuTable.TryGetValue(pilih, out var action))
                    action();
                else
                    Console.WriteLine("Menu tidak valid!\n");
            }
        }

        public static void ShowAdminMenu()
        {
            var menuTable = new Dictionary<string, Action> {
                {"1", LihatPengaduan },
                {"2", FilterPengaduanByStatus },
                {"3", UbahStatusPengaduan },
                {"4", HapusPengaduan },
                {"5", () => Environment.Exit(0) }
            };
            while (true)
            {
                Console.WriteLine("=== MENU ADMIN ===");
                Console.WriteLine("1. Lihat Daftar Pengaduan");
                Console.WriteLine("2. Filter Pengaduan Berdasarkan Status");
                Console.WriteLine("3. Ubah Status Pengaduan");
                Console.WriteLine("4. Hapus Pengaduan");
                Console.WriteLine("5. Keluar");
                Console.Write("Pilih menu: ");
                string? pilih = Console.ReadLine();
                if (pilih != null && menuTable.TryGetValue(pilih, out var action))
                    action();
                else
                    Console.WriteLine("Menu tidak valid!\n");
            }
        }

        // --- USER ---
        private static void TambahPengaduan(string username)
        {
            Console.WriteLine("\n=== Tambah Pengaduan ===");
            var pengaduan = new Pengaduan
            {
                NamaPengadu = username,
                RT = ConsoleUtils.ReadNonEmpty("RT: "),
                JenisKejadian = ConsoleUtils.ReadNonEmpty("Jenis Kejadian: "),
                IsiKeluhan = ConsoleUtils.ReadNonEmpty("Isi Keluhan: "),
                LokasiKeluhan = ConsoleUtils.ReadNonEmpty("Lokasi Keluhan: "),
                Status = 1
            };
            PengaduanService.TambahPengaduan(pengaduan);
            Console.WriteLine("\nPengaduan berhasil ditambahkan!\n");
        }

        private static void LihatPengaduanUser(string username)
        {
            Console.WriteLine("\n=== Daftar Pengaduan Anda ===");
            var list = PengaduanService.GetByUser(username);
            if (list.Count == 0)
            {
                Console.WriteLine("Belum ada pengaduan.");
                return;
            }
            Console.WriteLine($"{"ID",-4} {"RT",-4} {"Jenis",-15} {"Status",-10} {"Lokasi",-15} {"Keluhan"}");
            foreach (var p in list)
            {
                statusTable.TryGetValue(p.Status, out var statusDesc);
                statusDesc ??= "?";
                Console.WriteLine($"{p.Id,-4} {p.RT,-4} {p.JenisKejadian,-15} {statusDesc,-10} {p.LokasiKeluhan,-15} {p.IsiKeluhan}");
            }
            Console.WriteLine();
        }

        // --- ADMIN ---
        private static void LihatPengaduan()
        {
            Console.WriteLine("\n=== Daftar Pengaduan ===");
            var list = PengaduanService.GetAll();
            if (list.Count == 0)
            {
                Console.WriteLine("Belum ada pengaduan.");
                return;
            }
            Console.WriteLine($"{"ID",-4} {"Nama",-15} {"RT",-4} {"Jenis",-15} {"Status",-10} {"Lokasi",-15} {"Keluhan"}");
            foreach (var p in list)
            {
                statusTable.TryGetValue(p.Status, out var statusDesc);
                statusDesc ??= "?";
                Console.WriteLine($"{p.Id,-4} {p.NamaPengadu,-15} {p.RT,-4} {p.JenisKejadian,-15} {statusDesc,-10} {p.LokasiKeluhan,-15} {p.IsiKeluhan}");
            }
            Console.WriteLine();
        }

        private static void FilterPengaduanByStatus()
        {
            Console.WriteLine("\nPilih status untuk filter:");
            foreach (var kv in statusTable)
            {
                Console.WriteLine($"{kv.Key}. {kv.Value}");
            }
            Console.Write("Status: ");
            if (!int.TryParse(Console.ReadLine(), out int status) || !statusTable.ContainsKey(status))
            {
                Console.WriteLine("Status tidak valid!\n");
                return;
            }
            Console.WriteLine($"\n=== Daftar Pengaduan dengan Status: {statusTable[status]} ===");
            var list = PengaduanService.GetByStatus(status);
            if (list.Count == 0)
            {
                Console.WriteLine("Tidak ada pengaduan dengan status ini.");
                return;
            }
            Console.WriteLine($"{"ID",-4} {"Nama",-15} {"RT",-4} {"Jenis",-15} {"Status",-10} {"Lokasi",-15} {"Keluhan"}");
            foreach (var p in list)
            {
                statusTable.TryGetValue(p.Status, out var statusDesc);
                statusDesc ??= "?";
                Console.WriteLine($"{p.Id,-4} {p.NamaPengadu,-15} {p.RT,-4} {p.JenisKejadian,-15} {statusDesc,-10} {p.LokasiKeluhan,-15} {p.IsiKeluhan}");
            }
            Console.WriteLine();
        }

        private static void UbahStatusPengaduan()
        {
            LihatPengaduan();
            Console.Write("Masukkan ID pengaduan yang ingin diubah statusnya: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID tidak valid!\n");
                return;
            }
            Console.WriteLine("Pilih status baru:");
            foreach (var kv in statusTable)
            {
                Console.WriteLine($"{kv.Key}. {kv.Value}");
            }
            Console.Write("Status: ");
            if (!int.TryParse(Console.ReadLine(), out int statusBaru) || !statusTable.ContainsKey(statusBaru))
            {
                Console.WriteLine("Status tidak valid!\n");
                return;
            }
            if (PengaduanService.UpdateStatus(id, statusBaru))
                Console.WriteLine("Status pengaduan berhasil diubah!\n");
            else
                Console.WriteLine("ID pengaduan tidak ditemukan!\n");
        }

        private static void HapusPengaduan()
        {
            LihatPengaduan();
            Console.Write("Masukkan ID pengaduan yang ingin dihapus: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID tidak valid!\n");
                return;
            }
            if (PengaduanService.Delete(id))
                Console.WriteLine("Pengaduan berhasil dihapus!\n");
            else
                Console.WriteLine("ID pengaduan tidak ditemukan!\n");
        }
    }
} 