using App.Core.Models;
using App.Core.Services;
using App.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PengaduanFasilitas.Services
{
    public class PengaduanFasilitasService : IPengaduanService<DetailFasilitas>
    {
        private readonly string _filePath;
        private readonly Validator _validator;
        private List<Pengaduan<DetailFasilitas>> _dataCache;

        /// <summary>
        /// Constructor untuk PengaduanFasilitasService.
        /// </summary>
        /// <param name="filePath">Path ke file JSON untuk penyimpanan (Runtime Configuration).</param>
        public PengaduanFasilitasService(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentNullException(nameof(filePath), "File path tidak boleh kosong.");

            _filePath = filePath;

            // Inisialisasi komponen yang dibutuhkan
            _validator = new Validator();
            _dataCache = LoadDataFromFile();
        }

        #region Implementasi IPengaduanService

        public Pengaduan<DetailFasilitas> BuatPengaduan(DetailFasilitas detail)
        {
            // 1. Validasi input menggunakan Validator sebelum diproses
            _validator.Validate(detail);

            // 2. Proses pembuatan pengaduan jika valid
            var id = Guid.NewGuid().ToString();
            var pengaduanBaru = new Pengaduan<DetailFasilitas>(id, detail);

            _dataCache.Add(pengaduanBaru);
            SaveChangesToFile();

            Console.WriteLine("Pengaduan berhasil dibuat.");
            return pengaduanBaru;
        }

        public Pengaduan<DetailFasilitas>? AmbilPengaduanById(string id)
        {
            return _dataCache.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Pengaduan<DetailFasilitas>> AmbilSemuaPengaduan()
        {
            return _dataCache;
        }

        public void HapusPengaduan(string id)
        {
            var pengaduan = AmbilPengaduanById(id);
            if (pengaduan == null)
            {
                Console.WriteLine($"Error: Pengaduan dengan ID '{id}' tidak ditemukan.");
                return;
            }

            _dataCache.Remove(pengaduan);
            SaveChangesToFile();
            Console.WriteLine($"Pengaduan dengan ID '{id}' berhasil dihapus.");
        }

        public void UbahDataPengaduan(string id, DetailFasilitas detailBaru)
        {
            var pengaduanLama = AmbilPengaduanById(id);
            if (pengaduanLama == null)
            {
                Console.WriteLine($"Error: Pengaduan dengan ID '{id}' tidak ditemukan.");
                return;
            }

            // 1. Validasi juga data baru yang akan di-update
            _validator.Validate(detailBaru);

            // 2. Lanjutkan proses update jika data baru valid
            var pengaduanUpdate = new Pengaduan<DetailFasilitas>(
                pengaduanLama.Id,
                detailBaru,
                pengaduanLama.Status,
                pengaduanLama.TanggalDibuat
            );

            var index = _dataCache.FindIndex(p => p.Id == id);
            _dataCache[index] = pengaduanUpdate;

            SaveChangesToFile();
            Console.WriteLine("Data pengaduan berhasil diubah.");
        }

        public void UbahStatus(string id, StatusPengaduan statusBaru)
        {
            var pengaduan = AmbilPengaduanById(id);
            if (pengaduan == null)
            {
                Console.WriteLine($"Error: Pengaduan dengan ID '{id}' tidak ditemukan.");
                return;
            }

            try
            {
                pengaduan.UbahStatus(statusBaru);
                SaveChangesToFile();
                Console.WriteLine($"Status pengaduan berhasil diubah menjadi '{statusBaru}'.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        #endregion

        #region Private Helper Methods (Code Reuse)

        /// <summary>
        /// Memuat data dari file JSON. Mengenkapsulasi logika pembacaan file.
        /// </summary>
        private List<Pengaduan<DetailFasilitas>> LoadDataFromFile()
        {
            return JsonUtils.ReadDataAsync<Pengaduan<DetailFasilitas>>(_filePath).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Menyimpan data cache saat ini ke dalam file JSON. Mengenkapsulasi logika penulisan file.
        /// </summary>
        private void SaveChangesToFile()
        {
            JsonUtils.WriteDataAsync(_filePath, _dataCache).GetAwaiter().GetResult();
        }

        #endregion
    }
}