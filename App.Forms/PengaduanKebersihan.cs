using App.Core.Models;
using App.Core.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class PengaduanKebersihan : UserControl
    {
        private readonly PengaduanKebersihanService _pengaduanService;
        private string? _selectedPengaduanId = null;

        public PengaduanKebersihan()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            // Inisialisasi service
            _pengaduanService = new PengaduanKebersihanService();

            // Tambahkan event handler
            this.Load += PengaduanKebersihan_Load;
            buttonSave.Click += buttonSave_Click;
            dataGridViewDataKebersihan.SelectionChanged += dataGridViewDataKebersihan_SelectionChanged;
            buttonClear.Click += buttonClear_Click;
            buttonDelete.Click += buttonDelete_Click;
        }

        private async void PengaduanKebersihan_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            SetupComboBoxes();
        }

        private async Task LoadDataAsync()
        {
            var data = await _pengaduanService.AmbilSemuaPengaduanAsync();

            // Transformasi data untuk ditampilkan di DataGridView
            var displayData = data.Select(p => new
            {
                p.Id,
                Pelapor = p.Detail.NamaPelapor,
                p.Detail.Lokasi,
                p.Detail.Deskripsi,
                p.Detail.Kategori,
                Prioritas = p.Detail.PrioritasPengaduan,
                p.Status,
                p.TanggalDibuat
            }).ToList();

            dataGridViewDataKebersihan.DataSource = displayData;

            // Atur visibilitas kolom
            dataGridViewDataKebersihan.Columns["Id"].Visible = false;
        }

        private void SetupComboBoxes()
        {
            // Setup ComboBox Prioritas
            comboBoxPrioritas.DataSource = Enum.GetValues(typeof(Prioritas));

            // Setup ComboBox Kategori (contoh)
            comboBoxKategori.Items.AddRange(new string[] { "Sampah", "Sanitasi", "Elektronik", "Listrik", "Aset Kantor" });
        }

        private async void dataGridViewDataKebersihan_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewDataKebersihan.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewDataKebersihan.SelectedRows[0];
                _selectedPengaduanId = selectedRow.Cells["Id"].Value.ToString();

                if (_selectedPengaduanId != null)
                {
                    var pengaduan = await _pengaduanService.AmbilPengaduanByIdAsync(_selectedPengaduanId);
                    if (pengaduan != null)
                    {
                        String textNama = "Ryan Santotso";
                        pengaduan.Detail.NamaPelapor = textNama;
                        //textBoxNamaPelapor.Text = pengaduan.Detail.NamaPelapor;
                        comboBoxPrioritas.SelectedItem = pengaduan.Detail.PrioritasPengaduan;
                        comboBoxKategori.SelectedItem = pengaduan.Detail.Kategori;
                        textBoxLokasi.Text = pengaduan.Detail.Lokasi;
                        richTextBoxDeskripsi.Text = pengaduan.Detail.Deskripsi;

                        // Set judul form dan teks tombol
                        labelTextFormKebersihan.Text = "Ubah Data Pengaduan";
                        buttonSave.Text = "Ubah Data";
                    }
                }
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                //string namaPelapor = textBoxNamaPelapor.Text;
                string namaPelapor = "Ryan Santoso";
                string lokasi = textBoxLokasi.Text;
                string deskripsi = richTextBoxDeskripsi.Text;
                Prioritas prioritas = (Prioritas)comboBoxPrioritas.SelectedItem;
                string kategori = comboBoxKategori.SelectedItem.ToString();

                if (string.IsNullOrWhiteSpace(namaPelapor) || string.IsNullOrWhiteSpace(lokasi) || string.IsNullOrWhiteSpace(deskripsi) || string.IsNullOrWhiteSpace(kategori))
                {
                    MessageBox.Show("Semua field harus diisi.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_selectedPengaduanId == null) // Mode Tambah
                {
                    await _pengaduanService.TambahPengaduanAsync(namaPelapor, deskripsi, lokasi, prioritas, kategori);
                    MessageBox.Show("Pengaduan berhasil ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Mode Ubah
                {
                    await _pengaduanService.UbahDataPengaduanAsync(_selectedPengaduanId, namaPelapor, deskripsi, lokasi, prioritas, kategori);
                    MessageBox.Show("Pengaduan berhasil diubah.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ClearForm();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            _selectedPengaduanId = null;
            //textBoxNamaPelapor.Clear();
            textBoxLokasi.Clear();
            richTextBoxDeskripsi.Clear();
            comboBoxPrioritas.SelectedIndex = 0;
            comboBoxKategori.SelectedIndex = -1;

            labelTextFormKebersihan.Text = "Form Pengaduan Kebersihan";
            buttonSave.Text = "Simpan Data";
            dataGridViewDataKebersihan.ClearSelection();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_selectedPengaduanId == null)
            {
                MessageBox.Show("Pilih pengaduan yang ingin dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Apakah Anda yakin ingin menghapus pengaduan ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    await _pengaduanService.HapusPengaduanAsync(_selectedPengaduanId);
                    MessageBox.Show("Pengaduan berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    await LoadDataAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menghapus data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {

        }

        private void richTextBoxDeskripsi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}