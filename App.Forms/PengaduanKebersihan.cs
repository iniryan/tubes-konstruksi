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
            buttonClear.Click += buttonClear_Click;
            buttonDelete.Click += buttonDelete_Click;
            dataGridViewDataKebersihan.SelectionChanged += dataGridViewDataKebersihan_SelectionChanged;
            dataGridViewDataKebersihan.RowPostPaint += dataGridViewDataKebersihan_RowPostPaint;
        }

        private async void PengaduanKebersihan_Load(object? sender, EventArgs e)
        {
            SetupDataGridViewStyles();
            SetupComboBoxes();
            await LoadDataAsync();
        }

        private void SetupDataGridViewStyles()
        {
            dataGridViewDataKebersihan.RowHeadersVisible = true;

            dataGridViewDataKebersihan.TopLeftHeaderCell.Value = "Pilih Data";

            var headerStyle = dataGridViewDataKebersihan.ColumnHeadersDefaultCellStyle;
            headerStyle.BackColor = Color.Navy;
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridViewDataKebersihan.TopLeftHeaderCell.Style.ApplyStyle(headerStyle);

            dataGridViewDataKebersihan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridViewDataKebersihan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDataKebersihan.AllowUserToAddRows = false;
            dataGridViewDataKebersihan.AllowUserToDeleteRows = false;
            dataGridViewDataKebersihan.ReadOnly = true;
        }

        private void dataGridViewDataKebersihan_RowPostPaint(object? sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dataGridViewDataKebersihan.Rows[e.RowIndex].Selected)
            {
                return;
            }

            string symbol = "▶";
            Font font = new Font("Segoe UI", 10, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(Color.Gray);

            SizeF stringSize = e.Graphics.MeasureString(symbol, font);

            float x = e.RowBounds.Left + (dataGridViewDataKebersihan.RowHeadersWidth - stringSize.Width) / 2;
            float y = e.RowBounds.Top + (e.RowBounds.Height - stringSize.Height) / 2;

            e.Graphics.DrawString(symbol, font, brush, x, y);
        }

        private async Task LoadDataAsync()
        {
            var data = await _pengaduanService.AmbilSemuaPengaduanAsync();

            var displayData = data.Select(p => new
            {
                p.Id,
                Pelapor = p.Detail.NamaPelapor,
                p.Status,
                Prioritas = p.Detail.PrioritasPengaduan,
                p.Detail.Kategori,
                p.Detail.Lokasi,
                p.Detail.Deskripsi,
                p.TanggalDibuat
            }).ToList();

            dataGridViewDataKebersihan.DataSource = displayData;

            // Atur visibilitas kolom
            dataGridViewDataKebersihan.Columns["Id"].Visible = false;
        }

        private void SetupComboBoxes()
        {
            comboBoxPrioritas.DataSource = Enum.GetValues(typeof(Prioritas));

            comboBoxKategori.Items.AddRange(new string[] { "Sampah", "Sanitasi", "Elektronik", "Listrik", "Aset Kantor" });
        }

        private async void dataGridViewDataKebersihan_SelectionChanged(object? sender, EventArgs e)
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

                        labelTextFormKebersihan.Text = "Ubah Data Pengaduan";
                        buttonSave.Text = "Ubah Data";
                    }
                }
            }
        }

        private async void buttonSave_Click(object? sender, EventArgs e)
        {
            try
            {
                //string namaPelapor = textBoxNamaPelapor.Text;
                string namaPelapor = "Ryan Santoso";
                string lokasi = textBoxLokasi.Text;
                string deskripsi = richTextBoxDeskripsi.Text;

                if (comboBoxPrioritas.SelectedItem is not Prioritas prioritas)
                {
                    MessageBox.Show("Prioritas harus dipilih.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string? kategori = comboBoxKategori.SelectedItem?.ToString();

                if (string.IsNullOrWhiteSpace(namaPelapor) || string.IsNullOrWhiteSpace(lokasi) || string.IsNullOrWhiteSpace(deskripsi) || string.IsNullOrWhiteSpace(kategori))
                {
                    MessageBox.Show("Semua field harus diisi.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mode Tambah
                if (_selectedPengaduanId == null)
                {
                    await _pengaduanService.TambahPengaduanAsync(namaPelapor, deskripsi, lokasi, prioritas, kategori);
                    MessageBox.Show("Pengaduan berhasil ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Mode Ubah
                else
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

        private void buttonClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private async void buttonDelete_Click(object? sender, EventArgs e)
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
    }
}