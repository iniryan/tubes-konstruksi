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
            Console.WriteLine("4. Cari Pengaduan Berdasarkan ID");
            Console.WriteLine("5. Hapus Pengaduan");
            Console.WriteLine("6. Ubah Data Pengaduan");
            Console.WriteLine("7. Kembali ke Menu Utama");
            Console.Write("Pilih menu (1-7): ");
            var pilihan = Console.ReadLine();

            switch (pilihan)
            {
                case "1":
                    Console.Write("\nMasukkan nama pelapor: ");
                    var nama = Console.ReadLine();
                    Console.Write("Masukkan masalah: ");
                    var masalah = Console.ReadLine();
                    Console.Write("Masukkan lokasi: ");
                    var lokasi = Console.ReadLine();
                    Console.Write("Masukkan kategori (misalnya: Sampah, Saluran Air, WC Umum, Lainnya): ");
                    var kategori = Console.ReadLine();

                    Console.WriteLine("Pilih prioritas:");
                    Console.WriteLine("1. Rendah");
                    Console.WriteLine("2. Sedang");
                    Console.WriteLine("3. Tinggi");
                    Console.Write("Pilih prioritas (1-3): ");
                    var prioritasInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(masalah)
                        || string.IsNullOrWhiteSpace(lokasi) || string.IsNullOrWhiteSpace(kategori)
                        || string.IsNullOrWhiteSpace(prioritasInput))
                    {
                        Console.WriteLine("Semua data harus diisi.");
                        break;
                    }

                    try
                    {
                        var prioritas = prioritasInput switch
                        {
                            "1" => Prioritas.Rendah,
                            "2" => Prioritas.Sedang,
                            "3" => Prioritas.Tinggi,
                            _ => throw new ArgumentException("Prioritas tidak valid.")
                        };

                        var pengaduan = service.TambahPengaduan(nama, masalah, lokasi, prioritas, kategori);
                        Console.WriteLine("Pengaduan berhasil ditambahkan dengan ID: " + pengaduan.Id);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Gagal menambah pengaduan: " + ex.Message);
                    }
                    break;

                case "2":
                    var semuaPengaduan = service.AmbilSemuaPengaduan();
                    Console.WriteLine("\nDaftar Pengaduan Kebersihan:");

                    if (semuaPengaduan.Count == 0)
                    {
                        Console.WriteLine("Tidak ada data pengaduan yang tersedia.");
                    } 
                    else 
                    {
                        foreach (var p in semuaPengaduan)
                        {
                            Console.WriteLine(p.ToString());
                        }
                    }
                    break;

                case "3":
                    string? idUbah;
                    Pengaduan<PengaduanKebersihan>? pengaduanUbahStatus;

                    while(true)
                    {
                        Console.Write("\nMasukkan ID pengaduan yang ingin diubah statusnya (atau ketik 'exit' untuk kembali): ");
                        idUbah = Console.ReadLine();

                        if (idUbah?.ToLower() == "exit")
                        {
                            break;
                        }

                        if (string.IsNullOrWhiteSpace(idUbah))
                        {
                            Console.WriteLine("ID tidak boleh kosong.");
                            continue;
                        }

                        pengaduanUbahStatus = service.AmbilPengaduanById(idUbah);
                        if (pengaduanUbahStatus == null)
                        {
                            Console.WriteLine("Pengaduan tidak ditemukan. Silakan masukkan ID yang valid.");
                            continue;
                        }

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
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Gagal mengubah status: " + ex.Message);
                        }
                    }
                    break;

                case "4":
                    String? idCari;
                    Pengaduan<PengaduanKebersihan>? pengaduanCari;

                    while(true)
                    {
                        Console.Write("\nMasukkan ID pengaduan yang ingin dicari (atau ketik 'exit' untuk kembali): ");
                        idCari = Console.ReadLine();

                        if (idCari?.ToLower() == "exit")
                        {
                            break;
                        }

                        if (string.IsNullOrWhiteSpace(idCari))
                        {
                            Console.WriteLine("ID tidak boleh kosong.");
                            continue;
                        }

                        pengaduanCari = service.AmbilPengaduanById(idCari);
                        if (pengaduanCari != null)
                        {
                            Console.WriteLine("\nDetail Pengaduan:");
                            Console.WriteLine(pengaduanCari.ToString());
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Pengaduan tidak ditemukan. Silakan masukkan ID yang valid.");
                            continue;
                        }
                    }
                    break;

                case "5":
                    String? idHapus;
                    Pengaduan<PengaduanKebersihan>? pengaduanHapus;

                    while(true)
                    {
                        Console.Write("\nMasukkan ID pengaduan yang ingin dihapus (atau ketik 'exit' untuk kembali): ");
                        idHapus = Console.ReadLine();

                        if (idHapus?.ToLower() == "exit")
                        {
                            break;
                        }

                        if (string.IsNullOrWhiteSpace(idHapus))
                        {
                            Console.WriteLine("ID tidak boleh kosong.");
                            continue;
                        }

                        pengaduanHapus = service.AmbilPengaduanById(idHapus);
                        if (pengaduanHapus == null)
                        {
                            Console.WriteLine("Pengaduan tidak ditemukan. Silakan masukkan ID yang valid.");
                            continue;
                        }

                        try
                        {
                            service.HapusPengaduan(idHapus);
                            Console.WriteLine("Pengaduan berhasil dihapus.");
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Gagal menghapus pengaduan: " + ex.Message);
                        }
                    }
                    break;

                case "6":
                    String? idUbahData;
                    Pengaduan<PengaduanKebersihan>? pengaduanData;

                    while(true)
                    {
                        Console.Write("\nMasukkan ID pengaduan yang ingin diubah (atau ketik 'exit' untuk kembali): ");
                        idUbahData = Console.ReadLine();

                        if (idUbahData?.ToLower() == "exit")
                        {
                            break;
                        }

                        if (string.IsNullOrWhiteSpace(idUbahData))
                        {
                            Console.WriteLine("ID tidak boleh kosong");
                            continue;
                        }

                        pengaduanData = service.AmbilPengaduanById(idUbahData);
                        if (pengaduanData == null)
                        {
                            Console.WriteLine("Pengaduan tidak ditemukan. Silakan masukkan ID yang valid.");
                            continue;
                        }

                        Console.WriteLine("\nData pengaduan saat ini:");
                        Console.WriteLine("Nama Pelapor: " + pengaduanData.Detail.NamaPelapor);
                        Console.WriteLine("Kategori: " + pengaduanData.Detail.Kategori);
                        Console.WriteLine("Prioritas: " + pengaduanData.Detail.PrioritasPengaduan);
                        Console.WriteLine("Masalah: " + pengaduanData.Detail.Masalah);
                        Console.WriteLine("Lokasi: " + pengaduanData.Detail.Lokasi);

                        Console.Write("\nMasukkan nama pelapor baru (kosongkan untuk mempertahankan): ");
                        var namaBaru = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(namaBaru))
                        {
                            namaBaru = pengaduanData.Detail.NamaPelapor;
                        }

                        Console.Write("Masukkan masalah baru (kosongkan untuk mempertahankan): ");
                        var masalahBaru = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(masalahBaru))
                        {
                            masalahBaru = pengaduanData.Detail.Masalah;
                        }

                        Console.Write("Masukkan lokasi baru (kosongkan untuk mempertahankan): ");
                        var lokasiBaru = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(lokasiBaru))
                        {
                            lokasiBaru = pengaduanData.Detail.Lokasi;
                        }

                        Console.Write("Masukkan kategori baru (kosongkan untuk mempertahankan): ");
                        var kategoriBaru = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(kategoriBaru))
                        {
                            kategoriBaru = pengaduanData.Detail.Kategori;
                        }

                        Console.WriteLine("Pilih prioritas baru (kosongkan untuk mempertahankan):");
                        Console.WriteLine("1. Rendah");
                        Console.WriteLine("2. Sedang");
                        Console.WriteLine("3. Tinggi");
                        Console.Write("Pilih prioritas baru (1-3, kosongkan untuk mempertahankan): ");
                        var prioritasBaruInput = Console.ReadLine();
                        Prioritas prioritasBaru;
                        if (string.IsNullOrWhiteSpace(prioritasBaruInput))
                        {
                            prioritasBaru = pengaduanData.Detail.PrioritasPengaduan;
                        }
                        else
                        {
                            prioritasBaru = prioritasBaruInput switch
                            {
                                "1" => Prioritas.Rendah,
                                "2" => Prioritas.Sedang,
                                "3" => Prioritas.Tinggi,
                                _ => throw new ArgumentException("Prioritas tidak valid.")
                            };
                        }

                        try
                        {
                            service.UbahDataPengaduan(idUbahData, namaBaru, masalahBaru, lokasiBaru, prioritasBaru, kategoriBaru);
                            Console.WriteLine("Data pengaduan berhasil diubah.");
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Gagal mengubah data pengaduan: " + ex.Message);
                        }
                    }
                    break;

                case "7":
                    Console.WriteLine("\nKembali ke menu utama...");
                    return;

                default:
                    Console.WriteLine("\nPilihan tidak valid. Silakan coba lagi.");
                    break;
            }
        }
    }
}
