using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuestApp.Models;
using GuestApp.Helpers;

namespace GuestApp.Data
{
    public static class GuestRepository
    {
        private static List<Tamu> daftarTamu = new List<Tamu>();
        private static int nextId = 1;

        public static void TambahTamu()
        {
            Console.Write("Nama: ");
            var nama = Console.ReadLine();
            Console.Write("No Identitas: ");
            var id = Console.ReadLine();
            Console.Write("Tujuan: ");
            var tujuan = Console.ReadLine();
            Console.Write("Pegawai yang Dituju: ");
            var pegawai = Console.ReadLine();

            daftarTamu.Add(new Tamu
            {
                Id = nextId++,
                Nama = nama,
                NomorIdentitas = id,
                Tujuan = tujuan,
                PegawaiTujuan = pegawai
            });

            Console.WriteLine("Tamu berhasil ditambahkan!");
            Console.ReadKey();
        }

        public static void LihatSemuaTamu()
        {
            foreach (var t in daftarTamu)
            {
                Console.WriteLine($"{t.Id}. {t.Nama} - {t.Tujuan} - Masuk: {t.WaktuDatang} - Keluar: {(t.WaktuKeluar.HasValue ? t.WaktuKeluar.ToString() : "Belum keluar")}");
            }
            Console.ReadKey();
        }

        public static void CariTamu()
        {
            Console.Write("Masukkan nama atau tanggal (yyyy-mm-dd): ");
            string input = Console.ReadLine();
            var hasil = TamuHelper.CariTamu(daftarTamu, input);

            foreach (var t in hasil)
            {
                Console.WriteLine($"{t.Id}. {t.Nama} - {t.Tujuan}");
            }

            Console.ReadKey();
        }

        public static void CheckoutTamu()
        {
            Console.Write("Masukkan ID Tamu: ");
            int id = int.Parse(Console.ReadLine());
            var tamu = daftarTamu.FirstOrDefault(t => t.Id == id);

            if (tamu != null)
            {
                tamu.WaktuKeluar = DateTime.Now;
                Console.WriteLine("Checkout berhasil.");
            }
            else
            {
                Console.WriteLine("Tamu tidak ditemukan.");
            }
            Console.ReadKey();
        }

        public static void TampilkanStatistik()
        {
            int jumlah = TamuHelper.HitungHarian(daftarTamu);
            Console.WriteLine($"Jumlah kunjungan hari ini: {jumlah}");
            Console.ReadKey();
        }

        public static void HapusTamu()
        {
            Console.Write("Masukkan ID Tamu yang akan dihapus: ");
            int id = int.Parse(Console.ReadLine());
            var tamu = daftarTamu.FirstOrDefault(t => t.Id == id);
            if (tamu != null)
            {
                daftarTamu.Remove(tamu);
                Console.WriteLine("Data tamu dihapus.");
            }
            else
            {
                Console.WriteLine("Tamu tidak ditemukan.");
            }
            Console.ReadKey();
        }
    }
}
